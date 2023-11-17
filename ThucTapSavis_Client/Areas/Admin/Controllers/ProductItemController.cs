using Microsoft.AspNetCore.Mvc;

namespace ThucTapSavis_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductItemController : Controller
	{
		[Route("product-item-manager")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
