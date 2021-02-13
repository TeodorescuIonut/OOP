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
            IMatch initialMatch = new Match(text, false);
            for (int i = 0; i < patterns.Length; i++)
            {
                myMatch = patterns[i].Match(text);
                if (myMatch.Success())
                {
                    text = myMatch.RemainingText();
                }
                else
                {

                    return initialMatch;
                }
                
            }
            return myMatch;
        }
    }
}
