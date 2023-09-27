using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_API.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
