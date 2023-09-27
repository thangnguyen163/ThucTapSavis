using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_API.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
