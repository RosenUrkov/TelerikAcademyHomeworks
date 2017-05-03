namespace SchoolSystem.Models
{
    using SchoolSystem.Contracts;
    using Utils;

    public class Person : IPerson
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;
        private const string InvalidNameLengthMessage = "Enter valid name between {0} and {1} symbols";

        private const string NamePattern = "^[A-Za-z]*$";
        private const string InvalidNameMessage = "Name must contain only latin symbols";

        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName, IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }

            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.Validator.ValidateNumberRange(value.Length, MinNameLength, MaxNameLength, InvalidNameLengthMessage);
                this.Validator.ValidateStringCharacters(value, NamePattern, InvalidNameMessage);

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
                this.Validator.ValidateNumberRange(value.Length, MinNameLength, MaxNameLength, InvalidNameLengthMessage);
                this.Validator.ValidateStringCharacters(value, NamePattern, InvalidNameMessage);

                this.lastName = value;
            }
        }

        protected IValidator Validator { get; private set; }
    }
}
