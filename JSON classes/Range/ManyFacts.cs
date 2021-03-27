using System;
using Xunit;

namespace JSONclasses
{
    public class ManyFacts
    {
        [Fact]
        public void AddCharsContainedInStringShouldReturnRemainingText()
        {
            var a = new Many(new Character('a'));
            const string text = "aaaabc";
            Assert.Equal("bc", a.Match(text).RemainingText());
        }

        [Fact]
        public void AddCharsNotContainedInStringShouldReturnRemainingText()
        {
            var a = new Many(new Character('a'));
            const string text = "bc";
            Assert.Equal("bc", a.Match(text).RemainingText());
        }

        [Fact]
        public void AddEmptyStringShouldReturnRemainingText()
        {
            var a = new Many(new Character('a'));
            const string text = "";
            Assert.Equal("", a.Match(text).RemainingText());
        }

        [Fact]
        public void AddNullStringShouldReturnNull()
        {
            var a = new Many(new Character('a'));
            const string text = null;
            Assert.Null(a.Match(text).RemainingText());
        }

        [Fact]
        public void AddCharsinRangeShouldReturnTrue()
        {
            var digits = new Many(new Range('0', '9'));
            const string text = "12345ab123";
            Assert.Equal("ab123", digits.Match(text).RemainingText());
        }

        [Fact]
        public void AddCharsNotInRangeShouldReturnFalse()
        {
            var digits = new Many(new Range('0', '9'));
            const string text = "ab";
            Assert.Equal("ab", digits.Match(text).RemainingText());
        }
    }
}
