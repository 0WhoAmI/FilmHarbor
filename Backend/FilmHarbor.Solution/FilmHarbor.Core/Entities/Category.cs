using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        //Navigattion Properties
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
