namespace ProjectManager.Core.Providers
{
    using Commands;
    using Commands.Contracts;
    using Common;
    using Common.Contracts;
    using Common.CustomExceptions;
    using Contracts;
    using System;
    using System.Linq;

    public class CommandProcessor : ICommandProcessor
    {
        private const string InvalidCommandMessage = "No command has been provided!";

        private ICommandsFactory factory;
        private IValidator validator;

        public CommandProcessor(ICommandsFactory factory, IValidator validator = null)
        {
            if (validator == null)
            {
                this.validator = new Validator();
            }
            else
            {
                this.validator = validator;
            }

            this.validator.ValidateNullObject(factory, "Factory can not be null");

            this.factory = factory;
        }

        public string Process(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException(InvalidCommandMessage);
            }

            var command = this.factory.CreateCommandFromString(commandLine.Split(' ')[0]);
            return command.Execute(commandLine.Split(' ').Skip(1).ToList());
        }
    }
}
