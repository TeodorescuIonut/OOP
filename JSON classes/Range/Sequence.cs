using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Sequence : IPattern
    {
        private readonly IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
    }
        public IMatch Match(string text)
        {
            IMatch match = new FailedMatch(text);
            for (int i = 0; i < patterns.Length; i++)
            {
                match = patterns[i].Match(match.RemainingText());
                if (!match.Success())
                {
                    
                    return new FailedMatch(text);
                }               
            }
            return new SuccessMatch(match.RemainingText());
            
        }
    }
}
