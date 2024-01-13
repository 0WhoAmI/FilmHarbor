using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FilmHarbor.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly FilmHarborDbContext _dbContext;

        public CategoriesRepository(FilmHarborDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByCategoryId(int categoryId)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
        }

        public async Task<Category?> GetCategoryByCategoryName(string categoryName)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(category => category.Name == categoryName);
        }
    }
}
