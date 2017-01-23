namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    public class School : ISchool
    {
        private List<Class> classList;

        private School()
        {
            classList = new List<Class>();
        }

        public School(Class schoolClass) : this()
        {
            classList.Add(schoolClass);
        }

        public School(List<Class> schoolClasses) : this()
        {
            classList.AddRange(schoolClasses);
        }

        public List<Class> Classes
        {
            get
            {
                return new List<Class>(this.classList);
            }
        }

        public void AddClass(Class newClass)
        {
            classList.Add(newClass);
        }

        public void AddStudent(int classIndex, Student student)
        {
            classList[classIndex].AddStudent(student);
        }

        public void AddTeacher(int classIndex, Teacher teacher)
        {
            classList[classIndex].AddTeacher(teacher);
        }
    }
}
