using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        ProductService ps = new ProductService();

        [HttpGet("{id}")]
        public Product GetProductDetails(int id)
        {
            return ps.GetDetails(id);
        }
    }
}
