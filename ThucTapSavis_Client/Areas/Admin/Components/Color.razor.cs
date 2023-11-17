using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Color
    {
		HttpClient _httpClient = new HttpClient();
		public Color_VM color_VM = new Color_VM();
		[Inject] NavigationManager navigationManager { get; set; }
		List<Color_VM> color = new List<Color_VM>();
		public string Message { get; set; } = string.Empty;

		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

		[Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
		User_VM _user_VM = new User_VM();
		protected override async Task OnInitializedAsync()
		{
				color = await _httpClient.GetFromJsonAsync<List<Color_VM>>("https://localhost:7264/api/color/get_color");
		}
		public async Task AddColor()
		{
			color_VM.Id = Guid.NewGuid();

			await _httpClient.PostAsJsonAsync<Color_VM>("https://localhost:7264/api/color/add_color", color_VM);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Color", true);


		}
		public async Task UpdateColor(Color_VM color)
		{
			await _httpClient.PutAsJsonAsync<Color_VM>("https://localhost:7264/api/color/update_color", color);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Color", true);
		}
		public async void DeleteColor(Guid Id)
		{
			await _httpClient.DeleteAsync("https://localhost:7264/api/color/delete_color/" + Id);
			navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Color", true);
		}
		public async Task LoadForm(Color_VM rvm)
		{
			color_VM.Id = rvm.Id;
			color_VM.Name = rvm.Name;
			color_VM.Status = rvm.Status;
		}
	}
}
