namespace SchoolSystem.Commands
{
    using Core;
    using Enums;
    using Models;
    using SchoolSystem.Contracts;
    using System.Collections.Generic;

    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Teachers.Add(id, new Teacher(parameters[0], parameters[1], (Subjct)int.Parse(parameters[2])));
            return $"A new teacher with name {parameters[0]} {parameters[1]}, subject {(Subjct)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
