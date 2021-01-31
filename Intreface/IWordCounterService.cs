using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordSentenceCounter.Services
{
    public interface IWordCounterService
    {
        Task<string> StartUp(int threadCount, string text);

        Task FindSentences(string text);

        void CalucateAvarageOfWordCount(List<string> sentences);

        void UpdateTaskInfo(int threadId, int processedSentenceCount);

        void UpdateWordCountInfo(List<string> wordList);

        string WriteProcessResults();
    }
}
