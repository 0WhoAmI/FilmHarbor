using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        //Navigattion Properties
        //public virtual ICollection<Movie>? Movies { get; set; }
    }
}
