using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; } = string.Empty;

        public int? ReleaseYear { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        public Category Category { get; set; }

        //public virtual ICollection<FavoriteMovie> FavoriteMovies { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }
    }
}
