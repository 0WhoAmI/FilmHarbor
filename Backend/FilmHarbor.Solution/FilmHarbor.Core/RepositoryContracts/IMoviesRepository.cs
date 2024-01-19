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

        /// <summary>
        /// Adds a new movie object to the data store
        /// </summary>
        /// <param name="movie"> Movie object to add</param>
        /// <returns>Returns the movie object after adding it to the data store</returns>
        Task<Movie> AddMovie(Movie movie);

        /// <summary>
        /// Delete a movie from the data store based on movie id
        /// </summary>
        /// <param name="movieId"> Movie id to delete</param>
        /// <returns>Returns true, if the deletion is successful; otherwise false</returns>
        Task<bool> DeleteMovie(int movieId);

        /// <summary>
        /// Update a exiting movie object in the data store
        /// </summary>
        /// <param name="movie"> Movie object to update</param>
        /// <returns>Returns the update movie object</returns>
        Task<Movie> UpdateMovie(Movie movie);
    }
}
