using FilmHarbor.Core.Entities;

namespace FilmHarbor.Core.RepositoryContracts
{
    /// <summary>
    /// Represents data acces logic for managing Category entity
    /// </summary>
    public interface ICategoriesRepository
    {
        /// <summary>
        /// Returns all categories in data store
        /// </summary>
        /// <returns>All categories from the table</returns>
        Task<List<Category>> GetAllCategories();

        /// <summary>
        /// Returns a category object based on the given category id; otherwise, it returns null
        /// </summary>
        /// <param name="categoryId">CategoryId to search</param>
        /// <returns>Matching category or null</returns>
        Task<Category?> GetCategoryByCategoryId(int categoryId);

        /// <summary>
        /// Returns a category object based on the given category name; otherwise, it returns null
        /// </summary>
        /// <param name="categoryName">CategoryName to search</param>
        /// <returns>Matching category or null</returns>
        Task<Category?> GetCategoryByCategoryName(string categoryName);
    }
}
