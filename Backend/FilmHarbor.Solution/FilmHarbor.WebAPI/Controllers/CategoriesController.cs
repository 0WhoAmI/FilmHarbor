using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;

namespace FilmHarbor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoriesRepository.GetAllCategories();
        }

        // GET: api/Categories/5
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            Category? category = await _categoriesRepository.GetCategoryByCategoryId(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{categoryId}")]
        public Task<IActionResult> PutCategory(int categoryId, Category category)
        {
            throw new NotImplementedException();
        }

        // POST: api/Categories
        [HttpPost]
        public Task<ActionResult<Category>> PostCategory(Category category)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{categoryId}")]
        public Task<IActionResult> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
