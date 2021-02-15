using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class SuccessMatch : IMatch
    {
        private readonly string remainingText;
        private readonly bool success;

        public SuccessMatch(string remainingText, bool success)
        {
            this.remainingText = remainingText;
            this.success = success;
        }
        public string RemainingText()
        {
            return this.remainingText;
        }

        public bool Success() => true;
    }
}
