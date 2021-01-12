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
            return !ContainsControlCharacters(input) || ContainLargeUnicodeCharacters(input) || ContainsEscapedCharacters(input);
        }

        private static bool ContainsEscapedCharacters(string input)
        {
            return ContainsEscapedQuotationMark(input) || ContainEscapedReversedSolidus(input) || ContainEscapedSolidus(input);
        }

        private static bool ContainEscapedSolidus(string input)
        {
            const int value = 47;
            foreach (char c in input)
            {
                if (Convert.ToInt32(c) == value)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainEscapedReversedSolidus(string input)
        {
            const int value = 92;
            foreach (char c in input)
            {
                if (Convert.ToInt32(c) == value)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsEscapedQuotationMark(string input)
        {
            int count = 0;
            const int maxCount = 2;
            foreach (char c in input)
            {
                if (c == '"')
                {
                    count++;
                }
            }

            return count > maxCount;
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
