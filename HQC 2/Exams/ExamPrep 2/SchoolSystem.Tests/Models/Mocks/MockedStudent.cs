namespace SchoolSystem.Tests.Models.Mocks
{
    using Contracts;
    using Enums;
    using SchoolSystem.Models;

    public class MockedStudent : Student
    {
        public MockedStudent(string firstName, string lastName, Grade grade, IValidator validator = null)
            : base(firstName, lastName, grade, validator)
        {
        }

        public IValidator GetValidator()
        {
            return this.Validator;
        }
    }
}
