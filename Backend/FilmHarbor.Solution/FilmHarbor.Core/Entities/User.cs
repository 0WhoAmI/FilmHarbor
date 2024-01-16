using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string Password { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        //Navigattion Properties
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Movie> FavouriteMovies { get; set; } = new List<Movie>();
    }
}
