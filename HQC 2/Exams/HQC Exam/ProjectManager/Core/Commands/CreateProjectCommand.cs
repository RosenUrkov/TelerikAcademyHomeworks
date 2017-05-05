namespace ProjectManager.Core.Commands
{
    using Common.Contracts;
    using Common.CustomExceptions;
    using Contracts;
    using Data;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateProjectCommand : CreationalCommand, ICommand
    {
        private const string InvalidProjectMessage = "A project with that name already exists!";

        public CreateProjectCommand(IDatabase database, IModelsFactory factory, IValidator validator = null)
            : base(database, factory, validator)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var message = base.Execute(parameters);

            if (this.Datebase.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException(InvalidProjectMessage);
            }

            var project = this.Factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.Datebase.Projects.Add(project);

            return message + "project!";
        }

        protected override int GetParametersCount()
        {
            return 4;
        }
    }
}
