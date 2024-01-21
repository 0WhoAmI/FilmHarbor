using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _moviesRepository.GetAllMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> GetMovie(int movieId)
        {
            Movie? movie = await _moviesRepository.GetMovieByMovieId(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateMovie(int movieId, Movie movie)
        {
            if (movieId != movie.Id)
            {
                return BadRequest();
            }

            Movie? existingMovie = await _moviesRepository.GetMovieByMovieId(movieId);
            if (existingMovie == null)
            {
                return NotFound();
            }

            try
            {
                Movie updateMovie = await _moviesRepository.UpdateMovie(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(movieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie( Movie movie)
        {
            await _moviesRepository.AddMovie(movie);

            return CreatedAtAction("GetMovie", new { movieId = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {

            Movie? movie = await _moviesRepository.GetMovieByMovieId(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            await _moviesRepository.DeleteMovie(movie.Id);

            return NoContent();
        }

        private async Task<bool> MovieExists(int id)
        {
            List<Movie> movies = await _moviesRepository.GetAllMovies();

            return movies.Any(movie => movie.Id == id);
        }
    }
}
