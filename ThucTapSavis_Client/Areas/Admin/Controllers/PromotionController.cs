using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {     
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

    }
}
