namespace SchoolSystem.Tests.Models.Mocks
{
    using Contracts;
    using Enums;
    using SchoolSystem.Models;

    public class MockedTeacher : Teacher
    {
        public MockedTeacher(string firstName, string lastName, Subjct subject, IValidator validator = null) 
            : base(firstName, lastName, subject, validator)
        {
        }

        public IValidator GetValidator()
        {
            return this.Validator;
        }
    }
}
