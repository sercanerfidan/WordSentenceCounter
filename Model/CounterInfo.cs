using System;
using System.Collections.Generic;
using System.Text;

namespace WordSentenceCounter.Model
{
    public class CounterInfo
    {
        public int SentenceCount { get; set; }

        public List<string> Sentences { get; set; }

        public List<string> Words { get; set; }
        public double AvarageOfWordCount { get; set; }

        public List<ThreadInfo> ThreadCount { get; set; }

        public List<WordInfo> WordCount { get; set; }
    }
}
