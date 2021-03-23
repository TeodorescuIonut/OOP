using System;
using Xunit;

namespace JSONclasses
{
    public class NumberFacts
    {
        [Fact]
        public void CanStartWithZero()
        {
            var number = new Number();
            const string text = "01";
            Assert.Equal("1", number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            var number = new Number();
            const string text = "7121";
            Assert.Equal("", number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Fact]
        public void IsNotNull()
        {
            var number = new Number();
            const string text = null;
            Assert.Null(number.Match(text).RemainingText());
            Assert.False(number.Match(text).Success());
        }

        [Fact]
        public void CanBeFractional()
        {
            var number = new Number();
            const string text = "12.34";
            Assert.Equal("", number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            var number = new Number();
            const string text = "0.000001";
            Assert.Equal("", number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            var number = new Number();
            const string text = "12.";
            Assert.Equal(".", number.Match(text).RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            var number = new Number();
            const string text = "12.23.32";
            Assert.Equal(".32", number.Match(text).RemainingText());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            var number = new Number();
            const string text = "12.3x";
            Assert.Equal("x", number.Match(text).RemainingText());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            var number = new Number();
            const string text = "12e3";
            Assert.Equal("", number.Match(text).RemainingText());
            Assert.True(number.Match(text).Success());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            var number = new Number();
            const string text = "12e+3";
            Assert.Equal("", number.Match(text).RemainingText());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            var number = new Number();
            const string text = "12.34E3";
            Assert.Equal("", number.Match(text).RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            var number = new Number();
            const string text = "22e323e33";
            Assert.Equal("e33", number.Match(text).RemainingText());
        }
    }
}
