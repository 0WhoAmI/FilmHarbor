using FilmHarbor.Core.Entities;

namespace FilmHarbor.Core.RepositoryContracts
{
    public interface IFavouriteMoviesRepository
    {

        /// <summary>
        /// Get favourite movies from tables FavouriteMovies for user id
        /// </summary>
        /// <param name="userId">User id to search</param>
        /// <returns>Returns list of favourite movies</returns>
        Task<List<Movie>> GetFavouriteMovies(int userId);

        /// <summary>
        /// Add userId and movieId to tables FavouriteMovies
        /// </summary>
        /// <param name="userId">User id to insert</param>
        /// <param name="movieId">Movie id to insert</param>
        /// <returns>>Returns true, if the insert is successful; otherwise false</returns>
        Task<bool> AddFavouriteMovie(int userId, int movieId);

        /// <summary>
        /// Remove userId and movieId to tables FavouriteMovies
        /// </summary>
        /// <param name="userId">User id to deleted</param>
        /// <param name="movieId">Movie id to deleted</param>
        /// <returns>Returns true, if the deleted is successful; otherwise false</returns>
        Task<bool> RemoveFavouriteMovie(int userId, int movieId);
    }
}
