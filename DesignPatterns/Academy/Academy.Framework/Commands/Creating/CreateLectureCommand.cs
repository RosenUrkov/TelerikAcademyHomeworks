using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateLectureCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyModel academy;

        public CreateLectureCommand(IAcademyFactory factory, IAcademyModel academy)
        {
            this.factory = factory;
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = int.Parse(parameters[0]);
            var courseId = int.Parse(parameters[1]);
            var name = parameters[2];
            var date = parameters[3];
            var trainerUsername = parameters[4];

            var course = this.academy.GetSeason(seasonId).Courses[courseId];
            var trainer = this.academy.GetTrainer(trainerUsername);

            var lecture = this.factory.CreateLecture(name, date, trainer);
            course.Lectures.Add(lecture);

            return $"Lecture with ID {course.Lectures.Count - 1} was created in course {seasonId}.{course.Name}.";
        }
    }
}
