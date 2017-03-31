namespace Methods
{
    using System;
    using System.Text.RegularExpressions;

    public static class Validator
    {
        public const string NAME_PATTERN = @"^[A-z][a-z]+$";
        public const string DATE_PATTERN = @"^[0-9]{2}.[0-9]{2}.[0-9]{4}$";

        public static void ValidateString(string pattern, string targetText, string message = "Incorrect input string!")
        {
            var regex = new Regex(pattern);

            if (targetText == null || !regex.IsMatch(targetText))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
