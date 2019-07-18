using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
    public class FindAnagrams
    {
        public static void FindAnagramsInListOfWords(List<string> words, ref List<string> anagramSets, ref int anagramsCount)
        {
            string separator = "";
            separator = " ";
            var rearrangedWord = new List<string>();
            //Strip out the words that aren't anagrams of other words
            foreach (string a in words)
            {
                string currentRearrangedWord;

                string currentWord = a.ToLower();
                //set current word in loop with its characters in alphabetic order
                currentRearrangedWord = FindAnagrams.MakeAlphabetic(currentWord);
                rearrangedWord.Add(currentRearrangedWord);
            }

            //get all duplicates using Linq
            var duplicates = rearrangedWord
              .Select((x, i) => new { i, x })
                     .GroupBy(x => x.x)
                     .Where(g => g.Count() > 1)
                     .ToDictionary(g => g.Key, g => g.Select(x => x.i).ToList());

            anagramsCount = duplicates.Count;

            string currentAnagramWord;
            int currentAnagramWordIndex;

            //populate anagramSets for each duplicate set of words
            foreach (string wordThatIsAnagram in duplicates.Keys)
            {
                string currentAnagramSetsLine = "";
                currentAnagramWord = wordThatIsAnagram;
                foreach (int indexInWordList in duplicates[wordThatIsAnagram])
                {
                    currentAnagramWordIndex = indexInWordList;

                    if (anagramSets.Contains(wordThatIsAnagram))
                    {
                    }
                    else
                    {
                        currentAnagramSetsLine += words[currentAnagramWordIndex].ToLower();

                        currentAnagramSetsLine += separator;
                    }
                }
                if (anagramSets.Contains(currentAnagramWord))
                {
                }
                else
                {
                    anagramSets.Add(currentAnagramSetsLine);
                }
            }

        }

        public static string MakeAlphabetic(string currentWord)
        {
            // Convert to char array.
            char[] a = currentWord.ToCharArray();

            // Sort letters.
            Array.Sort(a);

            // Return modified string.
            return new string(a);
        }
    }
}
