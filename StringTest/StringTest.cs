using System;
using System.Linq;
using Xunit;

namespace StringTest
{
    public class StringTest
    {
        [Fact]
        public void ReturnNoOfVocalsAndConsonants()
        {
            const string word = " 'aabbbbceitu@";
            const string vowels = "aeiou";
            (int vocalsNo, int consNo) = word.Aggregate((v: 0, c: 0), (total, c) =>
            {
                if (char.IsLetter(c))
                {
                    if (vowels.Contains(c))
                    {
                        return (total.v + 1, total.c);
                    }

                    return (total.v, total.c + 1);
                }

                return (total.v, total.c);
            });
            Assert.Equal(6, consNo);
            Assert.Equal(5, vocalsNo);
        }

        [Fact]
        public void ReturnFirstNonRepeatingCharacter()
        {
            const string word = "aabbbbeitu";
            var firstNonRepeatedChar = word.GroupBy(x => x).First(x => x.Count() == 1).Key;
            Assert.Equal(char.Parse("e"), firstNonRepeatedChar);
        }
    }
}
