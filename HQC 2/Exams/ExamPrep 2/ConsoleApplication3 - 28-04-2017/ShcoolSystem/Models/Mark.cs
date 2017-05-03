namespace SchoolSystem.Models
{
    using Contracts;
    using SchoolSystem.Enums;
    using Utils;

    public class Mark : IMark
    {
        private const int MinValue = 2;
        private const int MaxValue = 6;
        private const string InvalidValueMessage = "Enter valid value between {0} and {1}";

        private const int MinSubjectValue = 0;
        private const int MaxSubjectValue = 3;
        private const string InvalidSubjectMessage = "Enter a valid subject number between {0} and {1}";

        private float value;
        private Subjct subject;

        public Mark(Subjct subject, float value, IValidator validator = null)
        {
            if (validator == null)
            {
                this.Validator = new Validator();
            }
            else
            {
                this.Validator = validator;
            }

            this.Subject = subject;
            this.Value = value;
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

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                this.Validator.ValidateNumberRange(value, MinValue, MaxValue, InvalidValueMessage);

                this.value = value;
            }
        }

        protected IValidator Validator { get; private set; }
    }
}
