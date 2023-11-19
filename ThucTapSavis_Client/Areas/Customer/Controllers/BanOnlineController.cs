using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text;
using ThucTapSavis_Shared.ViewModel;
using ThucTapSavis_Shared.ViewModel.Momo;
using X.PagedList;

namespace ThucTapSavis_Client.Areas.Customer.Controllers
{
	[Area("Customer")]
	public class BanOnlineController : Controller
	{
		private HttpClient _client = new HttpClient();
		private List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		private List<Product_VM> _lstP = new List<Product_VM>();
		private List<Product_VM> _lstP_Tam1 = new List<Product_VM>();
		private List<Category_VM> _lstCate = new List<Category_VM>();
		public static List<PromotionItem_VM>? _lstpi_Percent = new List<PromotionItem_VM>();
		private Product_VM _P_Show = new Product_VM();
		public static Guid _idP;
		public static string? _mau;
		public static IPagedList<Product_VM> _pageList;
		public static MomoExecuteResponseModel _momoExecuteResponseModel = new();
		public static string _tenDanhMuc { get; set; }
		public static string _valueSearch { get; set; }
		public static int _soKQ { get; set; }
		/*----------------------------------------------------------------------------------------*/
		private string XoaDau(string text)
		{
			string normalizedString = text.Normalize(NormalizationForm.FormD);
			StringBuilder stringBuilder = new StringBuilder();

			foreach (char c in normalizedString)
			{
				UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
		}
		private void SetTenKhongDau(List<Category_VM> lst)
		{
			// Dictionary để theo dõi số lần xuất hiện của mỗi chuỗi TenKhongDau
			Dictionary<string, int> countDictionary = new Dictionary<string, int>();

			foreach (var x in lst)
			{
				string tenKhongDau = XoaDau(x.Name).Replace(" ", "-");

				// Kiểm tra xem chuỗi đã xuất hiện trước đó chưa
				if (countDictionary.ContainsKey(tenKhongDau))
				{
					// Nếu đã xuất hiện, thì thêm số thứ tự vào cuối chuỗi
					countDictionary[tenKhongDau]++;
					x.TenKhongDau = $"{tenKhongDau}-{countDictionary[tenKhongDau]}";
				}
				else
				{
					// Nếu chưa xuất hiện, thêm vào từ điển với số thứ tự là 1
					countDictionary.Add(tenKhongDau, 1);
					x.TenKhongDau = tenKhongDau;
				}
			}
		}
		/*-------------------------------------------------------------------------------------------*/
		[Route("all-product")]
		public async Task<IActionResult> ShowProduct(int? page)
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			_lstpi_Percent = await _client.GetFromJsonAsync<List<PromotionItem_VM>>($"https://localhost:7264/api/PromotionItem/getLstPromotionItem_Percent_by_productItemID");
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
			// Lấy list sp ko có spct
			foreach (var a in _lstP)
			{
				if (_lstPrI_show_VM.Any(c => c.ProductId == a.Id))
				{
					_lstP_Tam1.Add(a);
				}
			}
			// 1. Tham số int? dùng để thể hiện null và kiểu int
			// page có thể có giá trị là null và kiểu int.

			// 2. Nếu page = null thì đặt lại là 1.
			if (page == null) page = 1;
			// 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
			// theo BookID mới có thể phân trang.
			var pr = _lstP_Tam1.OrderBy(c => c.Name);
			// 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
			int pageSize = 8;

			// 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
			// nếu page = null thì lấy giá trị 1 cho biến pageNumber.
			int pageNumber = (page ?? 1);
			_pageList = pr.ToPagedList(pageNumber, pageSize);
			// 5. Trả về các Link được phân trang theo kích thước và số trang.
			return View(_pageList);
		}
		[Route("product-detail/{id}")]
		public async Task<IActionResult> ProductDetail(Guid id)
		{
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
			_P_Show = _lstP.Where(c => c.Id == id).FirstOrDefault();
			_idP = _P_Show.Id;
			return View(_P_Show);
		}
		[Route("cart")]
		public async Task<IActionResult> ShowCart()
		{
			return View();
		}

		[Route("bill-info")]
		public async Task<IActionResult> Create_Bill_With_Info()
		{
			return View();
		}

