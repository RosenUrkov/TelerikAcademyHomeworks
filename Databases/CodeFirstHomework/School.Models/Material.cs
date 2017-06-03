namespace School.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SubjectType Subject { get; set; }

        [Required]
        [Index]
        public Course Course { get; set; }
    }
}