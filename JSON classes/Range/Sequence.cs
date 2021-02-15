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
            IMatch myMatch = new Match(text, false);
            IMatch failMatch = new FailedMatch(text, false);
            foreach (var pattern in patterns)
            {
                myMatch = pattern.Match(text);
                if (!pattern.Match(text).Success())
                {
                    
                    return failMatch;
                }

                    text = myMatch.RemainingText();
                
            }
            return myMatch;
        }
    }
}
