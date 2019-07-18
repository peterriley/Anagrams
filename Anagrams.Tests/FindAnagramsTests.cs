using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anagrams;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Anagrams.Tests
{
    [TestClass]
    public class FindAnagramsTests
    {
        [TestMethod]
        public void TestMakeAlphabetic()
        {
            // Arrange
            var currentWord = "zebra";
            var expected = "aberz";

            // Act
            var actual = FindAnagrams.MakeAlphabetic(currentWord);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFindAnagramsInListOfWords_1()
        {
            // Arrange
            var currentWordList = new List<string>() { "Board", "Broad", "Bard" };
            var returnedAnagramSets = new List<string>();
            int returnedAnagramsCount = 0;

            var expected = new List<string>() { "board broad " };
            var expectedSequence = expected.SelectMany(x => x).ToList();

            // Act
            FindAnagrams.FindAnagramsInListOfWords(currentWordList, ref returnedAnagramSets, ref returnedAnagramsCount);
            var actual = returnedAnagramSets;
            var actualSequence = actual.SelectMany(x => x).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual, StructuralComparisons.StructuralComparer);
            CollectionAssert.AreEqual(expectedSequence, actualSequence, StructuralComparisons.StructuralComparer);
        }

        [TestMethod]
        public void TestFindAnagramsInListOfWords_2()
        {
            // Arrange
            var currentWordList = new List<string>() { "Board", "Broad", "Bard", "This", "Hits" };
            var returnedAnagramSets = new List<string>();
            int returnedAnagramsCount = 0;

            var expected = new List<string>() { "board broad ", "this hits " };
            var expectedSequence = expected.SelectMany(x => x).ToList();

            // Act
            FindAnagrams.FindAnagramsInListOfWords(currentWordList, ref returnedAnagramSets, ref returnedAnagramsCount);
            var actual = returnedAnagramSets;
            var actualSequence = actual.SelectMany(x => x).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual, StructuralComparisons.StructuralComparer);
            CollectionAssert.AreEqual(expectedSequence, actualSequence, StructuralComparisons.StructuralComparer);
        }

    }
}
