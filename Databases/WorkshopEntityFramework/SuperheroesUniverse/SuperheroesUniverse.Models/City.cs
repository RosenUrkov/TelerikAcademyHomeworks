using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        public City()
        {
            this.Superheroes = new HashSet<Superhero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Superhero> Superheroes { get; set; }
    }
}