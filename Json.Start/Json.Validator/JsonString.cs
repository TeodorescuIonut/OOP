using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && ContainsQuotes(input) && ContainsCharacters(input);
        }

        private static bool ContainsQuotes(string input)
        {
            return IsDoubleQuoted(input) && ContainsStartAndEndQuotes(input);
        }

        private static bool ContainsCharacters(string input)
        {
            return !ContainsControlCharacters(input) || ContainLargeUnicodeCharacters(input);
        }

        private static bool ContainLargeUnicodeCharacters(string input)
        {
            const int maxValue = 255;
            foreach (char c in input)
            {
                if (Convert.ToInt32(c) > maxValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsControlCharacters(string input)
        {
            const int maxValue = 32;
            foreach (char c in input)
            {
                if (Convert.ToInt32(c) <= maxValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsStartAndEndQuotes(string input)
        {
            const int length = 2;
            return input.Length >= length;
        }

        private static bool IsDoubleQuoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"');
        }

        private static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
