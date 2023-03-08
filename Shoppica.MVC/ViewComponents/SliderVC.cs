using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class SliderVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // 5 adet random product.
            var response = GlobalConfig.webClient.GetAsync("ContentProduct/1").Result; // .../api/ContentProduct/1
            var json = response.Content.ReadAsStringAsync().Result;
            List<ProductVM> productVMs = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productVMs);
        }
    }
}
