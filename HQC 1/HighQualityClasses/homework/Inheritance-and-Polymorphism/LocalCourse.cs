namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string courseName) :
            this(courseName, "Cuki")
        {
        }

        public LocalCourse(string courseName, string teacherName) :
            this(courseName, teacherName, new List<string>(), "Ultimate")
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab) :
            base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
