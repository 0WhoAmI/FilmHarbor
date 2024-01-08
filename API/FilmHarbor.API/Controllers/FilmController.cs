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

        [HttpGet("film")]
        public Film GetFilm(int id)
        {
            if (id == 0)
                throw new Exception("Zły id.");

            Film film = Films.FirstOrDefault(film => film.Id == id);

            if (film == null)
                throw new Exception("Nie ma filmu z takim id.");

            return film;
        }

        [HttpPost("film/add")]
        public IEnumerable<Film> AddFilm(string filmName)
        {
            Films.Add(new Film(6,filmName, 2022, "testPost", new List<string> { "Action", "Adventure" }));

            return Films;
        }
    }
}
