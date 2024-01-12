using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; }
    }
}
