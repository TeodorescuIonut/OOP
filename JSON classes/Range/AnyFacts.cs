using System;
using Xunit;

namespace JSONclasses
{
    public class AnyFacts
    {
        [Fact]
        public void AddCharsAcceptedInStringShouldReturnTrue()
        {
            var e = new Any("eE");
            const string text = "Ea";
            Assert.True(e.Match(text).Success());
            var sign = new Any("-+");
            const string signtext = "+3";
            Assert.True(sign.Match(signtext).Success());
        }

        [Fact]
        public void AddCharsNotAcceptedInStringShouldReturnFalse()
        {
            var e = new Any("eE");
            const string text = "a";
            Assert.False(e.Match(text).Success());
            var sign = new Any("-+");
            const string signtext = "2";
            Assert.False(sign.Match(signtext).Success());
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var e = new Any("eE");
            const string text = "";
            Assert.False(e.Match(text).Success());
            var sign = new Any("-+");
            const string signtext = "";
            Assert.False(sign.Match(signtext).Success());
        }

        [Fact]
        public void AddNullStringShouldReturnFalse()
        {
            var e = new Any("eE");
            const string text = null;
            Assert.False(e.Match(text).Success());
            var sign = new Any("-+");
            const string signtext = null;
            Assert.False(sign.Match(signtext).Success());
        }
    }
}
