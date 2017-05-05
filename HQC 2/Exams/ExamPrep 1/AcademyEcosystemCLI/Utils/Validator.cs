namespace AcademyEcosystemCLI.Utils
{
    using System;
    using AcademyEcosystemCLI.Contracts;

    public class Validator : IValidator
    {
        public void ValidateNullObject(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
