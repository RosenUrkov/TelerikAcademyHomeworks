using System;

namespace SchoolSystem
{
    public class Student : Person
    {
        private static int uniqueClassNumberCreator;

        static Student()
        {
            uniqueClassNumberCreator = 0;
        }

        public Student(string firstName, string lastName) : base(firstName + ' ' + lastName)
        {
            this.ClassNumber = uniqueClassNumberCreator++;
        }

        public int ClassNumber { get; private set; }
    }
}
