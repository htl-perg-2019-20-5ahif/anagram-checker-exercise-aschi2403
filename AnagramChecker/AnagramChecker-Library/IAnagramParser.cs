using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_Library
{
    internal interface IAnagramParser
    {
        IEnumerable<AnagramList> ParseAnagrams(IEnumerable<string> lines);
    }
}
