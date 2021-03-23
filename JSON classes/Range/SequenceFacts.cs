using System;
using Xunit;

namespace JSONclasses
{
    public class SequenceFacts
    {
        [Fact]
        public void AddCharsInRangShouldReturnTrue()
        {
            var ab = new Sequence(
                    new Character('a'),
                    new Character('b'));
            var abc = new Sequence(
                ab,
                new Character('c'));
            SuccessMatch testMatch = new SuccessMatch("d");
            Assert.Equal(testMatch.RemainingText(), abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void AddCharsNotInRangeShouldReturnFalse()
        {
            var ab = new Sequence(
                    new Character('a'),
                    new Character('b'));
            var abc = new Sequence(
            ab,
            new Character('c'));
            FailedMatch testMatch = new FailedMatch("abx");
            Assert.Equal(testMatch.RemainingText(), abc.Match("abx").RemainingText());
        }

        [Fact]
        public void AddNullShouldReturnFalse()
        {
            var ab = new Sequence(
                    new Character('a'),
                    new Character('b'));
            var abc = new Sequence(
            ab,
            new Character('c'));
            FailedMatch testMatch = new FailedMatch(null);
            Assert.Equal(testMatch.RemainingText(), abc.Match(null).RemainingText());
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var ab = new Sequence(
                    new Character('a'),
                    new Character('b'));
            var abc = new Sequence(
            ab,
            new Character('c'));
            FailedMatch testMatch = new FailedMatch("");
            Assert.Equal(testMatch.RemainingText(), abc.Match("").RemainingText());
        }

        [Fact]
        public void AddStringWithLeadingCharacterAndOnlyDigitsShouldReturnTrue()
        {
            var hex = new Choice(
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F'));

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            SuccessMatch testMatch = new SuccessMatch("");
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("u1234").RemainingText());
        }

        [Fact]
        public void AddLeadingCharacterWithOnlyCharactersShouldReturnRemainingText()
        {
            var hex = new Choice(
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F'));

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            SuccessMatch testMatch = new SuccessMatch("ef");
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("uabcdef").RemainingText());
        }

        [Fact]
        public void AddLeadingCharacterWithOnlyCharactersShouldReturnRemainingTextAndSpace()
        {
            var hex = new Choice(
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F'));

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            SuccessMatch testMatch = new SuccessMatch(" ab");
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("uB005 ab").RemainingText());
        }

        [Fact]
        public void AddNoLeadingCharacterShouldReturnRemainingText()
        {
            var hex = new Choice(
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F'));

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex));
            FailedMatch testMatch = new FailedMatch("abc");
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("abc").RemainingText());
        }
    }
}
