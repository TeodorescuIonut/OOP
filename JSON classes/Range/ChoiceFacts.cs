using System;
using Xunit;

namespace JSONclasses
{
    public class ChoiceFacts
    {
        [Fact]
        public void AddNumbersWithLeadingZeroShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                    );
            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void AddOnlyTwoNumbersShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                    );
            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void StartingWithLetterShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                    );
            Assert.False(digit.Match("a9"));
        }

        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                    );
            Assert.False(digit.Match(" "));
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                    );
            Assert.False(digit.Match(null));
        }

        [Fact]
        public void AddLeadingZeroShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            ));

            Assert.True(hex.Match("012"));
        }
        [Fact]
        public void AddInRangeLetterShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            ));

            Assert.True(hex.Match("A9"));
        }

        [Fact]
        public void AddNOutOfRangeLetterShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            ));

            Assert.False(hex.Match("G8"));
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            ));

            Assert.False(hex.Match(" "));
        }

        [Fact]
        public void AddNullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
                );
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')
            ));

            Assert.False(hex.Match(null));
        }
    }
}
