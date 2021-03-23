using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
   public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new FailedMatch(text);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (match.Success())
                {
                    return match;
                }
            }

            return match;
        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = pattern;
        }
    }
}
