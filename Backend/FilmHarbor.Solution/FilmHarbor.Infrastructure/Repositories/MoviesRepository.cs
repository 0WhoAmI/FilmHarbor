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

        public async Task<Movie> AddMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteMovie(int movieId)
        {
            _dbContext.RemoveRange(_dbContext.Movies.Where(movie => movie.Id == movieId));
            int rowsDeleted = await _dbContext.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            Movie? matchingMovie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);

            if (matchingMovie == null)
            {
                return movie;
            }

            matchingMovie.Title = movie.Title;
            matchingMovie.CategoryId = movie.CategoryId;
            matchingMovie.ReleaseYear = movie.ReleaseYear;
            matchingMovie.ImageUrl = movie.ImageUrl;
            matchingMovie.Description = movie.Description;

            int rowsUpdated = await _dbContext.SaveChangesAsync();

            return matchingMovie;
        }
    }
}
