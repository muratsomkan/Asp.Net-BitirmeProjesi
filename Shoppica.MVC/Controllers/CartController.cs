using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;
using System.Text;

namespace Shoppica.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var response = GlobalConfig.webClient.GetAsync("Cart").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            List<CartProdVM> carts = JsonConvert.DeserializeObject<List<CartProdVM>>(json);
            return View(carts);
        }

        public async Task<IActionResult> CartAdd(int id, int quan = 1)
        {
            CartVM cartVM = new CartVM() { ProductId = id, Quantity = quan };
            try
            {
                var c = JsonConvert.SerializeObject(cartVM);
                StringContent content = new StringContent(c, Encoding.UTF8, "application/json");
                var response = await GlobalConfig.webClient.PostAsync("Cart", content);
                return RedirectToAction("Index", "Cart");
            }
            catch
            {
                return View(cartVM);
            }
        }

        public async Task<IActionResult> CartDelete(int id)
        {
            var response = await GlobalConfig.webClient.DeleteAsync("Cart/" + id);
            return RedirectToAction("index", "cart");
        }
    }
}
