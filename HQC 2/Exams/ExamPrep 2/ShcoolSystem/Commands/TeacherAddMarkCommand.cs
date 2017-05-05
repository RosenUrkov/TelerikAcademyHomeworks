namespace SchoolSystem.Commands
{
    using Core;
    using SchoolSystem.Contracts;
    using System.Collections.Generic;

    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);

            var teacher = Engine.Teachers[teacherId];
            var student = Engine.Students[studentId];

            teacher.AddMark(student, float.Parse(parameters[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
