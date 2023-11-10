using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BillDetail()
        {
            return View();
        }
    }
}
