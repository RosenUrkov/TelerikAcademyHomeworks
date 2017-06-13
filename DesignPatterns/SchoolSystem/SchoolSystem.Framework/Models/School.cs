using SchoolSystem.Framework.Models.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace SchoolSystem.Framework.Models
{
    public class School : ISchoolSystem
    {
        private readonly IDictionary<int, IStudent> students;
        private readonly IDictionary<int, ITeacher> teachers;

        public School()
        {
            this.students = new Dictionary<int, IStudent>();
            this.teachers = new Dictionary<int, ITeacher>();
        }

        public void AddStudent(int studentId, IStudent student)
        {
            this.students.Add(studentId, student);
        }

        public void AddTeacher(int teacherId, ITeacher teacher)
        {
            this.teachers.Add(teacherId, teacher);
        }

        public IStudent GetStudent(int studentId)
        {

            if (!this.students.ContainsKey(studentId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            return this.students.FirstOrDefault(x => x.Key == studentId).Value;            
        }

        public ITeacher GetTeacher(int teacherId)
        {
            if (!this.teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            return this.teachers.FirstOrDefault(x => x.Key == teacherId).Value;
        }

        public void RemoveStudent(int studentId)
        {
            if (!this.students.ContainsKey(studentId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.students.Remove(studentId);
        }

        public void RemoveTeacher(int teacherId)
        {
            if (!this.teachers.ContainsKey(teacherId))
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.teachers.Remove(teacherId);
        }
    }
}
