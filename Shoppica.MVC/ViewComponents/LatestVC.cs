using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class LatestVC:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // 6 adet random product.
            var response = GlobalConfig.webClient.GetAsync("ContentProduct/3").Result; // .../api/ContentProduct/3
            var json = response.Content.ReadAsStringAsync().Result;
            List<ProductVM> productVMs = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productVMs);
        }
    }
}
