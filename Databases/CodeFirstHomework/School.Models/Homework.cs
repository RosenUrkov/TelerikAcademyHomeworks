namespace School.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        [Required]
        [Index]
        public Course Course { get; set; }

        [Required]
        [Index]
        public Student Student { get; set; }
    }
}