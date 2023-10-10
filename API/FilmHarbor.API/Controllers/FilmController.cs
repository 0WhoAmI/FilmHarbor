using FilmHarbor.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmHarbor.API.Controllers
{
    [ApiController]
    [Route("api/film")]
    public class FilmController : ControllerBase
    {
        private List<Film> Films;
        public FilmController()
        {
            List<Film> films = new List<Film>
            {
                new Film(1, "Movie 1", 2020, "Director A", new List<string> { "Action", "Adventure" }),
                new Film(2, "Movie 2", 2019, "Director B", new List<string> { "Drama", "Romance" }),
                new Film(3, "Movie 3", 2021, "Director C", new List<string> { "Sci-Fi", "Action" }),
                new Film(4, "Movie 4", 2018, "Director D", new List<string> { "Comedy" }),
                new Film(5, "Movie 5", 2017, "Director E", new List<string> { "Horror", "Thriller" }),
            };

            Films = films;
        }

        [HttpGet("films")]
        public IEnumerable<Film> GetFilms()
        {
            return Films;
        }
    }
}
