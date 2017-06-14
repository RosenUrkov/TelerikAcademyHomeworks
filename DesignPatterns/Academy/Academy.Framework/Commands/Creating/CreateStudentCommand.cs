using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyModel academy;

        public CreateStudentCommand(IAcademyFactory factory, IAcademyModel academy)
        {
            this.factory = factory;
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var track = parameters[1];

            if (this.academy.GetStudent(username) != null || this.academy.GetTrainer(username) != null)
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var student = this.factory.CreateStudent(username, track);
            var studentId = this.academy.AddStudent(student);

            return $"Student with ID {studentId} was created.";
        }
    }
}
