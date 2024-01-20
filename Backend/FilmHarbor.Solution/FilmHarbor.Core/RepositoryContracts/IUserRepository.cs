using FilmHarbor.Core.Entities;

namespace FilmHarbor.Core.RepositoryContracts
{
    /// <summary>
    /// Represents data acces logic for managing User entity
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Returns all users in data store
        /// </summary>
        /// <returns>All users from the table</returns>
        Task<List<User>> GetAllUsers();

        /// <summary>
        /// Returns a user object based on the given user id; otherwise, it returns null
        /// </summary>
        /// <param name="userId">UserId to search</param>
        /// <returns>Matching user or null</returns>
        Task<User?> GetUserByUserId(int userId);

        /// <summary>
        /// Adds a new user object to the data store
        /// </summary>
        /// <param name="user"> User object to add</param>
        /// <returns>Returns the user object after adding it to the data store</returns>
        Task<User> AddUser(User user);

        /// <summary>
        /// Delete a user from the data store based on user id
        /// </summary>
        /// <param name="userId"> User id to delete</param>
        /// <returns>Returns true, if the deletion is successful; otherwise false</returns>
        Task<bool> DeleteUser(int userId);

        /// <summary>
        /// Update a exiting user object in the data store
        /// </summary>
        /// <param name="user"> User object to update</param>
        /// <returns>Returns the update user object</returns>
        Task<User> UpdateUser(User user);
    }
}
