using System;

namespace StudentsAndCourses
{
    public class Student
    {
        private static int uniqueNumberGen = 10000;

        private string name;
        private int uniqueNumber;

        public Student(string name)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumberGen;
            uniqueNumberGen++;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must not be empty");
                }
                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentException("Unique number must be between 10000 and 99999");
                }
                this.uniqueNumber = value;
            }
        }
    }
}
