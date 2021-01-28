using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfNullorEmpty(input)
                && CheckAllowedChars(input)
                && CheckIfHasOneOrMoreDigits(input)
                && CheckTypeOfNumber(input);
        }

        private static bool CheckIfHasOneOrMoreDigits(string input)
        {
            return CanHaveOneDigit(input) || CanHaveMultipleDigits(input);
        }

        private static bool CheckTypeOfNumber(string input)
        {
                return CanBeAFraction(input) || CanBeAWholeNumber(input) || CanBeExponent(input);
        }

        private static bool CanBeExponent(string input)
        {
            if (ContainsTwoExponent(input)
                || CheckIfExponentIsComplete(input)
                || CanHaveExponentAfterFraction(input))
            {
                return false;
            }

            return ContainsPositiveOrNegativeExponent(input) || ContainsExponent(input) || ContainsExponentAndFraction(input);
        }

        private static bool ContainsExponentAndFraction(string input)
        {
            return ContainsExponent(input) && input.Contains('.');
        }

        private static bool ContainsExponent(string input)
        {
            return input.Contains('e') || input.Contains('E');
        }

        private static bool CanHaveExponentAfterFraction(string input)
        {
            if (input.Contains('e'))
            {
                return input.IndexOf('e') < input.IndexOf('.');
            }

            return !input.Contains('E') || input.IndexOf('E') < input.IndexOf('.');
        }

        private static bool CheckIfExponentIsComplete(string input)
        {
            return input.EndsWith('e')
                || input.EndsWith('-')
                || input.EndsWith('+')
                || input.EndsWith('E');
        }

        private static bool ContainsTwoExponent(string input)
        {
            int exponentCount = 0;
            foreach (char c in input)
            {
                if (c == 'e' || c == 'E')
                {
                    exponentCount++;
                }
            }

            return exponentCount > 1;
        }

        private static bool ContainsPositiveOrNegativeExponent(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E')
                {
                    return input[i + 1] == '+' || input[i + 1] == '-' || char.IsDigit(input[i + 1]);
                }
            }

            return false;
        }

        private static bool CanBeAWholeNumber(string input)
        {
            if (CanHaveLeadingZero(input)
                || input.Contains('.')
                || ContainsExponent(input))
            {
                return false;
            }

            return CanBeNegative(input) || CanHaveMultipleDigits(input) || CanHaveOneDigit(input);
        }

        private static bool CanBeNegative(string input)
        {
            return input.StartsWith('-');
        }

        private static bool CanBeAFraction(string input)
        {
            if (!input.Contains('.')
                || FractionEndsWithDot(input)
                || FractionsContainsTwoParts(input)
                || ContainsExponent(input))
            {
                return false;
            }

            return HaveLeadingZeroAsAFraction(input) || !HaveLeadingZeroAsAFraction(input) || CanBeNegative(input);
        }

        private static bool FractionsContainsTwoParts(string input)
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

        private static bool CanHaveMultipleDigits(string input)
        {
            return !CanHaveOneDigit(input);
        }

        private static bool CanHaveOneDigit(string input)
        {
            const int twoDigit = 2;
            return input.Length < twoDigit && CheckIfHasOnlyDigits(input);
        }

        private static bool CheckIfHasOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HaveLeadingZeroAsAFraction(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '0' && input[i + 1] == '.')
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

        private static bool CheckAllowedChars(string input)
        {
            const string allowedChars = "-+.eE";
            foreach (char c in input)
            {
                if (!char.IsDigit(c) && !allowedChars.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
