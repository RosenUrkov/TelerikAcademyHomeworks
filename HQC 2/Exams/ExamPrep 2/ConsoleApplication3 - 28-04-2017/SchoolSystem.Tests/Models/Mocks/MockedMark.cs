namespace SchoolSystem.Tests.Models.Mocks
{
    using Contracts;
    using Enums;
    using SchoolSystem.Models;

    public class MockedMark : Mark
    {
        public MockedMark(Subjct subject, float value, IValidator validator = null) 
            : base(subject, value, validator)
        {
        }

        public IValidator GetValidator()
        {
            return this.Validator;
        }
    }
}
