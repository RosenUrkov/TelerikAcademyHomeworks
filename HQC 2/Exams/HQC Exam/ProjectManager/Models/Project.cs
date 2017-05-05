namespace ProjectManager.Models
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Project : IProject
    {
        private const string RequiredProjectNameMessage = "Project Name is required!";

        private const string ProjectStartingDateErrorMessage = "Project StartingDate must be between 1800-1-1 and 2017-1-1!";
        private const string ProjectEndingDateErrorMessage = "Project EndingDate must be between 2018-1-1 and 2144-1-1!";

        private const string NoUsersMessage = "  - This project has no users!";
        private const string NoTasksMessage = "  - This project has no tasks!";

        public Project(string name, DateTime startingDate, DateTime endingDate, ProjectState state)
        {
            this.Name = name;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
            this.State = state;

            this.Users = new List<IUser>();
            this.Tasks = new List<ITask>();
        }

        public virtual List<IUser> Users { get; private set; }

        public virtual List<ITask> Tasks { get; private set; }

        [Required(ErrorMessage = RequiredProjectNameMessage)]
        public string Name { get; private set; }
        [Range(typeof(DateTime), "1800-1-1", "2017-1-1", ErrorMessage = ProjectStartingDateErrorMessage)]
        public DateTime StartingDate { get; private set; }
        [Range(typeof(DateTime), "2018-1-1", "2144-1-1", ErrorMessage = ProjectEndingDateErrorMessage)]
        public DateTime EndingDate { get; private set; }

        public ProjectState State { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Name: " + this.Name);
            builder.AppendLine("  Starting date: " + this.StartingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  Ending date: " + this.EndingDate.ToString("yyyy-MM-dd"));
            builder.AppendLine("  State: " + this.State);
            builder.AppendLine("  Users: ");

            builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Users));

            if (this.Users.Count == 0)
            {
                builder.AppendLine(NoUsersMessage);
            }

            builder.AppendLine("  Tasks: ");
            builder.Append(string.Join(Environment.NewLine + "  -------------" + Environment.NewLine, this.Tasks));

            if (this.Tasks.Count == 0)
            {
                builder.Append(NoTasksMessage);
            }

            return builder.ToString();
        }
    }
}