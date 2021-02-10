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


        public bool Match(string text)
        {
            bool result = false;
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text))
                    result = true;
            }

            return result;
        }
    }
}
