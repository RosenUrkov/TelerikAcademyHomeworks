namespace AcademyEcosystemCLI.Tests.Core.Mocks
{
    using Contracts;
    using AcademyEcosystemCLI.Core;
    using System.Collections.Generic;

    public class EngineMock : Engine
    {
        public EngineMock(IReader reader, IWriter writer, IValidator validator = null) 
            : base(reader, writer, validator)
        {
        }

        public IReader GetReader()
        {
            return this.Reader;
        }

        public IWriter getWriter()
        {
            return this.Writer;
        }

        public IValidator GetValidator()
        {
            return this.Validator;
        }

        public IList<IOrganism> GetOrganisms()
        {
            return this.AllOrganisms;
        }
    }
}
