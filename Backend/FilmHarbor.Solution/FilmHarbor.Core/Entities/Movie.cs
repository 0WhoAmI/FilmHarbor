using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHarbor.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Title { get; set; } = null!;

        public int CategoryId { get; set; }

        public int? ReleaseYear { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }


        //Navigattion Properties
        public Category? Category { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<User> FavouriteByUsers { get; set; } = new List<User>();
    }
}
