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
            bool success = false;
            string remainingText;
            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, success);
            }

            if (text[0] == this.pattern)
            {
                success = true;
            }
            remainingText = text;
            if (success)
            {
                remainingText = text.Remove(0, 1);
            }
            return new Match(remainingText, success);
        }
    }
}
