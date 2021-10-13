using Microsoft.AspNetCore.Mvc;
using MongoSQL.API.Collections.Versions.V1.Models;
using MongoSQL.API.Services.Versions.V1;
using System.Threading.Tasks;

namespace MongoSQL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _categoryService.CreateCategory(category);

            if (result.IsError)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
