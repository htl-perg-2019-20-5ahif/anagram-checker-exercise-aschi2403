using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramChecker_Library
{
    internal class CharacterSorter : ICharacterSorter
    {
        public string SortCharacters(string originalString)
        {
            var characters = originalString.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
