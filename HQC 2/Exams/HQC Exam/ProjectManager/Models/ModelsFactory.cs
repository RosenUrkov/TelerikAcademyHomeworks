namespace ProjectManager.Models
{
    using Common;
    using Common.Contracts;
    using Contracts;
    using Enums;
    using ProjectManager.Common.CustomExceptions;
    using System;

    public class ModelsFactory : IModelsFactory
    {
        private const string InvalidStartingDateMessage = "Failed to parse the passed starting date!";
        private const string InvalidEngingDateMessage = "Failed to parse the passed ending date!";

        public ModelsFactory(IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }
        }

        public IValidator Validator { get; private set; }

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;

            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException(InvalidStartingDateMessage);
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException(InvalidEngingDateMessage);
            }

            ProjectState projectState = (ProjectState)Enum.Parse(typeof(ProjectState), state);

            var project = new Project(name, starting, end, projectState);
            this.Validator.Validate(project);

            return project;
        }

        public ITask CreateTask(string name, IUser owner, string state)
        {
            TaskState taskState = (TaskState)Enum.Parse(typeof(TaskState), state);

            var task = new Task(name, owner, taskState);
            this.Validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.Validator.Validate(user);

            return user;
        }
    }
}
