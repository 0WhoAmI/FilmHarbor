using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        //Navigattion Properties
        public User? User { get; set; }

        public Movie? Movie { get; set; }
    }
}