		[Route("results-after-payment")]
		public IActionResult CallBackAfterPayment()
		{
			var collection = HttpContext.Request.Query;
			_momoExecuteResponseModel.Amount = collection.First(s => s.Key == "amount").Value;
			_momoExecuteResponseModel.OrderInfo = collection.First(s => s.Key == "orderInfo").Value;
			_momoExecuteResponseModel.OrderId = collection.First(s => s.Key == "orderId").Value;
			_momoExecuteResponseModel.Message = collection.First(s => s.Key == "message").Value;
			_momoExecuteResponseModel.MessageLocal = collection.First(s => s.Key == "localMessage").Value;
			return View(_momoExecuteResponseModel);
		}
		[Route("all-product/{danhmuc}")]
		public async Task<IActionResult> ShowDanhMuc(int? page,string? danhmuc)
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			_lstpi_Percent = await _client.GetFromJsonAsync<List<PromotionItem_VM>>($"https://localhost:7264/api/PromotionItem/getLstPromotionItem_Percent_by_productItemID");
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
			_lstCate = await _client.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
			SetTenKhongDau(_lstCate);
			var duplicates = _lstCate
			.GroupBy(x => x.TenKhongDau)
			.Where(group => group.Count() > 1)
			.Select(group => group.Key);
			Guid _idcate = _lstCate.Where(c=>c.TenKhongDau == danhmuc).Select(c=>c.Id).FirstOrDefault();
			_lstPrI_show_VM = _lstPrI_show_VM.Where(c=>c.CategoryID == _idcate).ToList();
			_tenDanhMuc = (await _client.GetFromJsonAsync<Category_VM>($"https://localhost:7264/api/category/get_category_by_id/{_idcate}")).Name;
			// Lấy list sp ko có spct
			foreach (var a in _lstP)
			{
				if (_lstPrI_show_VM.Any(c => c.ProductId == a.Id))
				{
					_lstP_Tam1.Add(a);
				}
			}
			_soKQ = _lstP_Tam1.Count;
			// 1. Tham số int? dùng để thể hiện null và kiểu int
			// page có thể có giá trị là null và kiểu int.

			// 2. Nếu page = null thì đặt lại là 1.
			if (page == null) page = 1;
			// 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
			// theo BookID mới có thể phân trang.
			var pr = _lstP_Tam1.OrderBy(c => c.Name);
			// 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
			int pageSize = 8;

			// 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
			// nếu page = null thì lấy giá trị 1 cho biến pageNumber.
			int pageNumber = (page ?? 1);
			_pageList = pr.ToPagedList(pageNumber, pageSize);
			// 5. Trả về các Link được phân trang theo kích thước và số trang.
			return View(_pageList);
		}

		[Route("search/{search}")]
		public async Task<IActionResult> SearchProduct(int? page, string? search)
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			_lstpi_Percent = await _client.GetFromJsonAsync<List<PromotionItem_VM>>($"https://localhost:7264/api/PromotionItem/getLstPromotionItem_Percent_by_productItemID");
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
			if (search.ToLower() != XoaDau(search))
			{
				_lstPrI_show_VM = _lstPrI_show_VM.Where(c => c.Name.ToLower().Contains(search.ToLower())).ToList();
			}
			else
			{
				_lstPrI_show_VM = _lstPrI_show_VM.Where(c => XoaDau(c.Name).Contains(XoaDau(search))).ToList();
			}
			// Lấy list sp ko có spct
			foreach (var a in _lstP)
			{
				if (_lstPrI_show_VM.Any(c => c.ProductId == a.Id))
				{
					_lstP_Tam1.Add(a);
				}
			}
			_valueSearch = search;
			_soKQ = _lstP_Tam1.Count;
			// 1. Tham số int? dùng để thể hiện null và kiểu int
			// page có thể có giá trị là null và kiểu int.

			// 2. Nếu page = null thì đặt lại là 1.
			if (page == null) page = 1;
			// 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
			// theo BookID mới có thể phân trang.
			var pr = _lstP_Tam1.OrderBy(c => c.Name);
			// 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
			int pageSize = 12;

			// 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
			// nếu page = null thì lấy giá trị 1 cho biến pageNumber.
			int pageNumber = (page ?? 1);
			_pageList = pr.ToPagedList(pageNumber, pageSize);
			// 5. Trả về các Link được phân trang theo kích thước và số trang.
			return View(_pageList);
		}
	}
}
