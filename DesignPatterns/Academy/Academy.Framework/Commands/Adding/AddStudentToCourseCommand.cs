using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Framework.Core.Contracts;
using Academy.Framework.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddStudentToCourseCommand : ICommand
    {
        private readonly IAcademyModel academy;
        private readonly IEnumerable<ICourseForm> courseForms;

        public AddStudentToCourseCommand(IAcademyModel academy, IEnumerable<ICourseForm> courseForms)
        {
            this.academy = academy;
            this.courseForms = courseForms;
        }

        public string Execute(IList<string> parameters)
        {
            var studentUsername = parameters[0];
            var seasonId = int.Parse(parameters[1]);
            var courseId = int.Parse(parameters[2]);
            var form = parameters[3];

            var student = this.academy.GetStudent(studentUsername);
            var course = this.academy.GetSeason(seasonId).Courses[courseId];

            var courseForm = this.courseForms.FirstOrDefault(x => x.CheckForm(form));
            if(courseForm == null)
            {
                throw new ArgumentException($"Cannot add student to course {seasonId}.{course.Name}. Invalid course form {form}!");
            }

            courseForm.AddStudentToCourseForm(course, student);
            return $"Student {studentUsername} was added to Course {seasonId}.{course.Name}.";
        }
    }
}
