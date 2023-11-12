using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;
using Microsoft.AspNetCore.Components;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
	public partial class ShowCart
	{
		private HttpClient _client = new HttpClient();
		[Inject] private NavigationManager _navi { get; set; }
		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
		private List<CartItem_VM> _lstCI = new List<CartItem_VM>();
		private List<Image_Join_ProductItem> _lstImg_PI = new List<Image_Join_ProductItem>();
		private List<Image_Join_ProductItem> _lstImg_PI_tam = new List<Image_Join_ProductItem>();
		private List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		private ProductItem_Show_VM? _pi_s_vm = new ProductItem_Show_VM();
		public int? _tongTien { get; set; } = 0;
		public string? _idUser { get; set; } = string.Empty;
		public static string? _note { get; set; } = string.Empty;
        private User_VM? _user_vm { get; set; }
        protected override async Task OnInitializedAsync()
		{
            _user_vm = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
            _idUser = _user_vm.Id.ToString();
			if (_idUser == "00000000-0000-0000-0000-000000000000") _idUser = null;
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			if (_idUser == null) _lstCI = SessionServices.GetLstFromSession_LstCI(_ihttpcontextaccessor.HttpContext.Session, "_lstCI_Vanglai");
			else _lstCI = await _client.GetFromJsonAsync<List<CartItem_VM>>($"https://localhost:7264/api/cartitem/get_cartitem_by_userid/{_idUser}");
			_lstImg_PI = (await _client.GetFromJsonAsync<List<Image_Join_ProductItem>>("https://localhost:7264/api/image/get_Image_Join_PI")).OrderBy(c => c.STT).ToList();
			foreach (var x in _lstCI)
			{
				_pi_s_vm = _lstPrI_show_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
				_tongTien += x.Quantity * _pi_s_vm.CostPrice;
			}
			_note = string.Empty;
		}

		public async Task SL_Cong(CartItem_VM ci)
		{

			if (_idUser == null)
			{
				if (ci.Quantity == 99) return;
				_lstCI.Remove(ci);
				ci.Quantity += 1;
				_lstCI.Add(ci);
				SessionServices.SetLstFromSession_LstCI(_ihttpcontextaccessor.HttpContext.Session, "_lstCI_Vanglai", _lstCI);
			}
			else
			{
				if (ci.Quantity == 99) return;
				ci.Quantity += 1;
				await _client.PutAsJsonAsync("https://localhost:7264/api/cartitem/update_cartitem", ci);
			}
			_tongTien = 0;
			foreach (var x in _lstCI)
			{
				_pi_s_vm = _lstPrI_show_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
				_tongTien += x.Quantity * _pi_s_vm.CostPrice;
			}
		}

		public async Task SL_Tru(CartItem_VM ci)
		{
			if (_idUser == null)
			{
				if (ci.Quantity == 1) return;
				_lstCI.Remove(ci);
				ci.Quantity -= 1;
				_lstCI.Add(ci);
				SessionServices.SetLstFromSession_LstCI(_ihttpcontextaccessor.HttpContext.Session, "_lstCI_Vanglai", _lstCI);
			}
			else
			{
				if (ci.Quantity == 1) return;
				ci.Quantity -= 1;
				await _client.PutAsJsonAsync("https://localhost:7264/api/cartitem/update_cartitem", ci);
			}
			_tongTien = 0;
			foreach (var x in _lstCI)
			{
				_pi_s_vm = _lstPrI_show_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
				_tongTien += x.Quantity * _pi_s_vm.CostPrice;
			}
		}

		public async Task DeleteCI(CartItem_VM ci)
		{
			if (_idUser == null)
			{
				_lstCI.Remove(ci);
				SessionServices.SetLstFromSession_LstCI(_ihttpcontextaccessor.HttpContext.Session, "_lstCI_Vanglai", _lstCI);
				_toastService.ShowSuccess("Sản phẩm đã được xóa khỏi giỏ hàng của bạn");
			}
			else
			{
				var delete = await _client.DeleteAsync($"https://localhost:7264/api/cartitem/delete_cartitem/{ci.Id}");
				_lstCI = await _client.GetFromJsonAsync<List<CartItem_VM>>($"https://localhost:7264/api/cartitem/get_cartitem_by_userid/{_idUser}");
				_toastService.ShowSuccess("Sản phẩm đã được xóa khỏi giỏ hàng của bạn");
			}
			_tongTien = 0;
			foreach (var x in _lstCI)
			{
				_pi_s_vm = _lstPrI_show_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
				_tongTien += x.Quantity * _pi_s_vm.CostPrice;
			}
		}

		public async Task CreateBill()
		{
			if (_tongTien == 0)
			{
				_toastService.ShowError("Giỏ hàng không có sản phẩm nào vui lòng chọn thêm sản phẩm");
				return;
			}
			_navi.NavigateTo("https://localhost:7022/bill-info", true);
		}

		public async Task MuaHang()
		{
			_navi.NavigateTo("https://localhost:7022/all-product", true);
		}
	}
}