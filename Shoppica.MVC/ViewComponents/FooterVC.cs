using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class FooterVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.webClient.GetAsync("Category").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            List<CategoryVM> categoryVMs = JsonConvert.DeserializeObject<List<CategoryVM>>(json);
            return View(categoryVMs);
        }
    }
}
