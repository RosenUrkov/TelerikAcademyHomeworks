namespace SchoolSystem.Models
{
    using Contracts;
    using SchoolSystem.Enums;
    using System.Collections.Generic;
    using System.Linq;

    public class Student : Person, IStudent, IPerson
    {
        private const int MinGrade = 2;
        private const int MaxGrade = 12;
        private const string InvalidGradeMessage = "Enter valid grade between {0} and {1}";

        private Grade grade;

        public Student(string firstName, string lastName, Grade grade, IValidator validator = null)
            : base(firstName, lastName, validator)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.Validator.ValidateNumberRange((int)value, MinGrade, MaxGrade, InvalidGradeMessage);

                this.grade = value;
            }
        }

        public List<IMark> Marks { get; private set; }

        public string ListMarks()
        {
            var marks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();
            return marks.Count == 0 ? "This student has no marks." : "The student has these marks:\n" + string.Join("\n", marks);
        }
    }
}
