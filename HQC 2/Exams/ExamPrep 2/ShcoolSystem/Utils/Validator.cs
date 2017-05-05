namespace SchoolSystem.Utils
{
    using Contracts;
    using System;
    using System.Text.RegularExpressions;

    public class Validator : IValidator
    {
        public void ValidateBiggerThan(int number, int maxNumber, string message)
        {
            if (number > maxNumber)
            {
                throw new ArgumentException(string.Format(message, maxNumber));
            }
        }

        public void ValidateLessThan(int number, int minNumber, string message)
        {
            if (number < minNumber)
            {
                throw new ArgumentException(message);
            }
        }

        public void ValidateNullObject(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(string.Format(message, obj));
            }
        }

        public void ValidateNumberRange(int number, int minNumber, int maxNumber, string message)
        {
            if (number < minNumber || number > maxNumber)
            {
                throw new ArgumentException(string.Format(message, minNumber, maxNumber));
            }
        }

        public void ValidateNumberRange(float number, int minNumber, int maxNumber, string message)
        {
            if (number < minNumber || number > maxNumber)
            {
                throw new ArgumentException(string.Format(message, minNumber, maxNumber));
            }
        }        

        public void ValidateStringCharacters(string text, string regexPattern, string message)
        {
            var regex = new Regex(regexPattern);

            if (!regex.IsMatch(text))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
