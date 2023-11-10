﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        HttpClient _client = new HttpClient();

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

        [HttpPost]
        public async Task<IActionResult> Login(User_VM user)
        {

            List<User> a = await _client.GetFromJsonAsync<List<User>>("https://localhost:7264/api/User/get-user");
            User b = a.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
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
        
    }
}