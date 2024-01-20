using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;

namespace FilmHarbor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteMoviesController : ControllerBase
    {
        private readonly IFavouriteMoviesRepository _favouriteMoviesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMoviesRepository _moviesRepository;

        public FavouriteMoviesController(IFavouriteMoviesRepository favouriteMoviesRepository, IUsersRepository usersRepository, IMoviesRepository moviesRepository)
        {
            _favouriteMoviesRepository = favouriteMoviesRepository;
            _usersRepository = usersRepository;
            _moviesRepository = moviesRepository;
        }

        // GET: api/FavouriteMovies/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetFavouriteMovies(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);

            if (user == null)
            {
                return NotFound();
            }

            return await _favouriteMoviesRepository.GetFavouriteMovies(userId);
        }

        // PUT: api/FavouriteMovies/5
        [HttpPost("{userId}/{movieId}")]
        public async Task<IActionResult> AddFavouriteMovies(int userId, int movieId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);
            Movie? movie = await _moviesRepository.GetMovieByMovieId(movieId);

            if (user != null && movie != null)
            {
                bool successfullyAdded = await _favouriteMoviesRepository.AddFavouriteMovie(userId, movieId);

                if (successfullyAdded)
                {
                    return NoContent();
                }

                return Problem(detail: "Film alredy is in favourites.", statusCode: 400);
            }

            return Problem(detail: "No found user or movie.", statusCode: 400);
        }

        // DELETE: api/Users/5
        [HttpDelete("{userId}/{movieId}")]
        public async Task<IActionResult> RemoveFavouriteMovie(int userId, int movieId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);
            Movie? movie = await _moviesRepository.GetMovieByMovieId(movieId);

            if (user != null && movie != null)
            {
                bool successfullyDeleted = await _favouriteMoviesRepository.RemoveFavouriteMovie(userId, movieId);

                if (successfullyDeleted)
                {
                    return NoContent();
                }

                return Problem(detail: "Film is not in favourites.", statusCode: 400);
            }

            return Problem(detail: "No found user or movie.", statusCode: 400);
        }
    }
}
