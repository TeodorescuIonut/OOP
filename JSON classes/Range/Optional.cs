using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
    }

        public IMatch Match(string text)
        {
            IMatch match = new SuccessMatch(text);
            match = pattern.Match(match.RemainingText());
            return new SuccessMatch(match.RemainingText());
        }
    }
}
