using Academy.Models.Contracts;
using System.Text;
using System;

namespace Academy.Models
{
    public class HomeworkResource : LectureResource, ILectureResouce
    {
        public HomeworkResource(string name, string url, DateTime dueDate) : base(name, url)
        {
            this.Type = "Homework";
            this.DueDate = dueDate.AddDays(7);
        }

        public DateTime DueDate { get; protected set; }

        protected override string AdditionalInfo()
        {
            return $"     - Due date: {this.DueDate}";
        }
    }
}
