using System;

namespace Academy.Models
{
    public static class Validator
    {
        public const int CourseNameMinLength = 3;
        public const int CourseNameMaxLength = 45;
        public const string CourseNameMessage = "The name of the course must be between {0} and {1} symbols!";

        public const int LecturesPerWeekMinNumber = 1;
        public const int LecturesPerWeekMaxNumber = 7;
        public const string LecturesPerWeekMessage = "The number of lectures per week must be between {0} and {1}!";

        public const int UsernameMinLength = 3;
        public const int UsernameMaxLength = 16;
        public const string UsernameMessage = "User's username should be between {0} and {1} symbols long!";

        public const int LectureNameMinLength = 5;
        public const int LectureNameMaxLength = 30;
        public const string LectureNameMessage = "Lecture's name should be between {0} and {1} symbols long!";

        public const int MinExamPoints = 0;
        public const int MaxExamPoints = 1000;
        public const string ExamPointsMessage = "Course result's exam points should be between {0} and {1}!";

        public const int MinCoursePoints = 0;
        public const int MaxCoursePoints = 125;
        public const string CoursePointsMessage = "Course result's course points should be between {0} and {1}!";

        public const int LectureResourceNameMinLength = 3;
        public const int LectureResourceNameMaxLength = 15;
        public const string LectureResourceMessage = "Resource name should be between {0} and {1} symbols long!";

        public const int UrlMinLength = 5;
        public const int UrlMaxLength = 150;
        public const string UrlMessage = "Resource url should be between {0} and {1} symbols long!";


        public static void ValidateString(string text,int minLength, int maxLength,string message)
        {
            if (string.IsNullOrEmpty(text) || text.Length < minLength || text.Length > maxLength)
            {
                throw new ArgumentException(string.Format(message,minLength,maxLength));
            }
        }

        public static void ValidateNumber(int number,int minValue, int maxValue, string message)
        {
            if (number < minValue || number > maxValue)
            {
                throw new ArgumentException(string.Format(message, minValue, maxValue));
            }
        }

        public static void ValidateNumber(float number, int minValue, int maxValue, string message)
        {
            if (number < minValue || number > maxValue)
            {
                throw new ArgumentException(string.Format(message, minValue, maxValue));
            }
        }

        public static void ValidateNullObjectInstance(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Object instance cannot be null");
            }
        }
    }
}
