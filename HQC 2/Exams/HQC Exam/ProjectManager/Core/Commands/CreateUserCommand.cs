namespace ProjectManager.Core.Commands
{
    using Common.Contracts;
    using Contracts;
    using Models.Contracts;
    using ProjectManager.Common.CustomExceptions;
    using ProjectManager.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateUserCommand : CreationalCommand, ICommand
    {
        private const string InvalidUserMessage = "A user with that username already exists!";

        public CreateUserCommand(IDatabase datebase, IModelsFactory factory, IValidator validator = null)
            : base(datebase, factory, validator)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var message = base.Execute(parameters);

            if (this.Datebase.Projects[int.Parse(parameters[0])].Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException(InvalidUserMessage);
            }

            this.Datebase.Projects[int.Parse(parameters[0])].Users.Add(this.Factory.CreateUser(parameters[1], parameters[2]));

            return message + "user!";
        }

        protected override int GetParametersCount()
        {
            return 3;
        }
    }
}
