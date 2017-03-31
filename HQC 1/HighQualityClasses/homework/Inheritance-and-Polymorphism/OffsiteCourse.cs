namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName) :
            this(courseName, "Cuki")
        {
        }

        public OffsiteCourse(string courseName, string teacherName) :
            this(courseName, teacherName, new List<string>(), "Sofia")
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town) :
            base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString().Trim();
        }
    }
}
