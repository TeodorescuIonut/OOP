using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    class Range
    {
        private readonly char start;
        private readonly char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
    }

        public bool Match(string text)
        {
            bool result = true;
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
                
            foreach(char c in text)
            {
                if(c < this.start || c > this.end)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
