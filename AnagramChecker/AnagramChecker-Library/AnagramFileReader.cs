using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_Library
{
    internal class AnagramFileReader : IAnagramReader
    {
        private string filePath;
        private IAnagramParser anagramParser;
        private IEnumerable<string> lines;

        public AnagramFileReader(string filePath)
        {
            this.filePath = filePath;
            anagramParser = new AnagramParser();
        }

        public IEnumerable<AnagramList> ReadAnagrams()
        {
            lines = ReadFromFile();
            return ParseAnagramList();
        }

        private List<string> ReadFromFile()
        {
            return new List<string>(System.IO.File.ReadAllLines(filePath));
        }

        private IEnumerable<AnagramList> ParseAnagramList()
        {
            return anagramParser.ParseAnagrams(lines);
        }
    }
}
