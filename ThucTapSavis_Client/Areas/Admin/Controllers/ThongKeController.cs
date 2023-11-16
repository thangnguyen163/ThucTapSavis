using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
