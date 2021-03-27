using System;
using Xunit;

namespace JSONclasses
{
    public class OptionalFacts
    {
        [Fact]
        public void AddCharsContainedInStringShouldReturnRemainingText()
        {
            var a = new Optional(new Character('a'));
            const string text = "aabc";
            Assert.Equal("abc", a.Match(text).RemainingText());
        }

        [Fact]
        public void AddEmptyStringShouldReturnEmpty()
        {
            var a = new Optional(new Character('a'));
            const string text = "";
            Assert.Equal("", a.Match(text).RemainingText());
        }

        [Fact]
        public void AddNullStringShouldReturnNull()
        {
            var a = new Optional(new Character('a'));
            const string text = null;
            Assert.Null(a.Match(text).RemainingText());
        }

        [Fact]
        public void AddSignInStringShouldReturnRemainingText()
        {
            var a = new Optional(new Character('-'));
            const string text = "-123";
            Assert.Equal("123", a.Match(text).RemainingText());
        }
    }
}
