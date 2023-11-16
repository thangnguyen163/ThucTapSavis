﻿using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Text;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
	public partial class ShowProduct
	{
		private HttpClient _client = new HttpClient();
		[Inject] private NavigationManager _navigation { get; set; }
		[Inject] private IToastService _toastService { get; set; }
		private List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();
		private List<Image_Join_ProductItem> _lstImg_PI = new List<Image_Join_ProductItem>();
		private List<Category_VM> _lstCate = new List<Category_VM>();
		private string? _searchProduct { get; set; }

		protected override async Task OnInitializedAsync()
		{
			_lstPrI_show_VM = await _client.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
			_lstImg_PI = await _client.GetFromJsonAsync<List<Image_Join_ProductItem>>("https://localhost:7264/api/image/get_Image_Join_PI");
			_lstCate = await _client.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
			SetTenKhongDau(_lstCate);
		}

		public async Task SearchPrd()
		{
			if (_searchProduct == null || _searchProduct.Trim() == string.Empty)
			{
				_toastService.ShowError("Vui lòng nhập từ khóa cần tìm kiếm");
				return;
			}
			_navigation.NavigateTo($"https://localhost:7022/search/{_searchProduct}", true);
		}

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
	}
}