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
                new Range('1', '9'));
            Assert.True(digit.Match("012").Success());
        }

        [Fact]
        public void AddOnlyTwoNumbersShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            Assert.True(digit.Match("12").Success());
        }

        [Fact]
        public void StartingWithLetterShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            Assert.False(digit.Match(" ").Success());
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void AddLeadingZeroShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));

            Assert.True(hex.Match("012").Success());
        }

        [Fact]
        public void AddInRangeLetterShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));

            Assert.True(hex.Match("A9").Success());
        }

        [Fact]
        public void AddNOutOfRangeLetterShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));

            Assert.False(hex.Match("G8").Success());
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));

            Assert.False(hex.Match(" ").Success());
        }

        [Fact]
        public void AddNullShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));

            Assert.False(hex.Match(null).Success());
        }

        [Fact]
        public void AddnewPatternInRangeLetterShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '5'));
            var hex = new Choice(
                digit,
                new Choice(
                new Range('a', 'f'),
                new Range('A', 'F')));
            var newHex = new Range('6', '9');
            hex.Add(newHex);
            Assert.True(hex.Match("A9").Success());
        }
    }
}
