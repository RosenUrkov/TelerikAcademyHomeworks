namespace StudentGroups
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string tel;
        private string facultityNumber;
        private List<int> marks;

        public Student(string firstName, string lastName, string FN, int groupNumber, string email, string departament = "Mathematics")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = FN;            
            this.Email = email;
            this.marks = new List<int>();
            this.StudentGroup = new Group(groupNumber,departament);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Telephone number must be 10 digits long.");
                }
                NonDigitCheck(value);
                this.tel = value;
            }
        }

        public string FN
        {
            get
            {
                return this.facultityNumber;
            }

            set
            {
                NonDigitCheck(value);
                this.facultityNumber = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                return new List<int>(this.marks);
            }

            private set
            {
                this.marks = value;
            }
        }

        public string Email { get; }

        public Group StudentGroup { get; set; }

        public void AddMark(int mark)
        {
            this.marks.Add(mark);
        }

        private void NonDigitCheck(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]) == false)
                {
                    throw new ArgumentException("Number must contain only digits");
                }

            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}
