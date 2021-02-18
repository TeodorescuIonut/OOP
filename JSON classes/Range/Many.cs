using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
    }

        public IMatch Match(string text)
        {
            IMatch match = new FailedMatch(text);
           foreach(char c in text)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return match;

                }
            }
            return match;
        }
    }
}
