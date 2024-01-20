using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FilmHarbor.Core.Entities
{
    public class User : IdentityUser<int>
    {
        [StringLength(50)]
        public string? PersonName { get; set; }


        //Navigattion Properties
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Movie> FavouriteMovies { get; set; } = new List<Movie>();
    }
}
