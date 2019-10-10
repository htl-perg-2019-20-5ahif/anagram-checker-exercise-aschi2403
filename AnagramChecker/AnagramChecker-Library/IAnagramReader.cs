using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_Library
{
    internal interface IAnagramReader
    {
        IEnumerable<AnagramList> ReadAnagrams();
    }
}
