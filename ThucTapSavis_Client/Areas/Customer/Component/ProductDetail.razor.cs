using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using ThucTapSavis_Client.Areas.Customer.Controllers;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
	public partial class ProductDetail
	{
		private HttpClient _client = new HttpClient();
		[Inject] private NavigationManager _navigation { get; set; }
		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		private List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		private List<Image_Join_ProductItem> _lstImg_PI = new List<Image_Join_ProductItem>();
		private List<Image_Join_ProductItem> _lstImg_PI_tam = new List<Image_Join_ProductItem>();
		private List<Product_VM> _lstP = new List<Product_VM>();
		private List<CartItem_VM> _lstCI = new List<CartItem_VM>();
		private List<string> _lstColor = new List<string>();
		private List<string> _lstSize = new List<string>();
		private ProductItem_Show_VM? _pi_S_VM = new ProductItem_Show_VM();
		private Product_VM _p_vm = new Product_VM();
		public string _path_Tam { get; set; }
		public string _nameCate { get; set; }
		public int? _giaMin { get; set; }
		public int? _giaMax { get; set; }
		public string _gia { get; set; }
		public int _soLuong { get; set; } = 1;
		public int? _soluongton { get; set; } = 0;
		public string _chonMau { get; set; } = string.Empty;
		public string _chonSize { get; set; } = string.Empty;
		private User_VM? _user_vm { get; set; }
		public string? _iduser { get; set; }
		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
		private ISession? _ss { get; set; }
		public int _sttSize { get; set; }
		public int _sttMau { get; set; }
		List<string> _lstSizeSample = new List<string> { "XS", "S", "M", "L", "XL", "2XL", "3XL", "4XL", "5XL" };

		private void SapXepSize<T>(List<T> listToSort, List<T> referenceList)
		{
			// Sắp xếp danh sách để giống với danh sách tham chiếu
			listToSort.Sort((a, b) =>
			{
				int indexA = referenceList.IndexOf(a);
				int indexB = referenceList.IndexOf(b);
				return indexA.CompareTo(indexB);
			});
		}
		protected override async Task OnInitializedAsync()
		{
			_ss = _ihttpcontextaccessor.HttpContext.Session;
			_user_vm = SessionServices.GetUserFromSession_User_VM(_ss, "User");
			_iduser = _user_vm.Id.ToString();
			if (_iduser == "00000000-0000-0000-0000-000000000000") _iduser = null;
			_lstPrI_show_VM = (await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show")).Where(c => c.ProductId == BanOnlineController._idP).ToList();
			_p_vm = await _client.GetFromJsonAsync<Product_VM>($"https://localhost:7264/api/Product/{BanOnlineController._idP}");
			_lstImg_PI = (await _client.GetFromJsonAsync<List<Image_Join_ProductItem>>("https://localhost:7264/api/image/get_Image_Join_PI")).Where(c => c.ProductId == BanOnlineController._idP).ToList();
			_lstImg_PI_tam = _lstImg_PI; // Ảnh tạm
			_path_Tam = _lstImg_PI_tam.OrderBy(c => c.STT).Select(c => c.PathImage).FirstOrDefault();
			_nameCate = (await _client.GetFromJsonAsync<Category_VM>($"https://localhost:7264/api/category/get_category_by_id/{_p_vm.CategoryId}")).Name;
			_giaMin = _lstPrI_show_VM.Min(c => c.CostPrice);
			_giaMax = _lstPrI_show_VM.Max(c => c.CostPrice);
			_gia = _giaMin < _giaMax ? _giaMin?.ToString("#,##0") + "đ - " + _giaMax?.ToString("#,##0") + "đ" : _giaMax?.ToString("#,##0") + "đ";
			_lstColor = _lstPrI_show_VM.Select(c => c.ColorName).Distinct().ToList();
			_lstSize = _lstPrI_show_VM.Select(c => c.SizeName).Distinct().ToList();
			SapXepSize(_lstSize, _lstSizeSample);
			var a = _lstSize;
			foreach (var item in _lstPrI_show_VM)
			{
				_soluongton += item.AvaiableQuantity;
			}
		}

		public async Task LoadAnh(Guid ID)
		{
			_path_Tam = _lstImg_PI.FirstOrDefault(c => c.Id == ID).PathImage;
		}

		public async Task SL_Cong()
		{
			if (_soLuong == 99) return;
			_soLuong += 1;
		}

		public async Task SL_Tru()
		{
			if (_soLuong == 1) return;
			_soLuong -= 1;
		}

		public void ChonMau(string mau)
		{
			if (_chonSize == string.Empty)
			{
				_chonMau = mau;
				var lsttam = new List<Image_Join_ProductItem>();
				var lst_chonmau = _lstPrI_show_VM.Where(c => c.ColorName == mau).ToList();
				_soluongton = 0;
				foreach (var x in lst_chonmau)
				{
					var a = _lstImg_PI.Where(c => c.ProductItemId == x.Id);
					lsttam.AddRange(a);
					_soluongton += x.AvaiableQuantity;
				}
				_lstImg_PI_tam = lsttam;
				_path_Tam = lsttam.OrderBy(c => c.STT).Select(c => c.PathImage).FirstOrDefault();
				_gia = _giaMin < _giaMax ? _giaMin?.ToString("#,##0") + "đ - " + _giaMax?.ToString("#,##0") + "đ" : _giaMax?.ToString("#,##0") + "đ";
			}
			else
			{
				_chonMau = mau;
				var lsttam = new List<Image_Join_ProductItem>();
				var lst_chonmau = _lstPrI_show_VM.Where(c => c.ColorName == mau).ToList();
				_soluongton = 0;
				foreach (var x in lst_chonmau)
				{
					var a = _lstImg_PI.Where(c => c.ProductItemId == x.Id);
					lsttam.AddRange(a);
				}
				_lstImg_PI_tam = lsttam;
				_path_Tam = lsttam.OrderBy(c => c.STT).Select(c => c.PathImage).FirstOrDefault();
				_pi_S_VM = _lstPrI_show_VM.Where(c => c.ColorName == _chonMau && c.SizeName == _chonSize).FirstOrDefault();
				if (_pi_S_VM == null)
				{
					_gia = "0đ";
					_soluongton = 0;
					_toastService.ShowError("Biến thể không tồn tại, vui lòng chọn biến thể khác");
					return;
				}
				_gia = _pi_S_VM.CostPrice?.ToString("#,##0") + "đ";
				_soluongton = 0;
				_soluongton = _pi_S_VM.AvaiableQuantity;
			}
			
			//_lstSize.Clear();
			//_lstSize = lst_chonmau.Select(c => c.SizeName).Distinct().ToList();
		}

		public async Task ChonSize(string size)
		{
			_chonSize = size;
			_pi_S_VM = _lstPrI_show_VM.Where(c => c.ColorName == _chonMau && c.SizeName == _chonSize).FirstOrDefault();
			if (_pi_S_VM==null)
			{
				_gia = "0đ";
				_soluongton = 0;
				_toastService.ShowError("Biến thể không tồn tại, vui lòng chọn biến thể khác");
				return;
			}
			_gia = _pi_S_VM.CostPrice?.ToString("#,##0") + "đ";
			_soluongton = 0;
			_soluongton = _pi_S_VM.AvaiableQuantity;
		}

		public async Task ThemVaoGiohang()
		{
			if (_chonSize == string.Empty || _chonMau == string.Empty)
			{
				_toastService.ShowError("Vui lòng chọn biến thể trước khi thêm sản phẩm vào giỏ");
				return;
			}
			if (_pi_S_VM==null||_pi_S_VM.AvaiableQuantity==0)
			{
				_toastService.ShowError("Biến thể đã hết hàng hoặc không tồn tại. Vui lòng chọn biến thể khác");
				return;
			}
			if (_pi_S_VM.AvaiableQuantity > 0)
			{
				if (_iduser != null)
				{
					_lstCI = await _client.GetFromJsonAsync<List<CartItem_VM>>($"https://localhost:7264/api/cartitem/get_cartitem_by_userid/{_iduser}");
					var x = _pi_S_VM; // debug
					if (_lstCI.Any(c => c.ProductItemId == _pi_S_VM.Id))
					{
						CartItem_VM ci = _lstCI.FirstOrDefault(c => c.ProductItemId == _pi_S_VM.Id);
						ci.Quantity += _soLuong;
						var request1 = await _client.PutAsJsonAsync("https://localhost:7264/api/cartitem/update_cartitem", ci);
						if (request1.IsSuccessStatusCode) _toastService.ShowSuccess("Sản phẩm đã được thêm vào giỏ hàng của bạn");
						return;
					}
					CartItem_VM cartItems = new CartItem_VM();
					cartItems.Id = Guid.NewGuid();
					cartItems.UserId = Guid.Parse(_iduser);
					cartItems.ProductItemId = _pi_S_VM.Id;
					cartItems.Quantity = _soLuong;
					cartItems.Status = 1;
					var request2 = await _client.PostAsJsonAsync("https://localhost:7264/api/cartitem/add_cartitem", cartItems);
					if (request2.IsSuccessStatusCode) _toastService.ShowSuccess("Sản phẩm đã được thêm vào giỏ hàng của bạn");
				}
				if (_iduser == null)
				{
					_lstCI = SessionServices.GetLstFromSession_LstCI(_ss, "_lstCI_Vanglai");
					var x = _pi_S_VM; // debug
					if (_lstCI.Any(c => c.ProductItemId == _pi_S_VM.Id))
					{
						CartItem_VM ci = _lstCI.FirstOrDefault(c => c.ProductItemId == _pi_S_VM.Id);
						ci.Quantity += _soLuong;
						var luuss1 = SessionServices.SetLstFromSession_LstCI(_ss, "_lstCI_Vanglai", _lstCI);
						if (luuss1 == true)
						{
							_toastService.ShowSuccess("Sản phẩm đã được thêm vào giỏ hàng của bạn");
							return;
						}
						else
						{
							_toastService.ShowError("Đã có lỗi xảy ra");
							return;
						}
					}
					CartItem_VM cartItems = new CartItem_VM
					{
						Id = Guid.NewGuid(),
						UserId = Guid.Parse("8031befc-4dec-4df3-8387-5f759c253d7d"),
						ProductItemId = _pi_S_VM.Id,
						Quantity = _soLuong,
						Status = 1
					};
					_lstCI.Add(cartItems);
					var luuss2 = SessionServices.SetLstFromSession_LstCI(_ss, "_lstCI_Vanglai", _lstCI);
					if (luuss2 == true)
					{
						_toastService.ShowSuccess("Sản phẩm đã được thêm vào giỏ hàng của bạn");
						return;
					}
					else
					{
						_toastService.ShowError("Đã có lỗi xảy ra");
						return;
					}
				}
			}
		}
	}
}
