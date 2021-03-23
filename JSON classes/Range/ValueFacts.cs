using System;
using Xunit;

namespace JSONclasses
{
    public class ValueFacts
    {
        [Fact]
        public void CheckIfString()
        {
            var value = new Value();
            string text = Quoted("abc");
            Assert.Equal("", value.Match(text).RemainingText());
            Assert.True(value.Match(text).Success());
        }

        [Fact]
        public void CheckIfNumber()
        {
            var value = new Value();
            const string text = "7121";
            Assert.Equal("", value.Match(text).RemainingText());
            Assert.True(value.Match(text).Success());
        }

        [Fact]
        public void CheckIfNull()
        {
            var value = new Value();
            const string text = null;
            Assert.Null(value.Match(text).RemainingText());
            Assert.False(value.Match(text).Success());
        }

        [Fact]
        public void CheckIfFalse()
        {
            var value = new Value();
            const string text = "false";
            Assert.Equal("", value.Match(text).RemainingText());
            Assert.True(value.Match(text).Success());
        }

        public string Quoted(string text)
        => $"\"{text}\"";
    }
}
