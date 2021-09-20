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
            const string numberAsString = "-1234";
            var numbersAsInt = GetIntegerFromString(numberAsString);
            Assert.Equal(-1234, numbersAsInt);
        }

        [Fact]
        public static void ReturnFromStringCharWithMoreOCurrance()
        {
            const string word = "abstwqeeeertwesl";
            var character = word.GroupBy(x => x).Where(x => x.Key > 1);
        }

        private static int GetIntegerFromString(string word)
        {
            if (word.StartsWith('-') && word[1..].All(x => char.IsDigit(x)))
            {
                return word[1..].Select(x => x - '0').Aggregate((result, x) => result * 10 + x) * -1;
            }
            else if (word.All(x => char.IsDigit(x)))
            {
                return word.Select(x => x - '0').Aggregate((result, x) => result * 10 + x);
            }

            throw new ArgumentException("Please enter a valid number", nameof(word));
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
