namespace SchoolClasses
{
    using SchoolSystem;
    public class MainClass
    {
        public static void Main(string[] args)
        {  
            var firstDiscipline = new Discipline("Physics", 2, 3);

            var firstTeacher = new Teacher("Petrov");
            firstTeacher.AddDiscipline(firstDiscipline);

            var firstStudent = new Student("Ivo", "Ivanov");

            var firstClass = new Class("12B");
            firstClass.AddStudent(firstStudent);
            firstClass.AddTeacher(firstTeacher);

            var mySchool = new School(firstClass);

        }

    }
}
