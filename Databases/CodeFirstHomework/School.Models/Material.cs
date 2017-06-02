namespace School.Models
{
    public class Material
    {
        public int Id { get; set; }

        public SubjectType Subject { get; set; }

        public Course Course { get; set; }
    }
}