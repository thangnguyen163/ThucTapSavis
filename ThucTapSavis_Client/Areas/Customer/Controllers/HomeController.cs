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
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Bill()
        {
            return View();
        }
        public IActionResult BillDetail()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult ShowAllProduct()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
