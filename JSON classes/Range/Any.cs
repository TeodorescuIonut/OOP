using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Any : IPattern
    {
        private readonly string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && accepted.Contains(text[0]) ?
              new SuccessMatch(text[1..]) :
              (IMatch)new FailedMatch(text);
        }
    }
}
