using System;
using Xunit;

namespace JSONclasses
{
    public class CharacterFacts
    {
        [Fact]
        public void AddCharsInRangShouldReturnTrue()
        {
            var digit = new Character('0');
            const string text = "01";
            Assert.True(digit.Match(text).Success());
        }

        [Fact]
        public void AddNullShouldRetunrFalse()
        {
            var digit = new Character('0');
            const string text = null;
            Assert.False(digit.Match(text).Success());
        }

        [Fact]
        public void AddEmptyStringShouldRetunrFalse()
        {
            var digit = new Character('0');
            const string text = "";
            Assert.False(digit.Match(text).Success());
        }

    }
}
