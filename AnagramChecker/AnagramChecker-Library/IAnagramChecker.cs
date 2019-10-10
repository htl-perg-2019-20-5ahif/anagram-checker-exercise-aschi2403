using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_Library
{
    public interface IAnagramChecker
    {
        IEnumerable<string> GetAnagrams(string originalString);
        Boolean CheckIfAnagrams(string firstWord, string secondWord);
    }
}
