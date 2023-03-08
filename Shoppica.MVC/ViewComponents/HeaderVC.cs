using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;
using System.Collections.Generic;

namespace Shoppica.MVC.ViewComponents
{
    public class HeaderVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.webClient.GetAsync("Category").Result; 
            // https://localhost:7113/api/category
            var json = response.Content.ReadAsStringAsync().Result;
            List<CategoryVM> categoryVMs = JsonConvert.DeserializeObject<List<CategoryVM>>(json);
            return View(categoryVMs);
        }
    }
}
