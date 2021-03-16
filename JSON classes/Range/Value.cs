using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
     class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var stringText = new String();
            var number = new Number();
            var value = new Choice(
                stringText,
                number,
                new Text("true"),
                new Text("false"),
                new Text("null")
            );
            var ws = new Choice(
                     new Character(Convert.ToChar(Convert.ToUInt32("0020", 16))),
                     new Character(Convert.ToChar(Convert.ToUInt32("000A", 16))),
                     new Character(Convert.ToChar(Convert.ToUInt32("000D", 16))),
                     new Character(Convert.ToChar(Convert.ToUInt32("0009", 16))));
            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));
            var member = new Sequence(ws, stringText, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var array = new Sequence(
                new Character('['),
                new Optional(ws), 
                elements, 
                new Character('}'));
            var objects = new Sequence(
                new Character('{'),
                new Optional(ws),
                members,
                new Character(']'));
            value.Add(array);
            value.Add(objects);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
