using System;
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
            const string numberAsString = "-6534a";
            var numbersAsInt = GetIntegerFromString(numberAsString);
            Assert.Equal(-6534, numbersAsInt);
        }

        [Fact]
        public static void ReturnFromStringCharWithMoreOCurrance()
        {
            const string word = "abstwqeeeertwesl";
            var character = word.GroupBy(x => x).Where(x => x.Key > 1);
        }

        private static int GetIntegerFromString(string word)
        {
                return word.Select(x =>
                    {
                        if (word.StartsWith('-'))
                        {
                            word = word[1..];
                            return 0;
                        }

                        if (char.IsDigit(x))
                        {
                            return x - '0';
                        }

                        throw new ArgumentException("the character is not a valid integer", nameof(x));
                    }).Aggregate((result, x) => result <= 0 ? result * 10 - x : result * 10 + x);
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
