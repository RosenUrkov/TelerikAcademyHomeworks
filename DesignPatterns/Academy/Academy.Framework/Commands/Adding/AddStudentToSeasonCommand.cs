using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddStudentToSeasonCommand : ICommand
    {
        private readonly IAcademyModel academy;

        public AddStudentToSeasonCommand(IAcademyModel academy)
        {
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var studentUsername = parameters[0];
            var seasonId = int.Parse(parameters[1]);

            var student = this.academy.GetStudent(studentUsername);
            var season = this.academy.GetSeason(seasonId);

            if (season.Students.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The Student {studentUsername} is already a part of Season {seasonId}!");
            }

            season.Students.Add(student);
            return $"Student {studentUsername} was added to Season {seasonId}.";
        }
    }
}
