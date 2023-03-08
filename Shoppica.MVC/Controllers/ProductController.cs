using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.MVC.ViewModels;

namespace Shoppica.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts(int id)
        {
            var response = GlobalConfig.webClient.GetAsync("Product/" + id).Result;
            // https://localhost:7113/api/category
            var json = response.Content.ReadAsStringAsync().Result;
            List<ProductVM> productVMs = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productVMs);
        }
        public IActionResult GetProducts2(int id)
        {
            var response = GlobalConfig.webClient.GetAsync("Product/" + id).Result;
            // https://localhost:7113/api/category
            var json = response.Content.ReadAsStringAsync().Result;
            List<ProductVM> productVMs = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productVMs);
        }
        public IActionResult GetProductDetails(int id)
        {
            var response = GlobalConfig.webClient.GetAsync("ProductDetails/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            ProductVM productVM = JsonConvert.DeserializeObject<ProductVM>(json);
            return View(productVM);
        }
        public IActionResult GetSearch(string text)
        {
            var response = GlobalConfig.webClient.GetAsync("ProductSearch/" + text).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            List<ProductVM> productVMs = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productVMs);
        }
    }
}
