namespace School.Models
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}