using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        HttpClient _client = new HttpClient();
        public static string _nameUser {  get; set; }
        [Route("home")]
        public IActionResult Index()
        {
            HttpContext.Session.SetString($"{Guid.NewGuid()}", JsonConvert.SerializeObject(Guid.NewGuid()));
            return View();
        }
        [Route("about")]
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
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
		[Route("login")]
		[HttpPost]
        public async Task<IActionResult> Login(User_VM user)
        {
            List<User> a = await _client.GetFromJsonAsync<List<User>>("https://localhost:7264/api/User/get-user");
            User b = a.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            _nameUser = b.FullName;
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(b));
            if (b != null)
            {
                return RedirectToAction("Index", "Home", new { Area = "Customer" });
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            _nameUser = null;
            return RedirectToAction("Index");
        }
    }
}