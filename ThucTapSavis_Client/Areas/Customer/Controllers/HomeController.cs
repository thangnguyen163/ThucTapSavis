using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
