using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateCourseResultCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IAcademyModel academy;

        public CreateCourseResultCommand(IAcademyFactory factory, IAcademyModel academy)
        {
            this.factory = factory;
            this.academy = academy;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = int.Parse(parameters[0]);
            var courseId = int.Parse(parameters[1]);
            var examPoints = parameters[2];
            var coursePoints = parameters[3];
            var studentUsername = parameters[4];

            var student = this.academy.GetStudent(studentUsername);
            var course = this.academy.GetSeason(seasonId).Courses[courseId];

            if (!course.OnsiteStudents.Any(x => x.Username.ToLower() == studentUsername.ToLower()) &&
                !course.OnlineStudents.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The student {studentUsername} is not signed up for the course {seasonId}.{course.Name}!");
            }

            var courseResult = this.factory.CreateCourseResult(course, examPoints, coursePoints);
            student.CourseResults.Add(courseResult);

            return $"Course result with ID {student.CourseResults.Count - 1} was created for Student {studentUsername}.";
        }
    }
}
