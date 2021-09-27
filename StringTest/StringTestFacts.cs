using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StringTest
{
    public static class StringTestFacts
    {
        [Fact]
        public static void ReturnNoOfVocalsAndConsonants()
        {
            const string word = " 'aabbbbceitu@";
            (int vocalsNo, int consNo) = GetNoOfVowelsAndConsonants(word);
            Assert.Equal(6, consNo);
            Assert.Equal(5, vocalsNo);
        }

        [Fact]
        public static void ReturnFirstNonRepeatingCharacter()
        {
            const string word = "aabbbbeitu";
            var firstNonRepeatedChar = GetFirstNonRepeatingCharacter(word);
            Assert.Equal('e', firstNonRepeatedChar);
        }

        [Fact]
        public static void ReturnFromStringAnInteger()
        {
            const string numberAsString = "6534";
            var numbersAsInt = GetIntegerFromString(numberAsString);
            Assert.Equal(6534, numbersAsInt);
        }

        [Fact]
        public static void ReturnFromStringCharWithMoreOccurrences()
        {
            const string word = "aaaaaaabstwqeeeertwesl";
            var character = GetCharWithMostOccurrencesInAString(word);
            Assert.Equal('a', character);
        }

        [Fact]
        public static void ReturnPalindromeSubstrings()
        {
            const string word = "aabaac";
            var palindromCombinations = GetSubstringsThatArePalindrome(word);
            Assert.Equal("aba", palindromCombinations[8]);
        }

        private static char GetCharWithMostOccurrencesInAString(string word)
        {
            return word.GroupBy(x => x).Aggregate((max, i) => max.Count() > i.Count() ? max : i).Key;
        }

        private static string[] GetSubstringsThatArePalindrome(string word)
        {
            return Enumerable
    .Range(1, word.Length)
    .SelectMany(size => Enumerable
       .Range(0, word.Length - size + 1)
       .Select(i => word.Substring(i, size)))
    .Where(item => item.SequenceEqual(item.Reverse()))
    .ToArray();
        }

        private static int GetIntegerFromString(string word)
        {
            int sign = 1;
            if (word.StartsWith('-'))
            {
                word = word[1..];
                sign = -1;
            }

            return word.Select(x =>
            char.IsDigit(x) ?
            x - '0' :
            throw new ArgumentException("the character is not a valid integer", nameof(x)))
                .Aggregate((result, x) => result * 10 + x) * sign;
        }

        private static (int vocalsNo, int consNo) GetNoOfVowelsAndConsonants(this string word)
        {
            const string vowels = "aeiou";
            return word.Aggregate((v: 0, c: 0), (total, c) =>
            {
                if (char.IsLetter(c))
                {
                    return vowels.Contains(c) ? (total.v + 1, total.c) : (total.v, total.c + 1);
                }

                return (total.v, total.c);
            });
        }

        private static char GetFirstNonRepeatingCharacter(this string word)
        {
            return word.GroupBy(x => x).First(x => x.Count() == 1).Key;
        }
    }
}
