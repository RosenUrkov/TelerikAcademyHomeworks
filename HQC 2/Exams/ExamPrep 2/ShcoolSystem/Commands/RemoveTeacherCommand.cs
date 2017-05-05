namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;

    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Students.Remove(int.Parse(parameters[0]));
            return $"Teacher with ID {int.Parse(parameters[0])} was sucessfully removed.";
        }
    }
}
