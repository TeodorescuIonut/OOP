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
            var firstNonRepeatedChar = word.GroupBy(x => x).First(x => x.Count() == 1).Key;
            Assert.Equal(char.Parse("e"), firstNonRepeatedChar);
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
    }
}
