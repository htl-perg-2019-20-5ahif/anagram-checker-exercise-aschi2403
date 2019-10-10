using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramChecker_Library
{
    public class AnagramChecker : IAnagramChecker
    {
        private IAnagramReader anagramReader;
        private IEnumerable<AnagramList> anagramLists;
        private ICharacterSorter characterSorter = new CharacterSorter();

        public AnagramChecker(string path)
        {
            anagramReader = new AnagramFileReader(path);
            anagramLists = anagramReader.ReadAnagrams();
        }
        public bool CheckIfAnagrams(string firstWord, string secondWord)
        {
            return characterSorter.SortCharacters(firstWord).Equals(characterSorter.SortCharacters(secondWord));
        }

        public IEnumerable<string> GetAnagrams(string originalString)
        {
            var finalAnagramLists = anagramLists.Where(p => p.literals.Equals(characterSorter.SortCharacters(originalString)));
            var anagrams = new List<string>();

            foreach(var anagramList in anagramLists)
            {
                foreach(var anagram in anagramList.words)
                {
                    anagrams.Add(anagram);
                }
            }

            return anagrams;
        }

        private IEnumerable 
    }
}
