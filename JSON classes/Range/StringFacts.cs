using System;
using Xunit;

namespace JSONclasses
{
    public class StringFacts
    {

        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            var textInput = new String();
            string text = Quoted("abc");
            Assert.Equal("", textInput.Match(text).RemainingText());
            Assert.True(textInput.Match(text).Success());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            var textInput = new String();
            string text = Quoted(string.Empty);
            Assert.Equal("", textInput.Match(text).RemainingText());
            Assert.True(textInput.Match(text).Success());
        }

        [Fact]
        public void IsNotNull()
        {
            var textInput = new String();
            const string text = null;
            Assert.Null(textInput.Match(text).RemainingText());
            Assert.False(textInput.Match(text).Success());
        }


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            var textInput = new String();
            string text = Quoted("a\nb\rc");
            Assert.False(textInput.Match(text).Success());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var textInput = new String();
            string text = Quoted("⛅⚾");
            Assert.True(textInput.Match(text).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var textInput = new String();
            string text = Quoted(@"a \\ b");
            Assert.True(textInput.Match(text).Success());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var textInput = new String();
            string text = Quoted(@"a \u26Be b");
            Assert.True(textInput.Match(text).Success());
        }
        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            var textInput = new String();
            string text = Quoted(@"a\u");
            Assert.False(textInput.Match(text).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
