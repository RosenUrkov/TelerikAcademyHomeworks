namespace ProjectManager.Common.Contracts
{
    using System.Collections.Generic;

    public interface IValidator
    {
        void Validate<T>(T obj) where T : class;

        IEnumerable<string> GetValidationErrors(object obj);

        void ValidateNullObject(object obj, string message);

        void ValidateNumberBiggerThanValue(int number, int maxRange, string message);

        void ValidateNumberSmallerThanValue(int number, int minRange, string message);

        void ValidateExactIntValue(int number, int expectedNumber, string message);

        void ValidateExcludingExactIntValue(int number, int targetumber, string message);

        void ValidateNumberRange(int number, int minRange, int maxRange, string message);

        void ValidateEmptyParameters(IList<string> parameters, string message);
    }
}
