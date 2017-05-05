namespace SchoolSystem.Models
{
    using Contracts;
    using SchoolSystem.Enums;

    public class Teacher : Person, ITeacher, IPerson
    {
        private const int MinSubjectValue = 0;
        private const int MaxSubjectValue = 3;
        private const string InvalidSubjectMessage = "Enter a valid subject number between {0} and {1}";

        private Subjct subject;

        public Teacher(string firstName, string lastName, Subjct subject, IValidator validator = null) 
            : base(firstName, lastName, validator)
        {
            this.Subject = subject;
        }

        public Subjct Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.Validator.ValidateNumberRange((int)value, MinSubjectValue, MaxSubjectValue, InvalidSubjectMessage);

                this.subject = value;
            }
        }

        public void AddMark(IStudent student, float value)
        {
            this.Validator.ValidateNullObject(student, "Student must not be null");

            var cine = new Mark(this.Subject, value);
            student.Marks.Add(cine);
        }
    }
}
