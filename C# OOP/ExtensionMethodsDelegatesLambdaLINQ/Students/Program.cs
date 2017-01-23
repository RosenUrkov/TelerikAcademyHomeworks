namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            //place a breakpoint at the end of the main method, start debugging and watch the values of the collections :)

            var studentList = new List<Student>();
            studentList.Add(new Student("Ivan", "Petrov", 22));
            studentList.Add(new Student("Petko", "Georgiev", 27));
            studentList.Add(new Student("Georgi", "Dimitrov", 19));
            studentList.Add(new Student("Georgi", "Qnakiev", 30));

            var firstBeforeLast =
                from student in studentList
                where student.FirstName.CompareTo(student.LastName) < 0
                select student.FirstName + " " + student.LastName;

            var ageRange =
                from student in studentList
                where student.Age >= 18 && student.Age <= 24
                select student.FirstName + " " + student.LastName;

            var orderStudents = studentList.OrderBy(student => student.FirstName)
                .ThenByDescending(student => student.LastName)
                .Select(student => student.FirstName + " " + student.LastName);

            var orderStudentsLinq =
                from student in studentList
                orderby student.FirstName ascending, student.LastName descending                
                select student.FirstName + " " + student.LastName;


        }

    }
}
