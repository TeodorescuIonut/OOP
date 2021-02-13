using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Range: IPattern
    {
        private readonly char start;
        private readonly char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
    }

        IMatch IPattern.Match(string text)
        {
            bool success = false;
            string remainingText = text;
            if (string.IsNullOrEmpty(text))
            {
                return new Match(remainingText, success);
            }
            if (text[0] >= this.start && text[0] <= this.end)
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
