using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThuocTinhController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Color()
        {
            return View();
        }
        public IActionResult Size()
        {
            return View();
        }
    }
}
