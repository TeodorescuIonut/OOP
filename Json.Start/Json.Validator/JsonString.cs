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
            if (ContainsControlCharacters(input)
                || EndsWithReverseSolidus(input)
                || EndsWithUnfinishedHexNumber(input))
            {
                return false;
            }

            if (ContainsEscapedSolidus(input))
            {
                return ContainsEscapedSpecialCharacters(input);
            }

            return ContainsLargeUnicodeCharacters(input);
        }

        private static bool ContainsEscapedSolidus(string input)
        {
            return input.Contains('\\');
        }

        private static bool EndsWithUnfinishedHexNumber(string input)
            {
            if (!input.Contains("\\u"))
            {
                return false;
            }

            int lastPos = input.LastIndexOf('"');
            int lastPosOfU = input.LastIndexOf("\\u");
            const int maxHexNo = 5;
            return lastPos - lastPosOfU <= maxHexNo;
        }

        private static bool EndsWithReverseSolidus(string input)
        {
            const int lastPos = 2;
            return input[^lastPos] == '\\';
        }

        private static bool ContainsEscapedSpecialCharacters(string input)
        {
            const string specialChar = "\\b/frntu\"";
            for (int i = 0; i < specialChar.Length; i++)
            {
               for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '\\' && input[j + 1] == specialChar[i])
                    {
                        return true;
                    }
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

        private static bool ContainsLargeUnicodeCharacters(string input)
        {
           return !ContainsControlCharacters(input) || !input.Contains('\\') || !input.Contains('"');
        }

        private static bool ContainsControlCharacters(string input)
        {
            const int maxValue = 32;
            foreach (char c in input)
            {
                if (c < maxValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsStartAndEndQuotes(string input)
        {
            const int length = 2;
            return input.Length >= length && IsDoubleQuoted(input);
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
