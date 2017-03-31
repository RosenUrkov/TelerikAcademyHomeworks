namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string town;
        private string birthDate;

        public Student(string firstName, string lastName, string town, string dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Town = town;
            this.BirthDate = dateOfBirth;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateString(Validator.NAME_PATTERN, value, "Incorrect first name!");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateString(Validator.NAME_PATTERN, value, "Incorrect last name!");
                this.lastName = value;
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            private set
            {
                Validator.ValidateString(Validator.NAME_PATTERN, value, "Incorrect town name!");
                this.town = value;
            }
        }

        public string BirthDate
        {
            get
            {
                return this.birthDate;
            }

            private set
            {
                Validator.ValidateString(Validator.DATE_PATTERN, value, "Incorrect date format!");
                this.birthDate = value;
            }
        }

        public bool IsOlderThan(string date)
        {
            var firstDate = DateTime.Parse(this.birthDate);
            var secondDate = DateTime.Parse(date);
            return firstDate < secondDate;
        }
    }
}
