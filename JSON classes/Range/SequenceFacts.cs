using System;
using Xunit;

namespace JSONclasses
{
    public class SequenceFacts
    {
        [Fact]
        public void AddCharsInRangShouldReturnTrue()
        {
            var ab = new Sequence
                (
                    new Character('a'),
                    new Character('b')
                );
            var abc = new Sequence(
                ab,
            new Character('c')
            );
            Match testMatch = new Match("d", true);
            Assert.Equal(testMatch.RemainingText(), abc.Match("abcd").RemainingText());
            Assert.Equal(testMatch.Success(), abc.Match("abcd").Success());
        }

        [Fact]
        public void AddCharsNotInRangeShouldReturnFalse()
        {
            var ab = new Sequence
                (
                    new Character('a'),
                    new Character('b')
                );
            var abc = new Sequence(
            ab,
            new Character('c')
            );
            Match testMatch = new Match("abx", false);
            Assert.Equal(testMatch.RemainingText(), abc.Match("abx").RemainingText());
            Assert.Equal(testMatch.Success(), abc.Match("abx").Success());
        }

        [Fact]
        public void AddNullShouldReturnFalse()
        {
            var ab = new Sequence
                (
                    new Character('a'),
                    new Character('b')
                );
            var abc = new Sequence(
            ab,
            new Character('c')
            );
            Match testMatch = new Match(null, false);
            Assert.Equal(testMatch.RemainingText(), abc.Match(null).RemainingText());
            Assert.Equal(testMatch.Success(), abc.Match(null).Success());
        }

        [Fact]
        public void AddEmptyStringShouldReturnFalse()
        {
            var ab = new Sequence
                (
                    new Character('a'),
                    new Character('b')
                );
            var abc = new Sequence(
            ab,
            new Character('c')
            );
            Match testMatch = new Match("", false);
            Assert.Equal(testMatch.RemainingText(), abc.Match("").RemainingText());
            Assert.Equal(testMatch.Success(), abc.Match("").Success());
        }

        [Fact]
        public void AddStringWithLeadingCharacterAndOnlyDigitsShouldReturnTrue()
        {
            var hex = new Choice
                (
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Match testMatch = new Match("", true);
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("u1234").RemainingText());
            Assert.Equal(testMatch.Success(), hexSeq.Match("u1234").Success());
        }

        [Fact]
        public void AddLeadingCharacterWithOnlyCharactersShouldReturnRemainingText()
        {
            var hex = new Choice
                (
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Match testMatch = new Match("ef", true);
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("uabcdef").RemainingText());
            Assert.Equal(testMatch.Success(), hexSeq.Match("uabcdef").Success());
        }

        [Fact]
        public void AddLeadingCharacterWithOnlyCharactersShouldReturnRemainingTextAndSpace()
        {
            var hex = new Choice
                (
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Match testMatch = new Match(" ab", true);
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("uB005 ab").RemainingText());
            Assert.Equal(testMatch.Success(), hexSeq.Match("uB005 ab").Success());
        }

        [Fact]
        public void AddNoLeadingCharacterShouldReturnRemainingText()
        {
            var hex = new Choice
                (
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F')
                );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            Match testMatch = new Match("abc", false);
            Assert.Equal(testMatch.RemainingText(), hexSeq.Match("abc").RemainingText());
            Assert.Equal(testMatch.Success(), hexSeq.Match("abc").Success());
        }
    }
}
