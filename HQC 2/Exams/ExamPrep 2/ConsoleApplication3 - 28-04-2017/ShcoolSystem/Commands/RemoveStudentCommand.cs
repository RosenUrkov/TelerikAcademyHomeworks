namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;

    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Students.Remove(int.Parse(parameters[0]));
            return $"Student with ID {int.Parse(parameters[0])} was sucessfully removed.";
        }
    }
}
