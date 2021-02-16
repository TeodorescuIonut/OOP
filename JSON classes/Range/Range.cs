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
            return (!string.IsNullOrEmpty(text) && text[0] >= this.start && text[0] <= this.end)
                           ? new SuccessMatch(text[1..])
                           : (IMatch)new FailedMatch(text);

        }

    }
}
