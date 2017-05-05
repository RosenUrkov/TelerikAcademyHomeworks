namespace ProjectManager.Core.Providers
{
    using Commands;
    using Commands.Contracts;
    using Common;
    using Common.Contracts;
    using Contracts;
    using Enums;
    using Models.Contracts;
    using ProjectManager.Common.CustomExceptions;
    using ProjectManager.Data;
    using ProjectManager.Models;
    using System;

    public class CommandsFactory : ICommandsFactory
    {
        private const string InvalidCommandMessage = "The passed command is not valid!";

        private IDatabase datebase;
        private IModelsFactory factory;
        private IValidator validator;

        public CommandsFactory(IDatabase datebase, IModelsFactory factory, IValidator validator = null)
        {
            if (validator == null)
            {
                this.validator = new Validator();
            }

            this.validator.ValidateNullObject(datebase, "Datebase must not be null");
            this.validator.ValidateNullObject(factory, "Factory must not be null");

            this.datebase = datebase;
            this.factory = factory;
        }

        public ICommand CreateCommandFromString(string command)
        {
            CommandNames commandName;
            Enum.TryParse(command, out commandName);

            switch (commandName)
            {
                case CommandNames.CreateProject: return new CreateProjectCommand(this.datebase, this.factory);
                case CommandNames.CreateTask: return new CreateTaskCommand(this.datebase, this.factory);
                case CommandNames.CreateUser: return new CreateUserCommand(this.datebase, this.factory);
                case CommandNames.ListProjects: return new ListProjectsCommand(this.datebase);
                case CommandNames.ListProjectDetails: return new ListProjectDetailsCommand(this.datebase);
                default: throw new UserValidationException(InvalidCommandMessage);
            }
        }
    }
}