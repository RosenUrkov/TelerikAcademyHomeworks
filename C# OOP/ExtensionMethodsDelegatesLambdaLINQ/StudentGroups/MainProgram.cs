namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            //we will need some randomness
            var generator = new Random();

            //create some students
            var studentsList = new List<Student>();
            studentsList.Add(new Student("Kalina", "Peshova", "111206" + CreateRandomNumberSequence(generator, 4), generator.Next(1, 4), "malkoKote@gmail.com"));
            studentsList.Add(new Student("Petko", "Ivanov", CreateRandomNumberSequence(generator, 10), generator.Next(1, 4), "petko.trepacha@abv.bg" , "Physics"));
            studentsList.Add(new Student("Martina", "Koparanova", CreateRandomNumberSequence(generator, 10), generator.Next(1, 4), "marina_kop@abv.bg" , "Art"));
            studentsList.Add(new Student("Ivan", "Petrov", "123406" + CreateRandomNumberSequence(generator, 4), generator.Next(1, 4), "vankata@gmail.com"));

            //get students in group 2 and order them by 1-st name
            var groupTwoFirstNameOrdered =
                from student in studentsList
                where student.StudentGroup.GroupNumber == 2
                orderby student.FirstName
                select student.ToString();

            var sameButWithExtension = studentsList.Where(student => student.StudentGroup.GroupNumber == 2)
                .OrderBy(student => student.FirstName).Select(student => student.ToString());

            //get students with abv email adress
            string emailPattern = @"\S*?@abv\.bg";

            var abvEmails =
                from student in studentsList
                where Regex.IsMatch(student.Email, emailPattern)
                select student.ToString();

            //get students with tel numbers that have Sofias encoding - 02
            studentsList[0].Tel = "02" + CreateRandomNumberSequence(generator, 8);
            studentsList[1].Tel = "088" + CreateRandomNumberSequence(generator, 7);
            studentsList[2].Tel = "02" + CreateRandomNumberSequence(generator, 8);
            studentsList[3].Tel = "089" + CreateRandomNumberSequence(generator, 7);

            string telPattern = @"^02[0-9]{8}";

            var sofiaTelNumbers =
                from student in studentsList
                where Regex.IsMatch(student.Tel, telPattern)
                select student.ToString();

            //generate some grades and find excellent students
            for (int i = 0; i < studentsList.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var mark = generator.Next(2, 7);
                    studentsList[i].AddMark(mark);
                }
            }

            var excellentStudents =
                from student in studentsList
                where student.Marks.Contains(6)
                select new { FullName = student.ToString(), Marks = student.Marks };

            //generate some bad marks and find the students that met the condition
            for (int i = 0; i < 5; i++)
            {
                studentsList[generator.Next(0, 4)].AddMark(2);
            }

            var badStudents = studentsList.Where(student => student.Marks.FindAll(mark => mark == 2).Count == 2)
                .Select(student => student.ToString());

            //find students that enrolled in 2006
            var enrolledStudents = studentsList.Where(student => student.FN[4] == '0' && student.FN[5] == '6')
                .Select(student => student.ToString());

            //find all students from mathematics departament
            var mathDepStudents = studentsList.Where(student => student.StudentGroup.DepartamentName.ToLower() == "mathematics")
                .Select(student => student.ToString());

            //find the longest string from array
            var list = new List<string>();
            foreach (var student in studentsList)
            {
                list.Add(student.FirstName);
            }

            var longestString = list.OrderByDescending(name => name.Length).First();

            //extract students by group numbers and print
            var orderedStudents =
                from student in studentsList
                group student by student.StudentGroup.GroupNumber;

            foreach (var group in orderedStudents)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student.ToString());
                }
                Console.WriteLine();
            }

            var sameButWithExtensions = studentsList.GroupBy(student => student.StudentGroup.GroupNumber);
            foreach (var group in sameButWithExtensions)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student.ToString());
                }
                Console.WriteLine( );               
            }
        }

        static string CreateRandomNumberSequence(Random generator, int length)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(generator.Next(0, 10));
            }
            return builder.ToString();
        }
    }
}
