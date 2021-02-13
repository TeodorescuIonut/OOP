using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Match : IMatch
    {
        private readonly string remainingText;
        private readonly bool success;

        public Match(string remainingText, bool success)
        {
            this.remainingText = remainingText;
            this.success = success;
        }


        public string RemainingText()
        {
            return this.remainingText;
        }

        public bool Success()
        {
            return this.success;
        }
    }
}
