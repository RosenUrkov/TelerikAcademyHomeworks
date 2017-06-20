using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Power
    {
        public Power()
        {
            this.Superheroes = new HashSet<Superhero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3), MaxLength(35)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes { get; set; }
    }
}