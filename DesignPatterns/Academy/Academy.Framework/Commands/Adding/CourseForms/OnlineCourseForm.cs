using System;
using Academy.Framework.Core.Contracts;
using Academy.Models.Contracts;

namespace Academy.Framework.Commands.Adding.CourseForms
{
    public class OnlineCourseForm : ICourseForm
    {
        private const string courseForm = "online";

        public void AddStudentToCourseForm(ICourse course, IStudent student)
        {
            course.OnlineStudents.Add(student);
        }

        public bool CheckForm(string formName)
        {
            return formName.ToLower() == courseForm;
        }
    }
}
