using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && CheckIfContainsDoubleQuotes(input) && CheckTypeOfCharactersContained(input);
        }

        private static bool CheckIfContainsDoubleQuotes(string input)
        {
            return IsDoubleQuoted(input) && ContainsStartAndEndQuotes(input);
        }

        private static bool CheckTypeOfCharactersContained(string input)
        {
            return !ContainsControlCharacters(input) || ContainLargeUnicodeCharacters(input) || ContainsEscapedCharacters(input);
        }

        private static bool ContainsEscapedCharacters(string input)
        {
            return ContainsEscapedQuotationMark(input) || ContainsEscapedSpecialCharacters(input) || !ContainsEscapedSpecialCharacters(input);
        }

        private static bool ContainsUnrecognizedExcapceCharacters(string input)
        {
            return !input.Contains("\\x");
        }

        private static bool ContainsEscapedSpecialCharacters(string input)
        {
            string[] specialChar = new[] { "\\", "\\b", "\\/", "\\f", "\\r", "\\n", "\\t", "\\u" };
            for (int i = 0; i < specialChar.Length; i++)
            {
                if (input.Contains(specialChar[i]))
                    {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainEscapedReversedSolidus(string input)
        {
            foreach (char c in input)
            {
                if (c == '\u005c')
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
            return !ContainsControlCharacters(input) && !input.Contains("\\") && !input.Contains('"');
        }

        private static bool ContainsControlCharacters(string input)
        {
            const int maxValue = 32;
            foreach (char c in input)
            {
                if (c <= maxValue)
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
