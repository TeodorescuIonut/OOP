using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var integer = new Sequence(new Optional(new Any("-")), new Choice(new Character('0'), digits));
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            var exponent = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));
            pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
