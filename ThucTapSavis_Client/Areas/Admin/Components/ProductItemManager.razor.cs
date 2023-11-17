using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
	public partial class ProductItemManager
	{
		HttpClient _client = new HttpClient();
		[Inject] NavigationManager _navigation { get; set; }
		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
		List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		List<Image_VM> _lstImg = new List<Image_VM>();
		List<Product_VM> _lstP = new List<Product_VM>();
		List<Color_VM> _lstC = new List<Color_VM>();
		List<Size_VM> _lstS = new List<Size_VM>();
		List<Category_VM> _lstCate = new List<Category_VM>();
		private List<Image_Join_ProductItem> _lstImg_PI = new List<Image_Join_ProductItem>();
		private List<Image_Join_ProductItem> _lstImg_PI_tam = new List<Image_Join_ProductItem>();
		ProductItem_VM _PI_VM = new ProductItem_VM();
		Product_VM _P_VM = new Product_VM();
		Category_VM _Cate_VM = new Category_VM();
		Color_VM _C_VM = new Color_VM();
		Size_VM _S_VM = new Size_VM();
		Image_VM _I_VM = new Image_VM();
		IBrowserFile _file { get; set; }
		public Guid _idPI { get; set; }
		public string _pathImg { get; set; }
		List<Image_VM> _lstImg_Tam = new List<Image_VM>();
		List<Image_VM> _lstImg_Tam_Them = new List<Image_VM>();
		List<Image_VM> _lstImg_Tam_Xoa = new List<Image_VM>();
		List<Image_VM> _lstImg_Tam_Sua = new List<Image_VM>();
		public Guid _idPI_Tam { get; set; }
		public Guid _idImg_Tam { get; set; }
		ProductItem_Show_VM _PM_S_VM = new ProductItem_Show_VM();
        //public Guid Id { get; set; }
        //public Guid ProductId { get; set; }
        //public Guid ColorId { get; set; }
        //public Guid SizeId { get; set; }
        //public int AvaiableQuantity { get; set; }
        //public int PurchasePrice { get; set; }
        //public int CostPrice { get; set; }
        //public int Status { get; set; }
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
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
            _lstP = _lstP.OrderBy(c => c.Name).ToList();
            _lstCate = await _client.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
			_lstCate = _lstCate.OrderBy(c => c.Name).ToList();
			_lstC = await _client.GetFromJsonAsync<List<Color_VM>>("https://localhost:7264/api/color/get_color");
			_lstC = _lstC.OrderBy(c=>c.Name).ToList();
			_lstS = await _client.GetFromJsonAsync<List<Size_VM>>("https://localhost:7264/api/Size/get_size");
            _lstS = _lstS.OrderBy(c=>_lstSizeSample.IndexOf(c.Name)).ToList();
            _lstImg = await _client.GetFromJsonAsync<List<Image_VM>>("https://localhost:7264/api/Image/get_Image");
			_lstImg_PI = await _client.GetFromJsonAsync<List<Image_Join_ProductItem>>("https://localhost:7264/api/image/get_Image_Join_PI");
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			_idPI_Tam = Guid.NewGuid();
			
        }
		public async Task ChangeEv(InputFileChangeEventArgs e)
		{
			Image_VM imgTam = new Image_VM();
			_file = e.File;
			if (_file != null)
			{
				// Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", _file.Name);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					// Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					try
					{
						await _file.OpenReadStream(2048 * 1024).CopyToAsync(stream);
					}
					catch (Exception)
					{

						_toastService.ShowError("Ảnh có kích thước quá lớn, vui lòng chọn ảnh khác");
						return;
					}
				}
				// Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã đưuọc sao chép
				imgTam.PathImage = _file.Name;
				_pathImg = _file.Name;
				imgTam.Id = Guid.NewGuid();
				_idImg_Tam = imgTam.Id;
				imgTam.Name = "";
				if (_lstImg_Tam.Count == 0) imgTam.STT = 1;
				else imgTam.STT = _lstImg_Tam.Count == 0
							? _lstImg.Max(c => c.STT) + 1
							: (_lstImg.Max(c => c.STT) > _lstImg_Tam.Max(c => c.STT)
							? _lstImg.Max(c => c.STT) + 1
							: _lstImg_Tam.Max(c => c.STT) + 1);
				if (_idPI.ToString() == "00000000-0000-0000-0000-000000000000") imgTam.ProductItemId = _idPI_Tam;
				else imgTam.ProductItemId = _idPI;
				imgTam.Status = 1;
				_lstImg_Tam_Them.Add(imgTam);
				_lstImg_Tam.Add(imgTam);
				_toastService.ShowSuccess("Ảnh đã được tải lên thành công");
			}
		}
		public async Task ChangeImg(InputFileChangeEventArgs e)
		{
			Image_VM imgTam = _lstImg.Where(c => c.Id == _idImg_Tam).FirstOrDefault();
			if (imgTam == null) imgTam = _lstImg_Tam_Them.Where(c => c.Id == _idImg_Tam).FirstOrDefault();

			_file = e.File;
			if (_file != null)
			{
				// Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", _file.Name);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					// Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					try
					{
						await _file.OpenReadStream(2048 * 1024).CopyToAsync(stream);
					}
					catch (Exception)
					{

						_toastService.ShowError("Ảnh có kích thước quá lớn, vui lòng chọn ảnh khác");
						return;
					}
				}
				// Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã đưuọc sao chép
				imgTam.PathImage = _file.Name;
				_pathImg = _file.Name;
				if (!_lstImg_Tam_Sua.Any(c => c.Id == imgTam.Id)) _lstImg_Tam_Sua.Add(imgTam);
				_toastService.ShowSuccess("Thay đổi ảnh thành công");
			}
		}
		public async Task Add_PI()
		{
			_PI_VM.Id = _idPI_Tam;


			var a = await _client.PostAsJsonAsync("https://localhost:7264/api/ProductItem/Add", _PI_VM);
			if (a.IsSuccessStatusCode)
			{
				foreach (var x in _lstImg_Tam_Them)
				{
					await _client.PostAsJsonAsync("https://localhost:7264/api/image/add_Image", x);
				}
				_navigation.NavigateTo("product-item-manager", true);
			}
		}
		public async Task Update_PI()
		{
			var a = await _client.PutAsJsonAsync("https://localhost:7264/api/ProductItem/update", _PI_VM);
			if (a.IsSuccessStatusCode)
			{
				var lstbd = _lstImg.Where(c => c.ProductItemId == _idPI).ToList();
				if (_lstImg_Tam_Them.Count > 0)
				{
					foreach (var x in _lstImg_Tam)
					{
						await _client.PostAsJsonAsync("https://localhost:7264/api/image/add_Image", x);
					}
				}
				if (_lstImg_Tam_Xoa.Count > 0)
				{
					foreach (var x in _lstImg_Tam_Xoa)
					{
						await _client.DeleteAsync($"https://localhost:7264/api/image/delete_Image/{x.Id}");
					}
				}
				if (_lstImg_Tam_Sua.Count > 0)
				{
					foreach (var x in _lstImg_Tam_Sua)
					{
						await _client.PutAsJsonAsync($"https://localhost:7264/api/image/update_Image", x);
					}
				}
				_navigation.NavigateTo("https://localhost:7022/Admin/ProductItem", true);
			}
		}
		public async Task LoadUpdate(ProductItem_Show_VM pi)
		{
			_pathImg = null;
			_idPI = pi.Id;
			_PI_VM.Id = pi.Id;
			_PI_VM.ProductId = pi.ProductId;
			_PI_VM.ColorId = pi.ColorId;
			_PI_VM.SizeId = pi.SizeId;
			_PI_VM.AvaiableQuantity = pi.AvaiableQuantity;
			_PI_VM.CostPrice = pi.CostPrice;
			_PI_VM.Status = pi.Status;
			var lst_chonmau = _lstPrI_show_VM.Where(c => c.ColorId == _PI_VM.ColorId && c.ProductId == _PI_VM.ProductId).ToList();
			_lstImg_PI_tam.Clear();
			foreach (var x in lst_chonmau)
			{
				var a = _lstImg_PI.Where(c => c.ProductItemId == x.Id);
				_lstImg_PI_tam.AddRange(a);
			}
			_lstImg_Tam.Clear();
			foreach (var item in _lstImg_PI_tam)
			{
				Image_VM image_VM = new Image_VM();
				image_VM.Id = item.Id;
				image_VM.Name = item.Name;
				image_VM.STT = item.STT;
				image_VM.PathImage = item.PathImage;
				image_VM.ProductItemId = item.ProductItemId;
				image_VM.Status = item.Status;
				_lstImg_Tam.Add(image_VM);
			}
			_idImg_Tam = _lstImg_Tam.OrderBy(c => c.STT).Select(c => c.Id).FirstOrDefault();
			_pathImg = _lstImg.Where(c => c.Id == _idImg_Tam).Select(c => c.PathImage).FirstOrDefault();
			await JsRuntime.InvokeVoidAsync("OnScrollEvent");
		}
		public async Task Add_P()
		{
			if (_P_VM.Name == string.Empty || _P_VM.Name == null)
			{
				_toastService.ShowError("Không được để trống");
				return;
			}
			if (_lstP.Any(c => c.Name.ToLower() == _P_VM.Name.ToLower()))
			{
				_toastService.ShowError("Tên đã tồn tại");
				return;
			}
			var x = await _client.PostAsJsonAsync("https://localhost:7264/api/Product/Add", _P_VM);
			if (x.IsSuccessStatusCode) _toastService.ShowSuccess("Thêm thành công");
			_lstP = await _client.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
		}
		public async Task Add_Cate()
		{
			if (_Cate_VM.Name == string.Empty || _Cate_VM.Name == null)
			{
				_toastService.ShowError("Không được để trống");
				return;
			}
			if (_lstCate.Any(c => c.Name.ToLower() == _Cate_VM.Name.ToLower()))
			{
				_toastService.ShowError("Thể loại đã tồn tại");
				return;
			}
			_Cate_VM.Id = Guid.NewGuid();
			_Cate_VM.TenKhongDau = "";
			var x = await _client.PostAsJsonAsync("https://localhost:7264/api/category/add_category", _Cate_VM);
			if (x.IsSuccessStatusCode) _toastService.ShowSuccess("Thêm thành công");
			_lstCate = await _client.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
		}
		public async Task Add_C()
		{
			if (_C_VM.Name == string.Empty || _C_VM.Name == null)
			{
				_toastService.ShowError("Không được để trống");
				return;
			}
			if (_lstC.Any(c => c.Name.ToLower() == _C_VM.Name.ToLower()))
			{
				_toastService.ShowError("Màu sắc đã tồn tại");
				return;
			}
			_C_VM.Id = Guid.NewGuid();
			var x = await _client.PostAsJsonAsync("https://localhost:7264/api/color/add_color", _C_VM);
			if (x.IsSuccessStatusCode) _toastService.ShowSuccess("Thêm thành công");
			_lstC = await _client.GetFromJsonAsync<List<Color_VM>>("https://localhost:7264/api/color/get_color");
		}
		public async Task Add_S()
		{
			if (_S_VM.Name == string.Empty || _S_VM.Name == null)
			{
				_toastService.ShowError("Không được để trống");
				return;
			}
			if (_lstS.Any(c => c.Name.ToLower() == _S_VM.Name.ToLower()))
			{
				_toastService.ShowError("Kích thước đã tồn tại");
				return;
			}
			_S_VM.Id = Guid.NewGuid();
			var x = await _client.PostAsJsonAsync("https://localhost:7264/api/Size/Add", _S_VM);
			if (x.IsSuccessStatusCode) _toastService.ShowSuccess("Thêm thành công");
			_lstS = await _client.GetFromJsonAsync<List<Size_VM>>("https://localhost:7264/api/Size/get_size");
		}

		public async Task LoadAnh(Guid id)
		{
			_idImg_Tam = id;
			_pathImg = _lstImg_Tam.FirstOrDefault(c => c.Id == id).PathImage;

		}
		public async Task Delete_Img_Tam()
		{
			Image_VM imgTam = new Image_VM();
			var imgVuaXoa = _lstImg_Tam.FirstOrDefault(c => c.Id == _idImg_Tam);
			_lstImg_Tam_Xoa.Add(imgVuaXoa);
			_lstImg_Tam.Remove(imgVuaXoa);
			_lstImg_Tam_Them.Remove(imgVuaXoa);
			_idImg_Tam = _lstImg_Tam.Select(c => c.Id).FirstOrDefault();
			if (_idPI.ToString() != "00000000-0000-0000-0000-000000000000")
			{
				_pathImg = _lstImg_Tam.Where(c => c.ProductItemId == _idPI).Select(c => c.PathImage).FirstOrDefault();
			}
			else
			{
				_pathImg = _lstImg_Tam.Select(c => c.PathImage).FirstOrDefault();
			}
			_toastService.ShowSuccess("Ảnh đã được xóa thành công");
		}
		public async Task LocHangLoat()
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");

			_lstPrI_show_VM = _lstPrI_show_VM.Where(c =>
								(_PM_S_VM.CategoryName == null ||
								_PM_S_VM.CategoryName == "0" ||
								c.CategoryName == _PM_S_VM.CategoryName) &&
								(_PM_S_VM.SizeName == null ||
								_PM_S_VM.SizeName == "0" ||
								c.SizeName == _PM_S_VM.SizeName) &&
								(_PM_S_VM.ColorName == null ||
								_PM_S_VM.ColorName == "0" ||
								c.ColorName == _PM_S_VM.ColorName)).ToList();
		}
		public async Task TimKiem()
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");

			_lstPrI_show_VM = _lstPrI_show_VM.Where(c =>
								_PM_S_VM.Name == null ||
								_PM_S_VM.Name == string.Empty ||
								c.Name.Trim().ToLower().Contains(_PM_S_VM.Name.Trim().ToLower())).ToList();
		}
	}
}
