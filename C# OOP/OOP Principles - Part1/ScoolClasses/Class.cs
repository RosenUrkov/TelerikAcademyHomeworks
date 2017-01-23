namespace SchoolSystem
{
    using System.Collections.Generic;
    public class Class
    {
        private List<Student> studentsInClass;
        private List<Teacher> classTeachers;

        public Class(string classIdentifier)
        {
            studentsInClass = new List<Student>();
            classTeachers = new List<Teacher>();
            this.ClassIdentifier = classIdentifier;
        }

        public Class(string classIdentifier, List<Student> students, List<Teacher> teachers) : this(classIdentifier)
        {
            studentsInClass.AddRange(students);
            classTeachers.AddRange(teachers);
                    
        }

        public string  ClassIdentifier { get; set; }
        public List<Student> StudentsInClass
        {
            get
            {
                return new List<Student>(this.studentsInClass);
            }
        }
        public List<Teacher> ClassTeachers
        {
            get
            {
                return new List<Teacher>(this.classTeachers);
            }
        }

        public void AddStudent(Student student)
        {
            this.studentsInClass.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.classTeachers.Add(teacher);
        }

    }
}
