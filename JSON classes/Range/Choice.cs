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
            foreach(var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    return pattern.Match(text);

                }

                text = pattern.Match(text).RemainingText();

            }
            return new FailedMatch(text, false);
        }
    }
}
