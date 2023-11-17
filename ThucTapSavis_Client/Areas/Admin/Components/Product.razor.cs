using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Product
    {
		HttpClient _httpClient = new HttpClient();
		public Product_VM product_VM = new Product_VM();
		public List<Category_VM> category = new List<Category_VM>();
		[Inject] NavigationManager navigationManager { get; set; }
		List<Product_VM> product = new List<Product_VM>();
		public string Message { get; set; } = string.Empty;

		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		User_VM _user_VM = new User_VM();
		protected override async Task OnInitializedAsync()
		{
			product = await _httpClient.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
			category =await _httpClient.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
		}
		public async Task AddProduct()
		{
			product_VM.Id = Guid.NewGuid();

			 var a= await _httpClient.PostAsJsonAsync<Product_VM>("https://localhost:7264/api/Product/Add", product_VM);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Product", true);
		}
		public async Task UpdateProduct(Product_VM Product)
		{
			var a =  await _httpClient.PutAsJsonAsync<Product_VM>("https://localhost:7264/api/Product/Update", Product);
			if (a.IsSuccessStatusCode)
            {
				if (Product.Status == 0)
				{
					var b = await _httpClient.GetFromJsonAsync<List<ProductItem_VM>>("https://localhost:7264/api/ProductItem");
					var c = b.Where(x => x.ProductId == Product.Id).ToList();
					foreach (var item in c)
					{
						item.Status = 0;
						var d = await _httpClient.PutAsJsonAsync("https://localhost:7264/api/ProductItem/update", item);
					}
				}
			}			
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Product", true);
		}
		public async void DeleteProduct(Guid Id)
		{
			await _httpClient.DeleteAsync("https://localhost:7264/api/Product/delete/" + Id);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Product", true);
		}
		public async Task LoadForm(Product_VM rvm)
		{
			product_VM.Id = rvm.Id;
			product_VM.Name = rvm.Name;
			product_VM.Status = rvm.Status;
		}
	}
}
