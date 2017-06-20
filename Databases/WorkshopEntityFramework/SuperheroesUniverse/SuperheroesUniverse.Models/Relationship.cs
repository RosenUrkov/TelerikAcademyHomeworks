using SuperheroesUniverse.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SuperheroesUniverse.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        public virtual Superhero FirstHero { get; set; }

        public virtual Superhero SecondHero { get; set; }

        [Required]
        public RelationshipType RelationshipType { get; set; }
    }
}
