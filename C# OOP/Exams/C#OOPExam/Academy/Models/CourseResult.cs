using System;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System.Text;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private ICourse course;
        private float coursePoints;
        private float examPoints;

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.Course = course;
            this.ExamPoints = float.Parse(examPoints);
            this.CoursePoints = float.Parse(coursePoints);
            this.CalculateGrade();      
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                Validator.ValidateNullObjectInstance(value);
                this.course = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            private set
            {
                Validator.ValidateNumber(value, Validator.MinCoursePoints, Validator.MaxCoursePoints, Validator.CoursePointsMessage);
                this.coursePoints = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            private set
            {
                Validator.ValidateNumber(value, Validator.MinExamPoints, Validator.MaxExamPoints, Validator.ExamPointsMessage);
                this.examPoints = value;
            }
        }

        public Grade Grade { get; set; }

        private void CalculateGrade()
        {
            if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
            {
                this.Grade = Grade.Excellent;
                return;
            }

            if ((this.ExamPoints < 60 && this.ExamPoints>=30)||(this.CoursePoints<75&&this.CoursePoints>=45))
            {
                this.Grade = Grade.Passed;
                return;
            }

            this.Grade = Grade.Failed;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"  * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}");
            return builder.ToString().TrimEnd();
        }
    }
}
