namespace ProjectManager.Models
{
    using Contracts;
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Task : ITask
    {
        private const string RequiredTaskNameMessage = "Task Name is required!";
        private const string RequiredOwnerMessage = "Task Owner is required";

        public Task(string name, IUser owner, TaskState state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = RequiredTaskNameMessage)]
        public string Name { get; private set; }
        [Required(ErrorMessage = RequiredOwnerMessage)]
        public IUser Owner { get; private set; }

        public TaskState State { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.Name);
            builder.AppendLine("    Owner: " + this.Owner.Username);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }
    }
}
