﻿using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    public class PromotionController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
