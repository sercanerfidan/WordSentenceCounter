using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSentenceCounter.Model;

namespace WordSentenceCounter.Services
{
    public class WordCounterService : IWordCounterService
    {
        private CounterInfo counterInfo;
        private readonly ITextHelperService textHelperService;
        List<Task> tasks;
        private static readonly object lockObj = new object();
        public WordCounterService(ITextHelperService textHelperService)
        {
            this.textHelperService = textHelperService;
        }

        public void CalucateAvarageOfWordCount(List<string> sentences)
        {
            double wordCount = 0;
            double sentenceCount = sentences.Count;

            foreach (var sentence in sentences) {

                wordCount += sentence.Split(' ').Length;
            }

            double avgOfWordCount = (double)(wordCount / sentenceCount);

            counterInfo.AvarageOfWordCount = avgOfWordCount;

        }

        public async Task FindSentences(string text)
        {
            string[] sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            counterInfo.Sentences = await textHelperService.RemoveInvalidCharacters(sentences);
            counterInfo.SentenceCount = counterInfo.Sentences.Count;
        }

        public async Task<string> StartUp(int threadCount, string text)
        {

            counterInfo = new CounterInfo();
            counterInfo.Sentences = new List<string>();
            counterInfo.Words = new List<string>();
            counterInfo.ThreadCount = new List<ThreadInfo>();
            counterInfo.WordCount = new List<WordInfo>();

            await FindSentences(text);
            CalucateAvarageOfWordCount(counterInfo.Sentences);

            var takeCount = counterInfo.SentenceCount / threadCount;

            if (takeCount == 0) {
                takeCount = 1;
            }

            List<IEnumerable<string>> listOfPartition = new List<IEnumerable<string>>();
            int totalTakeCount = 0;
            for (int i = 0; i < threadCount; i ++)
            {
                if (totalTakeCount == counterInfo.Sentences.Count) {
                    takeCount = 0;
                }

                if (i == threadCount - 1  && counterInfo.Sentences.Count > threadCount)
                {
                    takeCount = counterInfo.Sentences.Count - totalTakeCount;

                }

                listOfPartition.Add(counterInfo.Sentences.Skip(i).Take(takeCount));
                totalTakeCount += takeCount;
            }

            tasks = new List<Task>();
            foreach (var item in listOfPartition)
            {

                tasks.Add(Task.Run(async () =>
                {

                    await WordParserProcess(item);
                    await Task.Delay(2000);
                }));

            }
        
            Task.WaitAll(tasks.ToArray());

            string result = WriteProcessResults();

            return result;
        }

        public async Task WordParserProcess(IEnumerable<string> sentenceList) {

            List<string> wordList = new List<string>();

            foreach (var sentence in sentenceList) {

                string[] words = sentence.Split(' ');
                wordList.AddRange(words);

            }

            int threadId = Thread.CurrentThread.ManagedThreadId;
            int processedSentenceCount = sentenceList.ToList().Count;

            lock (lockObj)
            {

                UpdateTaskInfo(threadId, processedSentenceCount);

                UpdateWordCountInfo(wordList);

            }

        }

        public void UpdateTaskInfo(int threadId, int processedSentenceCount) {


            bool isThreadIdExist = counterInfo.ThreadCount.Any(x => x.ThreadId == threadId);
            if (!isThreadIdExist)
            {
                counterInfo.ThreadCount.Add(new ThreadInfo
                {
                    ThreadId = threadId,
                    ThreadCount = processedSentenceCount
                });
            }
            else
            {
                if (processedSentenceCount != 0)
                {

                    counterInfo.ThreadCount.Single(x => x.ThreadId == threadId).ThreadCount += 1;
                }
            }
        }

        public void UpdateWordCountInfo(List<string> wordList) {
            foreach (var item in wordList)
            {
                bool isWordItemContains = counterInfo.WordCount.Any(x => x.Word == item);
                if (isWordItemContains)
                {

                    counterInfo.WordCount.Single(x => x.Word == item).WordCount += 1;

                }
                else
                {
                    counterInfo.WordCount.Add(new WordInfo
                    {
                        Word = item,
                        WordCount = 1
                    });
                }

            }
        }

        public string WriteProcessResults() {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Sentence Count : {0}{1}", counterInfo.SentenceCount, Environment.NewLine);
            sb.AppendFormat("Avg. Word Count: {0}{1}{2}", counterInfo.AvarageOfWordCount, Environment.NewLine, Environment.NewLine);
            sb.AppendFormat("Thread Counts: {0}{1}", Environment.NewLine, Environment.NewLine);

            foreach (var item in counterInfo.ThreadCount) {

                sb.AppendFormat("Thread Id= {0}", item.ThreadId);
                sb.Append(", ");
                sb.AppendFormat("Count={0}{1}", item.ThreadCount, Environment.NewLine);
            }
           
            List<WordInfo> sortredWordInfoList = counterInfo.WordCount.OrderByDescending(o => o.WordCount).ToList();
           
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            
            foreach (var item in sortredWordInfoList)
            {

                sb.Append(item.Word);
                sb.Append(" ");
                sb.Append(item.WordCount);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

    }
}
