using Microsoft.AspNetCore.Mvc;

namespace Shoppica.MVC.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
