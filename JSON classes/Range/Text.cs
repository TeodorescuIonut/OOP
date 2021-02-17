using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    class Text : IPattern
    {
        private readonly string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }
        public IMatch Match(string text)
        {
            IMatch match = new FailedMatch(text);
            string remainedText = text;
            if (string.IsNullOrEmpty(text))
            {
                return match;
            }

            foreach (char c in text)
            {
                if (!prefix.Contains(c))
                {
                    return match;
                }
                remainedText = remainedText.Substring(1);
                match = new SuccessMatch(remainedText);

            }
            return match;
        }
    }
}
