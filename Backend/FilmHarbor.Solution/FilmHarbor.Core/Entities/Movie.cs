using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Title { get; set; }

        public int? ReleaseYear { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }


        //Navigattion Properties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //public virtual ICollection<FavoriteMovie> FavoriteMovies { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }
    }
}
