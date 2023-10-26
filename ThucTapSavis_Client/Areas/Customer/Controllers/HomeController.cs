using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
