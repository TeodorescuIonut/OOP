using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var digit = new Range('0', '9');
            var quotationMark = new Character('"');
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(
                new Character('u'), 
                new Sequence(hex, hex, hex, hex));
            var escaped = new Sequence(
                new Character('\\'),
                new Choice((new Any("\\/bnrft")),
                (hexSeq)));
            var character = new Choice(
                new Range(' ', '!'), 
                new Range('#','['), 
                new Range(']', 
                char.MaxValue), 
                escaped);
            var characters = new Optional(
                new Many(character));        
            pattern = new Sequence(quotationMark,characters, quotationMark);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
