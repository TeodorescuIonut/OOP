using System;
using System.Linq;
using Xunit;

namespace StringTest
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnNoOfVocalsAndConsonants()
        {
            const string word = "aabbbbeitu";
            char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
            var vowelsNumber = word.ToCharArray().Where(x => vowels.Contains(x));
            var consonantsNumber = word.ToCharArray().Where(x => !vowels.Contains(x));
            Assert.Equal(5, vowelsNumber.Count());
            Assert.Equal(5, consonantsNumber.Count());
        }

        [Fact]
        public void ReturnFirstNonRepeatingCharacter()
        {
            const string word = "aabbbbeitu";
            var nonRepeatingChars = word.GroupBy(x => x).Where(x => x.Count() == 1);
            char firstNonRepeatedChar = nonRepeatingChars.First().Key;
            Assert.Equal(char.Parse("e"), firstNonRepeatedChar);
        }
    }
}
