namespace ProjectManager.Core.Commands
{
    using Common;
    using Common.Contracts;
    using Common.CustomExceptions;
    using Data;
    using Models;
    using Models.Contracts;
    using ProjectManager.Core.Commands.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CreateTaskCommand : CreationalCommand, ICommand
    {
        public CreateTaskCommand(IDatabase datebase, IModelsFactory factory, IValidator validator = null)
            : base(datebase, factory, validator)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var message = base.Execute(parameters);

            var projects = this.Datebase.Projects[int.Parse(parameters[0])];
            var owner = projects.Users[int.Parse(parameters[1])];

            var task = Factory.CreateTask(parameters[2], owner, parameters[3]);
            projects.Tasks.Add(task);

            return message + "task!";
        }

        protected override int GetParametersCount()
        {
            return 4;
        }
    }
}
