using System;

namespace JSONclasses
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(prefix, StringComparison.CurrentCulture) ?
                new SuccessMatch(text[prefix.Length..]) :
                (IMatch)new FailedMatch(text);
        }
    }
}
