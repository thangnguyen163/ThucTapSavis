using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_API.Controllers
{
    public class BillController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
