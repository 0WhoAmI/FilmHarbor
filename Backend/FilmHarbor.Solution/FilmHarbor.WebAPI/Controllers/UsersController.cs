using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly FilmHarborDbContext _dbContext;

        public UsersController(IUsersRepository usersRepository, IMoviesRepository moviesRepository, FilmHarborDbContext dbContext)
        {
            _usersRepository = usersRepository;
            _moviesRepository = moviesRepository;
            _dbContext = dbContext;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersRepository.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, User user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            User? existingUser = await _usersRepository.GetUserByUserId(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            try
            {
                User updateUser = await _usersRepository.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(userId))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            await _usersRepository.AddUser(user);

            return CreatedAtAction("GetUser", new { userId = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);
            if (user == null)
            {
                return NotFound();
            }

            await _usersRepository.DeleteUser(user.Id);

            return NoContent();
        }

        [HttpGet("favourite-movies/{userId}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetFavouriteMovies(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);

            if (user == null)
            {
                return NotFound();
            }

            return await _usersRepository.GetFavouriteMovies(userId);
        }

        [HttpPost("favourite-movies/{userId}/{movieId}")]
        public async Task<IActionResult> AddFavouriteMovie(int userId, int movieId)
        {
            await _usersRepository.AddFavouriteMovie(userId, movieId);

            return NoContent();
        }

        [HttpDelete("favourite-movies/{userId}/{movieId}")]
        public async Task<IActionResult> RemoveFavouriteMovie(int userId, int movieId)
        {
            await _usersRepository.RemoveFavouriteMovie(userId, movieId);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            List<User> users = await _usersRepository.GetAllUsers();

            return users.Any(user => user.Id == id);
        }
    }
}
