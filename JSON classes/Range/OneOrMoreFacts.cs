using System;
using Xunit;

namespace JSONclasses
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void AddCharsContainedInStringShouldReturnRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));
            const string text = "123";
            Assert.Equal("", a.Match(text).RemainingText());
            Assert.True(a.Match(text).Success());
        }

        [Fact]
        public void AddCharsNotContainedInStringShouldReturnRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));
            const string text = "bc";
            Assert.Equal("bc", a.Match(text).RemainingText());
            Assert.False(a.Match(text).Success());
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var a = new OneOrMore(new Range('0', '9'));
            const string text = "";
            Assert.Equal("", a.Match(text).RemainingText());
            Assert.False(a.Match(text).Success());
        }

        [Fact]
        public void AddNullShouldReturnNull()
        {
            var a = new OneOrMore(new Range('0', '9'));
            const string text = null;
            Assert.Null(a.Match(text).RemainingText());
        }
    }
}
