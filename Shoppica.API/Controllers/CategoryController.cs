using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService cs = new CategoryService();

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return cs.GetMainCategories();
        }

        [HttpGet("{id}")]
        public IEnumerable<Category> GetAltCategory(int id)
        {
            return cs.GetByID(id);
        }

    }
}
