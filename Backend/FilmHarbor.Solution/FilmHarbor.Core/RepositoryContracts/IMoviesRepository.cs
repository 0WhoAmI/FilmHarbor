using FilmHarbor.Core.Entities;

namespace FilmHarbor.Core.RepositoryContracts
{
    /// <summary>
    /// Represents data acces logic for managing Movie entity
    /// </summary>
    public interface IMoviesRepository
    {
        /// <summary>
        /// Returns all movies in data store
        /// </summary>
        /// <returns>All movies from the table</returns>
        Task<List<Movie>> GetAllMovies();

        /// <summary>
        /// Returns a movie object based on the given movie id; otherwise, it returns null
        /// </summary>
        /// <param name="movieId">MovieId to search</param>
        /// <returns>Matching movie or null</returns>
        Task<Movie?> GetMovieByMovieId(int movieId);

        /// <summary>
        /// Returns a movie object based on the given movie title; otherwise, it returns null
        /// </summary>
        /// <param name="movieTitle">MovieTitle to search</param>
        /// <returns>Matching movie or null</returns>
        Task<Movie?> GetMovieByMovieTitle(string movieTitle);

        //TODO: AddMovie()

        //TODO: DeleteMovie()

        //TODO: UpdateMovie()
    }
}
