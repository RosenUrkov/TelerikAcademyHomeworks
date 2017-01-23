using System;
using System.Collections.Generic;
using Academy.Models.Contracts;
using System.Text;

namespace Academy.Models
{
    public class Trainer : User, ITrainer, IUser
    {
        private IList<string> technologies;

        public Trainer(string username, string technologies)
            : base(username)
        {
            this.technologies = new List<string>();
            this.Technologies = technologies.Split(',');   
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }

            set
            {                
                this.technologies = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"* Trainer:");
            builder.AppendLine($" - Username: {this.Username}");
            builder.AppendLine($" - Technologies: {string.Join("; ", this.Technologies)}");

            return builder.ToString().TrimEnd();
        }
    }
}
