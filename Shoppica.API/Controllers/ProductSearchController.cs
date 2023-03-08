using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSearch : ControllerBase
    {
        ProductService ps = new ProductService();

        [HttpGet("{text}")]
        public IEnumerable<Product> GetSearchProducts(string text)
        {
            return ps.SearchProducts(text);
        }
    }
}
