using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class FailedMatch : IMatch
    {
        private readonly string remainingText;

        public FailedMatch(string remainingText)
        {
            this.remainingText = remainingText;
            this.Success();
        }
        public string RemainingText() => this.remainingText;
       

        public bool Success() => false;
    }
}
