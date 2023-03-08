using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class CartListVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.webClient.GetAsync("Cart/").Result; // .../api/cart
            var json = response.Content.ReadAsStringAsync().Result;
            List<CartProdVM> cartProdVMs = JsonConvert.DeserializeObject<List<CartProdVM>>(json);
            return View(cartProdVMs);
        }
    }
}
