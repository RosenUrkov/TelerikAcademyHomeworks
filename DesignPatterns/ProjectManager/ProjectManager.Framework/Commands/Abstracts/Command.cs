using Bytes2you.Validation;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IDatabase Database;

        public Command(IDatabase database)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();

            this.Database = database;
        }

        protected abstract int GetParametersCount();

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count != this.GetParametersCount())
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }
        }
    }
}
