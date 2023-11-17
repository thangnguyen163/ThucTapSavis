using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Category
    {
		HttpClient _httpClient = new HttpClient();
		public Category_VM Category_VM = new Category_VM();
		[Inject] NavigationManager navigationManager { get; set; }
		List<Category_VM> category = new List<Category_VM>();
		public string Message { get; set; } = string.Empty;

		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		User_VM _user_VM = new User_VM();
		protected override async Task OnInitializedAsync()
		{
			_user_VM = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
			if (_user_VM.IdRole != Guid.Parse("c2fc9b7a-1e45-4de5-b2ed-7cb4e84397cf"))
			{
				_toastService.ShowError("Bạn không có quyền truy cập trang web này. Vui lòng đăng nhập với tư cách Admin");
				navigationManager.NavigateTo("https://localhost:7022/login", true);
			}
			else
			{
				category = await _httpClient.GetFromJsonAsync<List<Category_VM>>("https://localhost:7264/api/category/get_category");
			}
			
		}
		public async Task AddCategory()
		{
			Category_VM.Id = Guid.NewGuid();
			Category_VM.TenKhongDau = "";
			var a =await _httpClient.PostAsJsonAsync<Category_VM>("https://localhost:7264/api/category/add_Category", Category_VM);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Category", true);


		}
		public async Task UpdateCategory(Category_VM Category)
		{
			Category.TenKhongDau = "";
			var a =await _httpClient.PutAsJsonAsync<Category_VM>("https://localhost:7264/api/Category/update_category", Category);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Category", true);
		}
		public async void DeleteCategory(Guid Id)
		{
			await _httpClient.DeleteAsync("https://localhost:7264/api/category/delete_category/" + Id);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Category", true);
		}
		public async Task LoadForm(Category_VM rvm)
		{
			Category_VM.Id = rvm.Id;
			Category_VM.Name = rvm.Name;
			Category_VM.Status = rvm.Status;
		}
	}
}
