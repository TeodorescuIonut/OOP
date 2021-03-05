using System;
using Xunit;

namespace JSONclasses
{
    public class ListFacts
    {
        [Fact]
        public void AddCharsContainedInStringShouldReturnRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            const string text = "1,2,3";
            Assert.Equal("", a.Match(text).RemainingText());
            Assert.True(a.Match(text).Success());
        }

        [Fact]
        public void AddEmptyStringShouldReturnEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            const string text = "";
            Assert.Equal("", a.Match(text).RemainingText());
            Assert.True(a.Match(text).Success());
        }

        [Fact]
        public void AddNullShouldReturnNull()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            const string text = null;
            Assert.Null(a.Match(text).RemainingText());
            Assert.True(a.Match(text).Success());
        }

        [Fact]
        public void AddMoreElementsAndSeparatorsShouldReturnRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            const string text = "1; 22;\n 333 \t; 22";
            Assert.Equal("", list.Match(text).RemainingText());
            Assert.True(list.Match(text).Success());
        }
    }
}
