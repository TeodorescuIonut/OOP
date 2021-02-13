using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Choice: IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
    }

        IMatch IPattern.Match(string text)
        {
            IMatch myMatch = new Match(text, false);
            IMatch initialMatch = new Match(text, false);
            for (int i = 0; i < patterns.Length; i++)
            {
                myMatch = patterns[i].Match(text);
                if (myMatch.Success())
                {
                    return myMatch;

                }

                text = myMatch.RemainingText();

            }
            return myMatch;
        }
    }
}
