using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.API.Models;
using Shoppica.API.Services;

namespace Shoppica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        CartService cs = new CartService();

        [HttpGet]
        public IEnumerable<CartProd> Get()
        {
            return cs.GetAll();
        }
        [HttpPost]
        public void Post(Cart cart)
        {
            cs.AddToCart(cart);
        }

        //[HttpPost]
        //[Route("delete")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cs.DeleteToCart(id);
        } 
    }
}
