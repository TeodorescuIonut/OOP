using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Character: IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text[0] == pattern;
        }

        IMatch IPattern.Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
