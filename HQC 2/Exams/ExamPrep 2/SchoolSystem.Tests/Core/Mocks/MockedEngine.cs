namespace SchoolSystem.Tests.Core.Mocks
{
    using Contracts;
    using SchoolSystem.Core;

    public class MockedEngine : Engine
    {
        public MockedEngine(IReader reader, IWriter writer, ICommandParser parser, IValidator validator = null)
            : base(reader, writer, parser, validator)
        {
        }

        public IValidator GetValidator()
        {
            return this.Validator;
        }
    }
}
