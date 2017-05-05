namespace ProjectManager.Common.CustomExceptions
{
    using System;

    public class UserValidationException : ApplicationException
    {
        public UserValidationException(string msg)
            : base(" - Error: " + msg)
        {
        }
    }
}
