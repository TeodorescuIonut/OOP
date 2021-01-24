using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfNullorEmpty(input)
                && CheckAllowedFormat(input)
                && CheckIfOneOrMoreDigits(input)
                && CheckTypeOfNumber(input);
        }

        private static bool CheckTypeOfNumber(string input)
        {
                return CanBeAFraction(input) || CanBeAWholeNumber(input);
        }

        private static bool CanBeAWholeNumber(string input)
        {
            return !CanHaveLeadingZero(input) && !input.Contains('.');
        }

        private static bool CanBeAFraction(string input)
        {
            if (!input.Contains('.') || FractionEndsWithDot(input) || FractionsContainsTwoDots(input))
            {
                return false;
            }

            return HaveLeadingZeroAsAFraction(input) || !HaveLeadingZeroAsAFraction(input);
        }

        private static bool FractionsContainsTwoDots(string input)
        {
            int dotsCount = 0;
            foreach (char c in input)
            {
                if (c == '.')
                {
                    dotsCount++;
                }
            }

            return dotsCount > 1;
        }

        private static bool FractionEndsWithDot(string input)
        {
            return input.EndsWith('.');
        }

        private static bool CheckIfOneOrMoreDigits(string input)
        {
            return CanHaveOneDigit(input) || CanHaveMultipleDigits(input);
        }

        private static bool CanHaveMultipleDigits(string input)
        {
            return !CanHaveOneDigit(input);
        }

        private static bool CanHaveOneDigit(string input)
        {
            const int twoDigit = 2;
            return input.Length < twoDigit;
        }

        private static bool HaveLeadingZeroAsAFraction(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input.StartsWith('0') && input[i + 1] == '.')
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

        private static bool CheckAllowedFormat(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '-' && c != '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
