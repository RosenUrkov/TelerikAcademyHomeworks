namespace StrawberryAdventure.Utils
{
    using System;
    public static class Validator
    {
        public static void ValidateString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new InvalidOperationException("String cannon be null or empty.");
            }
        }

        public static void ValidateGameIntValue(int number)
        {
            if (number < Constants.MinIntGameValue || number > Constants.MaxIntGameValue)
            {
                throw new InvalidGameValueException($"Value must be between {Constants.MinIntGameValue} and {Constants.MaxIntGameValue}.");
            }
        }

        public static void ValidateGameObjectInstance(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Game instance cannon be null.");
            }
        }

        public static void ValidateNumber(int number,int minValue,int maxValue)
        {
            if (number < minValue || number > maxValue)
            {
                throw new InvalidGameValueException($"Value must be between {minValue} and {maxValue}.");
            }
        }
    }
}
