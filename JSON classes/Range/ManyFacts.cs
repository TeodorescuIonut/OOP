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
    }
}
