using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class SuccessMatch : IMatch
    {
        private readonly string remainingText;

        public SuccessMatch(string remainingText)
        {
            this.remainingText = remainingText;
        }

        public string RemainingText()
        {
            return this.remainingText;
        }

        public bool Success() => true;
    }
}
