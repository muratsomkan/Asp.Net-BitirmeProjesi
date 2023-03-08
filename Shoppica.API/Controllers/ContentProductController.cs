using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentProductController : ControllerBase
    {
        ProductService ps = new ProductService();

        [HttpGet("{id}")]
        public IEnumerable<Product> GetContentProducts(int id)
        {
            return ps.GetContentProducts(id);
        }
    }
}
