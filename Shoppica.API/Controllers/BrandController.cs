using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        BrandService bs = new BrandService();

        [HttpGet]
        public IEnumerable<Brand> GetBrands()
        {
            return bs.GetAll();
        }
    }
}
