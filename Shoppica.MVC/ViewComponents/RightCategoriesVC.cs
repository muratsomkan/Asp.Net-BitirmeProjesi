using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.ViewComponents
{
    public class RightCategoriesVC : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var response = GlobalConfig.webClient.GetAsync("Category").Result; // .../api/category
            var json = response.Content.ReadAsStringAsync().Result;
            List<CategoryVM> categoryVMs = JsonConvert.DeserializeObject<List<CategoryVM>>(json);
            ViewBag.Top = id;
            return View(categoryVMs);
        }
    }
}
