using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfNullorEmpty(input)
                && CheckIfIsADigit(input)
                && CanBeNegativeNumber(input)
                && !CanHaveLeadingZero(input);
        }

        private static bool CanBeNegativeNumber(string input)
        {
            foreach (char c in input)
            {
                if (c <= 0 || c > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CanHaveLeadingZero(string input)
        {
            const int twoDigits = 2;
            return input.Length >= twoDigits && input.StartsWith('0');
        }

        private static bool CheckIfNullorEmpty(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        private static bool CheckIfIsADigit(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
