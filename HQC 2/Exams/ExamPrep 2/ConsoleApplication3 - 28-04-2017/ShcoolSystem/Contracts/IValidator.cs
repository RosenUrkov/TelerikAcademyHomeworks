namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Represents validator abstraction with various methods
    /// </summary>
    public interface IValidator
    {
        void ValidateNumberRange(int number, int minNumber, int maxNumber, string message);

        void ValidateNumberRange(float number, int minNumber, int maxNumber, string message);

        void ValidateLessThan(int number, int minNumber, string message);

        void ValidateBiggerThan(int number, int maxNumber, string message);

        void ValidateStringCharacters(string text, string regexPattern, string message);

        void ValidateNullObject(object obj, string message);
    }
}
