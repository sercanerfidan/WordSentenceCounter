using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordSentenceCounter.Services
{
    public class TextHelperService : ITextHelperService
    {

        public Task<List<string>> RemoveInvalidCharacters(string[] sentences)
        {
            List<string> cleanSentences = new List<string>();
            string cleanSentence = string.Empty;
            foreach (var item in sentences)
            {
                cleanSentence = Regex.Replace(item, "[^A-Za-z0-9 ]", "");
                cleanSentences.Add(cleanSentence);
            }

            return Task.FromResult(cleanSentences);
        }
    }
}
