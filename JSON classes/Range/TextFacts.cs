using System;
using Xunit;

namespace JSONclasses
{
    public class TextFacts
    {
        [Fact]
        public void AddCharsContainedInStringShouldReturnRemainingText()
        {
            var prefix = new Text("true");
            const string text = "true";
            Assert.Equal("", prefix.Match(text).RemainingText());
        }
        [Fact]
        public void AddCharsAcceptedInStringShouldReturnRemainingText()
        {
            var prefix = new Text("true");
            const string text = "trueX";
            Assert.Equal("X", prefix.Match(text).RemainingText());
        }

        [Fact]
        public void AddEmptyStringShouldReturnEmptyText()
        {
            var prefix = new Text("true");
            const string text = "";
            Assert.Equal("", prefix.Match(text).RemainingText());
        }

        [Fact]
        public void AddNullStringShouldReturnNull()
        {
            var prefix = new Text("true");
            const string text = null;
            Assert.Null(prefix.Match(text).RemainingText());
        }

        [Fact]
        public void CheckEmptyStringShouldReturnText()
        {
            var prefix = new Text("");
            const string text = "true";
            Assert.Equal("true", prefix.Match(text).RemainingText());
        }

        [Fact]
        public void CheckNullStringShouldReturNull()
        {
            var prefix = new Text("");
            const string text = null;
            Assert.Null(prefix.Match(text).RemainingText());
        }
    }
}
