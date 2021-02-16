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

        IMatch IPattern.Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == this.pattern
                   ? new SuccessMatch(text[1..])
                   : (IMatch)new FailedMatch(text);
        }
    }
}
