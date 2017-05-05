namespace SchoolSystem.Commands
{
    using Core;
    using SchoolSystem.Contracts;
    using System.Collections.Generic;

    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}
