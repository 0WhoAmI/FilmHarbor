using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly FilmHarborDbContext _dbContext;

        public UsersRepository(FilmHarborDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByUserId(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Name == userName);
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            _dbContext.RemoveRange(_dbContext.Users.Where(user => user.Id == userId));
            int rowsDeleted = await _dbContext.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<User> UpdateUser(User user)
        {
            User? matchingUser = await _dbContext.Users.FirstOrDefaultAsync(m => m.Id == user.Id);

            if (matchingUser == null)
            {
                return user;
            }

            matchingUser.Name = user.Name;
            matchingUser.Password = user.Password;
            matchingUser.Email = user.Email;

            int rowsUpdated = await _dbContext.SaveChangesAsync();

            return matchingUser;
        }

        public async Task<List<Movie>> GetFavouriteMovies(int userId)
        {
            int[] movieIds = _dbContext.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavouriteMovies.Select(fm => fm.Id))
                .ToArray();

            List<Movie> movies = await _dbContext.Movies
                .Where(movie => movieIds.Contains(movie.Id))
                .ToListAsync();

            return movies;
        }

        public async Task<bool> AddFavouriteMovie(int userId, int movieId)
        {
            User? user = await _dbContext.Users.Include(u => u.FavouriteMovies).FirstOrDefaultAsync(u => u.Id == userId);
            Movie? movie = await _dbContext.Movies.FindAsync(movieId);

            if (user != null && movie != null)
            {
                // Sprawdź, czy film już nie jest ulubiony, aby uniknąć duplikatów
                if (!user.FavouriteMovies.Any(fm => fm.Id == movieId))
                {
                    user.FavouriteMovies.Add(movie);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> RemoveFavouriteMovie(int userId, int movieId)
        {
            User? user = await _dbContext.Users.Include(u => u.FavouriteMovies).FirstOrDefaultAsync(u => u.Id == userId);
            Movie? movie = await _dbContext.Movies.FindAsync(movieId);

            if (user != null && movie != null)
            {
                // Usuń film tylko jeśli istnieje na liście ulubionych
                Movie? movieToRemove = user.FavouriteMovies.FirstOrDefault(fm => fm.Id == movieId);
                if (movieToRemove != null)
                {
                    user.FavouriteMovies.Remove(movieToRemove);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
