using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThuocTinhController : Controller
    {
        public IActionResult Category()
        {
            User_VM _user_VM = SessionServices.GetUserFromSession_User_VM(HttpContext.Session, "User");
            if (_user_VM.IdRole != Guid.Parse("c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf"))
            {
                return RedirectToAction("BadRequest", "Home", new { Area = "Admin" });
            }
            return View();
        }
        public IActionResult Color()
        {
            User_VM _user_VM = SessionServices.GetUserFromSession_User_VM(HttpContext.Session, "User");
            if (_user_VM.IdRole != Guid.Parse("c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf"))
            {
                return RedirectToAction("BadRequest", "Home", new { Area = "Admin" });
            }
            return View();
        }
        public IActionResult Size()
        {
            User_VM _user_VM = SessionServices.GetUserFromSession_User_VM(HttpContext.Session, "User");
            if (_user_VM.IdRole != Guid.Parse("c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf"))
            {
                return RedirectToAction("BadRequest", "Home", new { Area = "Admin" });
            }
            return View();
        }
        public IActionResult Product()
        {
            User_VM _user_VM = SessionServices.GetUserFromSession_User_VM(HttpContext.Session, "User");
            if (_user_VM.IdRole != Guid.Parse("c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf"))
            {
                return RedirectToAction("BadRequest", "Home", new { Area = "Admin" });
            }
            return View();
        }
    }
}
