using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnagramChecker_Library
{
    internal class AnagramParser : IAnagramParser
    {
        private ICharacterSorter characterSorter = new CharacterSorter();

        public IEnumerable<AnagramList> ParseAnagrams(IEnumerable<string> lines)
        {
            var anagramLists = new List<AnagramList>();

            foreach(var line in lines)
            {
                var words = line.Split(',');
                var anagramList = new AnagramList();
                anagramList.words.AddRange(words);

                anagramList.literals = characterSorter.SortCharacters(words[0]);

                anagramLists.Add(anagramList);
            }

            return anagramLists;
        }
    }
}
