using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordSentenceCounter.Services
{
    public interface ITextHelperService
    {
       Task<List<string>> RemoveInvalidCharacters(string[] sentenceList);
    }
}
