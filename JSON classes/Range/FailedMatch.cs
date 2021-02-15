using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class FailedMatch : IMatch
    {
        private readonly string remainingText;
        private readonly bool success;

        public FailedMatch(string remainingText, bool success)
        {
            this.remainingText = remainingText;
            this.success = success;
        }
        public string RemainingText() => this.remainingText;
       

        public bool Success() => false;
    }
}
