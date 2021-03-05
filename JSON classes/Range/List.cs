using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Many(new Choice(element,new Sequence(separator, element)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
