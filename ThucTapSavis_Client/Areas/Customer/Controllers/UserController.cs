using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BillByUser()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult BillItemByBill()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
