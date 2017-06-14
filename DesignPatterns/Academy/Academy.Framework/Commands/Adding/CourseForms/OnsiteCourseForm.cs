using System;
using Academy.Framework.Core.Contracts;
using Academy.Models.Contracts;

namespace Academy.Framework.Commands.Adding.CourseForms
{
    public class OnsiteCourseForm : ICourseForm
    {
        private string courseForm = "onsite";

        public void AddStudentToCourseForm(ICourse course, IStudent student)
        {
            course.OnsiteStudents.Add(student);
        }

        public bool CheckForm(string formName)
        {
            return formName.ToLower() == courseForm;
        }
    }
}
