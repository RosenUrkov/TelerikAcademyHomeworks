namespace SchoolSystem.Commands
{
    using Contracts;
    using Core;
    using Enums;
    using Models;
    using System.Collections.Generic;

    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Students.Add(id, new Student(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])));
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
