using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly FilmHarborDbContext _dbContext;

        public MoviesRepository(FilmHarborDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieByMovieId(int movieId)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(movie => movie.Id == movieId);
        }

        public async Task<Movie?> GetMovieByMovieTitle(string movieTitle)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(movie => movie.Title == movieTitle);
        }
    }
}
