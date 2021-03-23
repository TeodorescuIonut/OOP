using System;
using Xunit;

namespace JSONclasses
    {
        public class RangeFacts
        {
            [Fact]
            public void AddCharsInRangShouldReturnTrue()
            {
                var digit = new Range('a', 'f');
                const string text = "abf";
                Assert.True(digit.Match(text).Success());
            }

            [Fact]
            public void AddEmptyStringShoudlReturnFalse()
            {
                var digit = new Range('a', 'f');
                const string text = " ";
                Assert.False(digit.Match(text).Success());
            }

            [Fact]
            public void AddNullShoudlReturnFalse()
            {
                var digit = new Range('a', 'f');
                const string text = null;
                Assert.False(digit.Match(text).Success());
            }
        }
    }