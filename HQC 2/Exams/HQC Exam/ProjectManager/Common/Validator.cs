namespace ProjectManager.Common
{
    using Contracts;
    using ProjectManager.Common.CustomExceptions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    public class Validator : IValidator
    {
        public void Validate<T>(T obj) where T : class
        {
            var errors = this.GetValidationErrors(obj);
            if (!(errors.Count() == 0))
            {
                throw new UserValidationException(errors.First());
            }
        }

        public IEnumerable<string> GetValidationErrors(object obj)
        {
            Type currentObjectType = obj.GetType();
            PropertyInfo[] pproperties = currentObjectType.GetProperties();
            Type attributeType = typeof(ValidationAttribute);

            foreach (var propertyInfo in pproperties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attributeType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }

        public void ValidateNullObject(object obj, string message)
        {
            if (obj == null)
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateNumberRange(int number, int minRange, int maxRange, string message)
        {
            if (number < minRange || number > maxRange)
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateNumberBiggerThanValue(int number, int maxRange, string message)
        {
            if (number > maxRange)
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateNumberSmallerThanValue(int number, int minRange, string message)
        {
            if (number < minRange)
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateExactIntValue(int number, int expectedNumber, string message)
        {
            if (number != expectedNumber)
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateEmptyParameters(IList<string> parameters, string message)
        {
            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException(message);
            }
        }

        public void ValidateExcludingExactIntValue(int number, int targetumber, string message)
        {
            if (number == targetumber)
            {
                throw new UserValidationException(message);
            }
        }
    }
}