using System;
using Dealership.Contracts;
using Dealership.Common;
using System.Text;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string author;
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                Validator.ValidateNull(value, "Author username can not be null");
                this.author = value;
            }
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateNull(value, "Message content can not be null");
                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Content", Constants.MinCommentLength, Constants.MaxCommentLength));
                this.content = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"    {Content}");
            builder.AppendLine($"      User: {Author}");
            return builder.ToString().TrimEnd();
        }
    }
}
