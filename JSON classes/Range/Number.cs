using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            // aici construiește patternul pentru
            // un JSON number

            var integer = new Sequence(new Optional(new Any("-")), new Choice(new Character('0'),new OneOrMore(new Range('1', '9'))));
            var fraction = new Optional(new Sequence(new Character('.'), new OneOrMore(new Range('0', '9'))));
            var exponent = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), new OneOrMore(new Range('0', '9'))));
            pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
