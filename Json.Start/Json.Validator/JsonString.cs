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

            if (ContainsReverseSolidus(input))
            {
                return ContainsEscapedSpecialCharacters(input);
            }

            return ContainsLargeUnicodeCharacters(input);
        }

        private static bool ContainsReverseSolidus(string input)
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
            const string specialCharacters = "\\b/frntu\"";
            for (int i = 0; i < input.Length; i++)
            {
                    if (input[i] == '\\' && !specialCharacters.Contains(input[i + 1]))
                    {
                        return false;
                    }
                    else if (input[i] == '\\' && input[i + 1] == '\\')
                {
                    return true;
                }
            }

            return true;
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
