using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class BrandVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.webClient.GetAsync("Brand/").Result; // .../api/brand
            var json = response.Content.ReadAsStringAsync().Result;
            List<BrandVM> brandVMs = JsonConvert.DeserializeObject<List<BrandVM>>(json);
            return View(brandVMs);
        }
    }
}
