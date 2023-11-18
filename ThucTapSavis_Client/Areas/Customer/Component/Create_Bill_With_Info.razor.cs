using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;
using ThucTapSavis_Shared.ViewModel.DiaChi;
using ThucTapSavis_Shared.ViewModel.Momo;
using ThucTapSavis_Shared.ViewModel.Momo.Order;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
	public partial class Create_Bill_With_Info
	{
		private HttpClient _httpClient = new HttpClient();
		[Inject] private NavigationManager _navi { get; set; }
		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
		private List<CartItem_VM> _lstCI = new List<CartItem_VM>();
		private List<Image_Join_ProductItem> _lstImg_PI = new List<Image_Join_ProductItem>();
		private List<Image_Join_ProductItem> _lstImg_PI_tam = new List<Image_Join_ProductItem>();
		private List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		public static Bill_VM _bill_vm;
		private User_VM? _user_vm = new User_VM();
		private ProductItem_Show_VM _pi_s_vm = new ProductItem_Show_VM();
		private OrderInfoModel _ord = new OrderInfoModel();
		private ProductItem_VM _pi_vm = new ProductItem_VM();
		public string _sdt { get; set; }
		public int? _tongTienHang { get; set; } = 0;
		public int? _tongTienAll { get; set; } = 0;
		private List<Province_VM> _lstTinhTp = new List<Province_VM>();
		private List<District_VM> _lstQuanHuyen = new List<District_VM>();
		private List<Ward_VM> _lstXaPhuong = new List<Ward_VM>();
		private List<Province_VM> _lstTinhTp_Data = new List<Province_VM>();
		private List<District_VM> _lstQuanHuyen_Data = new List<District_VM>();
		private List<Ward_VM> _lstXaPhuong_Data = new List<Ward_VM>();
		private List<Bill_VM> _lstBill = new List<Bill_VM>();
		private List<ProductItem_VM> _lstPrI_VM = new List<ProductItem_VM>();
		public string _TinhTp { get; set; }
		public string _QuanHuyen { get; set; }
		public string _ptttbill1 { get; set; }
		public string _ptttbill2 { get; set; }
		public int STT { get; set; } = 0;
		public string? _iduser { get; set; }
		protected override async Task OnInitializedAsync()
		{
			_user_vm = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
			_iduser = _user_vm.Id.ToString();
			if (_iduser == "00000000-0000-0000-0000-000000000000") _iduser = null;

			_bill_vm = new Bill_VM();
			_lstPrI_show_VM = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");


			_lstImg_PI = (await _httpClient.GetFromJsonAsync<List<Image_Join_ProductItem>>("https://localhost:7264/api/image/get_Image_Join_PI")).OrderBy(c => c.STT).ToList();
			_lstTinhTp_Data = await _httpClient.GetFromJsonAsync<List<Province_VM>>("https://api.npoint.io/ac646cb54b295b9555be"); // api tỉnh tp
			_lstTinhTp = _lstTinhTp_Data;
			_lstQuanHuyen_Data = await _httpClient.GetFromJsonAsync<List<District_VM>>("https://api.npoint.io/34608ea16bebc5cffd42");
			_lstXaPhuong_Data = await _httpClient.GetFromJsonAsync<List<Ward_VM>>("https://api.npoint.io/dd278dc276e65c68cdf5");
			_lstPrI_VM = await _httpClient.GetFromJsonAsync<List<ProductItem_VM>>("https://localhost:7264/api/ProductItem");
			if (_iduser == null)
			{
				_bill_vm.UserId = Guid.Parse("8031befc-4dec-4df3-8387-5f759c253d7d");
				_lstCI = SessionServices.GetLstFromSession_LstCI(_ihttpcontextaccessor.HttpContext.Session, "_lstCI_Vanglai");
				_bill_vm.SDTNhan = string.Empty;
				_bill_vm.TenNguoiNhan = string.Empty;
				_bill_vm.DiaChiCuThe = string.Empty;
				_bill_vm.Tinh = string.Empty;
				_bill_vm.Huyen = string.Empty;
				_bill_vm.Xa = string.Empty;
			}
			else
			{
				_bill_vm.UserId = Guid.Parse(_iduser);
				_user_vm = await _httpClient.GetFromJsonAsync<User_VM>($"https://localhost:7264/api/User/{_iduser}");
				_lstCI = await _httpClient.GetFromJsonAsync<List<CartItem_VM>>($"https://localhost:7264/api/cartitem/get_cartitem_by_userid/{_bill_vm.UserId}");
				_bill_vm.SDTNhan = _user_vm.NumberPhone;
				_bill_vm.TenNguoiNhan = _user_vm.FullName;
				_bill_vm.DiaChiCuThe = _user_vm.DiaChiCuThe;
				// Tự gen
				_bill_vm.Tinh = _user_vm.Tinh;
				await ChonTinhTP();
				_bill_vm.Huyen = _user_vm.Huyen;
				await ChonQuanHuyen();
				_bill_vm.Xa = _user_vm.Xa;
			}
			_bill_vm.PhuongThucTT = "Thanh toán khi nhận hàng (COD)";
			_bill_vm.Note = ShowCart._note;
			_bill_vm.PhiShip = 30000;
			foreach (var x in _lstCI)
			{
				_pi_s_vm = _lstPrI_show_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
				_tongTienHang += x.Quantity * _pi_s_vm.PriceAfterReduction;
			}
			_tongTienAll = _tongTienHang + _bill_vm.PhiShip;
		}

		//public Guid Id { get; set; }
		//public Guid UserId { get; set; }
		//public Guid? HistoryConsumerPointID { get; set; }
		//public Guid PaymentMethodId { get; set; }
		//public Guid? VoucherId { get; set; }
		//public string BillCode { get; set; }
		//public int? TotalAmount { get; set; }
		//public int? ReducedAmount { get; set; }
		//public int? Cash { get; set; }  // tiền mặt
		//public int? CustomerPayment { get; set; } // tiền khách đưa
		//public int? FinalAmount { get; set; } // tiền khách đưa
		//public DateTime? CreateDate { get; set; }
		//public DateTime? ConfirmationDate { get; set; }
		//public DateTime? CompletionDate { get; set; }
		//public int Type { get; set; }
		//public string? Note { get; set; }
		//public string Recipient { get; set; } // Người nhận
		//public string District { get; set; } // Quận/Huyện
		//public string Province { get; set; } // Tỉnh/ TP
		//public string WardName { get; set; } // Phường/ Xã
		//public string ToAddress { get; set; } // Địa chỉ chi tiết
		//public string NumberPhone { get; set; } // SDT
		//public int Status { get; set; }
		//public int? ShippingFee { get; set; }
		public async Task Btn_DatHang()
		{
			Regex phoneNumberRegex = new Regex(@"^0\d{9}$");
			if (_bill_vm.TenNguoiNhan == string.Empty || _bill_vm.SDTNhan == string.Empty || _bill_vm.DiaChiCuThe == string.Empty || _bill_vm.Tinh == string.Empty || _bill_vm.Huyen == string.Empty || _bill_vm.Xa == string.Empty || !phoneNumberRegex.IsMatch(_bill_vm.SDTNhan))
				return;
			if (_bill_vm.PhuongThucTT == "Thanh toán Momo")
			{
				//var abc = _bill_vm;
				// Bill
				_bill_vm.Id = Guid.NewGuid();
				_bill_vm.TotalAmount = _tongTienAll;
				_bill_vm.Status = 1;
				if (_bill_vm.Note == string.Empty) _bill_vm.Note = "Không có ghi chú";
				//_bill_vm.HistoryConsumerPointID = _lstHCP_VM.FirstOrDefault().Id;
				if (_bill_vm.TenNguoiNhan == string.Empty) _bill_vm.TenNguoiNhan = _user_vm.FullName;
				// Order
				_ord.OrderId = Guid.NewGuid().ToString();
				if (_user_vm.FullName == null) _ord.FullName = _bill_vm.TenNguoiNhan;
				else _ord.FullName = _user_vm.FullName;
				_ord.OrderInfo = _bill_vm.Note;
				_ord.Amount = _tongTienAll;
				var reponse = await _httpClient.PostAsJsonAsync("https://localhost:7264/api/Momo/CreatePaymentAsync", _ord);
				var reponse2 = await reponse.Content.ReadFromJsonAsync<MomoCreatePaymentResponseModel>();
				_navi.NavigateTo($"{reponse2.PayUrl}", true);
			}
			if (_bill_vm.PhuongThucTT == "Thanh toán khi nhận hàng (COD)")
			{
				var codeToday = "B" + DateTime.Now.ToString().Substring(0, 10).Replace("/", "") + ".";
				_lstBill = (await _httpClient.GetFromJsonAsync<List<Bill_VM>>("https://localhost:7264/api/bill/get_all_bill")).Where(c => c.BillCode.StartsWith(codeToday)).ToList();
				_bill_vm.Id = Guid.NewGuid();
				_bill_vm.TotalAmount = _tongTienAll;
				_bill_vm.Status = 1;
				if (_bill_vm.Note == string.Empty) _bill_vm.Note = "Không có ghi chú";
				//_bill_vm.HistoryConsumerPointID = _lstHCP_VM.FirstOrDefault().Id;
				if (_bill_vm.TenNguoiNhan == string.Empty) _bill_vm.TenNguoiNhan = _user_vm.FullName;
				// Tạo mã bill dạng: B + ngày tháng năm tạo bill + số lớn nhất +1
				if (_lstBill.Count == 0) _bill_vm.BillCode = codeToday + "1";
				else _bill_vm.BillCode = codeToday + _lstBill.Max(c => int.Parse(c.BillCode.Substring(10)) + 1).ToString();
				// Ngày tạo
				_bill_vm.CreateDate = DateTime.Now;

				var addBill = await _httpClient.PostAsJsonAsync("https://localhost:7264/api/bill/add_bill", _bill_vm);
				if (addBill.IsSuccessStatusCode)
				{
					foreach (var x in _lstCI)
					{
						_pi_vm = _lstPrI_VM.Where(c => c.Id == x.ProductItemId).FirstOrDefault();
						BillItem_VM billItem_VM = new BillItem_VM();
						billItem_VM.Id = Guid.NewGuid();
						billItem_VM.BillId = _bill_vm.Id;
						billItem_VM.ProductItemsId = x.ProductItemId;
						billItem_VM.Quantity = x.Quantity;
						billItem_VM.Price = _pi_vm.PriceAfterReduction;
						billItem_VM.Status = 1;
						_pi_vm.AvaiableQuantity -= x.Quantity;
						var a = await _httpClient.PostAsJsonAsync("https://localhost:7264/api/billitem/add_billitem", billItem_VM);
						var b = await _httpClient.PutAsJsonAsync("https://localhost:7264/api/ProductItem/update", _pi_vm);
						var c = await _httpClient.DeleteAsync($"https://localhost:7264/api/cartitem/delete_cartitem/{x.Id}");
					}
					_ihttpcontextaccessor.HttpContext.Session.Remove("_lstCI_Vanglai");
					_toastService.ShowSuccess("Đơn hàng đã được tạo thành công, để theo dõi đơn hàng hãy vào mục Lịch sử đơn hàng");
					_toastService.ShowSuccess("Sau 5 giây bạn sẽ được đưa vè trang chủ");
					await Task.Delay(5000);
					_navi.NavigateTo("/home", true);
					return;
					//_navi.NavigateTo("https://localhost:7022/home",true);
				}
				_toastService.ShowError("Tạo đơn hàng thất bại");
			}
		}

		public async Task BackToCart()
		{
			_navi.NavigateTo("https://localhost:7022/home", true);
		}

		public async Task ChonTinhTP()
		{
			if (_bill_vm.Tinh == _TinhTp) return;
			_lstQuanHuyen.Clear();
			_lstXaPhuong.Clear();
			_bill_vm.Huyen = string.Empty;
			_bill_vm.Xa = string.Empty;
			if (_bill_vm.Tinh == string.Empty)
			{
				_TinhTp = string.Empty;
				return;
			}
			Province_VM chon = new Province_VM();
			chon = _lstTinhTp_Data.FirstOrDefault(c => c.Name == _bill_vm.Tinh);
			_lstQuanHuyen = _lstQuanHuyen_Data.Where(c => c.ProvinceId == chon.Id).ToList();
			_TinhTp = _bill_vm.Tinh;
		}

		public async Task ChonQuanHuyen()
		{
			if (_bill_vm.Huyen == _QuanHuyen) return;
			_lstXaPhuong.Clear();
			_bill_vm.Xa = string.Empty;
			if (_bill_vm.Huyen == string.Empty)
			{
				_QuanHuyen = string.Empty;
				return;
			}
			District_VM chon = _lstQuanHuyen_Data.FirstOrDefault(c => c.Name == _bill_vm.Huyen);
			_lstXaPhuong = _lstXaPhuong_Data.Where(c => c.DistrictId == chon.Id).ToList();
			_QuanHuyen = _bill_vm.Huyen;
		}
	}
}