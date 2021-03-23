namespace JSONclasses
{
     public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var stringText = new JSONString();
            var number = new Number();
            var value = new Choice(
                stringText,
                number,
                new Text("true"),
                new Text("false"),
                new Text("null"));
            var ws = new Many(new Any(" \r\n\t"));
            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));
            var member = new Sequence(ws, stringText, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var array = new Sequence(
                new Character('['),
                new Optional(ws),
                elements,
                new Character(']'));
            var objects = new Sequence(
                new Character('{'),
                new Optional(ws),
                members,
                new Character('}'));
            value.Add(array);
            value.Add(objects);
            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
