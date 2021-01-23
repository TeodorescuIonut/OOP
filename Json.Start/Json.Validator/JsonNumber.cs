using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfNullorEmpty(input)
                && CheckIfIsADigit(input)
                && !CanHaveLeadingZero(input);
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
                if (!char.IsDigit(c) && c != '.' && c != '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
