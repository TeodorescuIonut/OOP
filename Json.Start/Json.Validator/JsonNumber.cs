using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return CheckIfValidNumber(input);
        }

        private static bool CheckIfValidNumber(string input)
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
