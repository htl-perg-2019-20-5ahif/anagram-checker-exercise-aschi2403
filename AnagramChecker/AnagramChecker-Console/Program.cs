using System;
using System.Linq;
using AnagramChecker_Library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace AnagramChecker_Console
{
    class Program
    {
        static IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        static string path = config["filepath"];
        static AnagramChecker anagramChecker = new AnagramChecker(path);

        static void Main(string[] args)
        {
            if (args[0].Equals("check"))
                CheckIfAnagrams(args[1], args[2]);
            else
                GetAnagrams(args[1]);
        }

        static void GetAnagrams(string word)
        {
            var anagrams = anagramChecker.GetAnagrams(word);
            if (anagrams.ToList().Count == 0)
            {

                Console.WriteLine("No known anagrams found");
            }
            else
            {
                foreach (var anagram in anagrams)
                {
                    Console.WriteLine(anagram);
                }
            }
        }

        static void CheckIfAnagrams(string firstWord, string secondWord)
        {
            if (anagramChecker.CheckIfAnagrams(firstWord, secondWord))
                Console.WriteLine("\"{0}\" and \"{1}\" are anagrams", firstWord, secondWord);
            else
                Console.WriteLine("\"{0}\" and \"{1}\" are no anagrams", firstWord, secondWord);
        }
    }
}
