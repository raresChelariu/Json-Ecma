namespace Json.Basics
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var indexOfDot = input.IndexOf('.');
            var indexOfExponent = input.IndexOfAny(new[] { 'e', 'E' });

            return IsInteger(Integer(input, indexOfDot, indexOfExponent))
                   && IsFraction(Fraction(input, indexOfDot, indexOfExponent))
                   && IsExponent(Exponent(input, indexOfExponent));
        }

        private static string Integer(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot != -1)
            {
                return input[..indexOfDot];
            }

            if (indexOfExponent != -1)
            {
                return input[..indexOfExponent];
            }

            return input;
        }

        private static bool IsInteger(string input)
        {
            if (input.StartsWith('-'))
            {
                input = input[1..];
            }

            if (input.StartsWith('0') && input.Length > 1)
            {
                return false;
            }

            return IsDigits(input);
        }

        private static string Fraction(string input, int indexOfDot, int indexOfExponent)
        {
            if (indexOfDot == -1)
            {
                return string.Empty;
            }

            if (indexOfExponent != -1)
            {
                return input[indexOfDot..indexOfExponent];
            }

            return input[indexOfDot..];
        }

        private static bool IsFraction(string input)
        {
            return string.IsNullOrEmpty(input) || IsDigits(input[1..]);
        }

        private static string Exponent(string input, int indexOfExponent)
        {
            return (indexOfExponent != -1) ? input[indexOfExponent..] : "";
        }

        private static bool IsExponent(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            input = input[1..];

            if (input.StartsWith('-') || input.StartsWith('+'))
            {
                input = input[1..];
            }

            return IsDigits(input);
        }

        private static bool IsDigits(string input)
        {
            foreach (var ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}