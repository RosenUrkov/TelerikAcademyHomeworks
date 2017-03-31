using System;
using Academy.Models.Contracts;
using System.Text;

namespace Academy.Models
{
    public abstract class LectureResource : ILectureResouce
    {
        private string name;
        private string url;

        public LectureResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public string Type { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateString(value, Validator.LectureResourceNameMinLength, Validator.LectureResourceNameMaxLength, Validator.LectureResourceMessage);
                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                Validator.ValidateString(value, Validator.UrlMinLength, Validator.UrlMaxLength, Validator.UrlMessage);
                this.url = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"    * Resource:");
            builder.AppendLine($"     - Name: {this.Name}");
            builder.AppendLine($"     - Url: {this.Url}");
            builder.AppendLine($"     - Type: {this.Type}");
            builder.AppendLine(AdditionalInfo());

            return builder.ToString().TrimEnd();
        }

        protected abstract string AdditionalInfo();
    }
}
