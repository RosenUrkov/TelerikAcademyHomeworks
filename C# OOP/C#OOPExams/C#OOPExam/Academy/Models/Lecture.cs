using System;
using System.Collections.Generic;
using Academy.Models.Contracts;
using System.Text;

namespace Academy.Models
{
    public class Lecture : ILecture
    {        
        private string name;
        private ITrainer trainer;
        private IList<ILectureResouce> resources;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(date);
            this.Trainer = trainer;
            this.resources = new List<ILectureResouce>();      
        }

        public DateTime Date { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {

                Validator.ValidateString(value, Validator.LectureNameMinLength, Validator.LectureNameMaxLength, Validator.LectureNameMessage);
                this.name = value;
            }
        }

        public IList<ILectureResouce> Resouces
        {
            get
            {
                return this.resources;
            }
            private set
            {
                this.resources = value;
            }
        }

        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }

            set
            {
                Validator.ValidateNullObjectInstance(value);
                this.trainer = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"  * Lecture:");
            builder.AppendLine($"   - Name: {this.Name}");
            builder.AppendLine($"   - Date: {this.Date}");
            builder.AppendLine($"   - Trainer username: {this.Trainer.Username}");
            builder.AppendLine($"   - Resources:");

            if (this.Resouces.Count == 0)
            {
                builder.AppendLine("    * There are no resources in this lecture.");
                return builder.ToString().TrimEnd();
            }

            foreach (var resource in this.Resouces)
            {
                builder.AppendLine(resource.ToString());
            }
            return builder.ToString().TrimEnd();
        }
    }
}
