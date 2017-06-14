using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateCourseCommand : ICommand
    {
        private readonly IAcademyModel academy;
        private readonly IAcademyFactory factory;

        public CreateCourseCommand(IAcademyModel academy, IAcademyFactory factory)
        {
            this.academy = academy;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = int.Parse(parameters[0]);
            var name = parameters[1];
            var lecturesPerWeek = parameters[2];
            var startingDate = parameters[3];

            var season = this.academy.GetSeason(seasonId);
            var course = this.factory.CreateCourse(name, lecturesPerWeek, startingDate);
            season.Courses.Add(course);

            return $"Course with ID {season.Courses.Count - 1} was created in Season {seasonId}.";
        }
    }
}
