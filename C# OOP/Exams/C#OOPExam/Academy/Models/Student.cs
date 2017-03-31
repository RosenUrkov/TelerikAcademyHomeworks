using System;
using System.Collections.Generic;
using Academy.Models.Contracts;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    using System.Linq;
    using System.Text;

    public class Student : User, IStudent, IUser
    {
        private IList<ICourseResult> courseResults;

        public Student(string username, string track) : base(username)
        {
            try
            {
                this.Track = (Track)Enum.Parse(typeof(Track), track);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("The provided track is not valid!");
            }

            this.courseResults = new List<ICourseResult>();

        }

        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }

            set
            {                
                this.courseResults = value;
            }
        }

        public Track Track { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"* Student:");
            builder.AppendLine($" - Username: {this.Username}");
            builder.AppendLine($" - Track: {this.Track}");
            builder.AppendLine($" - Course results:");

            if (this.CourseResults.Count == 0)
            {
                builder.AppendLine("  * User has no course results!");
                return builder.ToString().TrimEnd();
            }

            foreach (var result in this.CourseResults)
            {
                builder.AppendLine(result.ToString());
            }
            return builder.ToString().TrimEnd();
        }
    }
}
