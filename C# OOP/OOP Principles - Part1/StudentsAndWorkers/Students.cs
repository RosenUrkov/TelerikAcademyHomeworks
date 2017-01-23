using System;

namespace StudentsAndWorkers
{
    public class Students : Human
    {
        private double grade;

        public Students(string firstName, string lastName, double studentGrade):base(firstName,lastName)
        {
            this.Grade = studentGrade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Grade must be between 2 and 6.");
                }
                this.grade = value;
            }
        }
        
    }
}
