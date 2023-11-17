using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
	public partial class SignUp
	{
		HttpClient _client = new HttpClient();
		User_VM user = new User_VM();
		[Inject] NavigationManager navigationManager { get; set; }
		[Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
		public async Task Add()
		{
			Guid id = Guid.NewGuid();
			user.Id = id;
			user.Password = user.NewPassword;
			var a = await _client.PostAsJsonAsync("https://localhost:7264/api/User/add-user", user);
			if (a.IsSuccessStatusCode)
			{
				Cart cart = new Cart();
				cart.UserId = id;
				cart.Status = 1;
				var b = _client.PostAsJsonAsync("https://localhost:7264/api/cart/add_cart", cart);
				_toastService.ShowSuccess("Đăng ký tài khoản thành công");
				navigationManager.NavigateTo("https://localhost:7022/Customer/Home/Login", true);
			}
			else
            {
				_toastService.ShowError("Đăng ký tài khản thất bại");
				//navigationManager.NavigateTo("https://localhost:7022/Customer/Home/SignUp", true);
			}

		}
	}

}
