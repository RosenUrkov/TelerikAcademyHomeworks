using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;

        private IList<ILecture> lectures;
        private IList<IStudent> onlineStudents;
        private IList<IStudent> onsiteStudents;

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(startingDate);
            this.EndingDate = this.StartingDate.AddDays(30);
            this.lectures = new List<ILecture>();
            this.onlineStudents = new List<IStudent>();
            this.onsiteStudents = new List<IStudent>();       
        }

        public DateTime EndingDate { get; set; }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            private set
            {
                this.lectures = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                Validator.ValidateNumber(value, Validator.LecturesPerWeekMinNumber, Validator.LecturesPerWeekMaxNumber, Validator.LecturesPerWeekMessage);
                this.lecturesPerWeek = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.ValidateString(value, Validator.CourseNameMinLength, Validator.CourseNameMaxLength, Validator.CourseNameMessage);
                this.name = value;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            private set
            {
                this.onlineStudents = value;
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            private set
            {
                this.onsiteStudents = value;
            }
        }

        public DateTime StartingDate { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("* Course:");
            builder.AppendLine($" - Name: {this.name}");
            builder.AppendLine($" - Lectures per week: {this.lecturesPerWeek}");
            builder.AppendLine($" - Starting date: {this.StartingDate}");
            builder.AppendLine($" - Ending date: {this.EndingDate}");
            builder.AppendLine($" - Onsite students: {this.OnsiteStudents.Count}");
            builder.AppendLine($" - Online students: {this.OnlineStudents.Count}");
            builder.AppendLine($" - Lectures:");

            if (this.Lectures.Count == 0)
            {
                builder.AppendLine($"  * There are no lectures in this course!");
                return builder.ToString().TrimEnd();
            }

            foreach (var lecture in this.Lectures)
            {
                builder.AppendLine(lecture.ToString());
            }

            return builder.ToString().TrimEnd();           

            
        }
    }
}
