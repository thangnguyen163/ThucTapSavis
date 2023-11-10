using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Componment
{
    public partial class SignUp
    {
        HttpClient _client = new HttpClient();
        User_VM user=new User_VM();
        [Inject] NavigationManager navigationManager { get; set; }
        public async Task Add()
        {
            Guid id = Guid.NewGuid();
            user.Id = id;
            var a = await _client.PostAsJsonAsync("https://localhost:7264/api/User/add-user", user);
            if (a.IsSuccessStatusCode)
            {
                Cart cart = new Cart();
                cart.UserId = id;
                cart.Status = 1;
                var b = _client.PostAsJsonAsync("https://localhost:7264/api/cart/add_cart", cart);
                navigationManager.NavigateTo("https://localhost:7022/Customer/Home/Login",true);
            }
            //navigationManager.NavigateTo("https://localhost:7022/Customer/Home/Login", true);
        }
    }

}
