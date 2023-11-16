using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
    public partial class ChangePassword
    {
        HttpClient _client = new HttpClient();
        public string TypeInput_Pass { get; set; } = "password";
        public string Icon_Pass { get; set; } = "fa-regular fa-eye-slash";
        public string TypeInput_New { get; set; } = "password";
        public string Icon_New { get; set; } = "fa-regular fa-eye-slash";
        public string TypeInput_CheckNew { get; set; } = "password";
        public string Icon_CheckNew { get; set; } = "fa-regular fa-eye-slash";

        [Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

        User_VM _user_VM = new User_VM();
        User_VM _user = new User_VM();
        List<User> _lstUser_VM = new List<User>();

        protected async override Task OnInitializedAsync()
        {
            _user_VM = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
        }
        public async Task ChangePasswordMethor()
        {
            var a = await _client.GetFromJsonAsync<List<User_VM>>("https://localhost:7264/api/User/get-user");
            var b=a.FirstOrDefault(x=>x.Id==_user_VM.Id);
            b.Password = _user.NewPassword;
            b.NewPassword=_user.NewPassword;
            b.ConfirmNewPassword=_user.ConfirmNewPassword;
            var response = await _client.PutAsJsonAsync<User_VM>("https://localhost:7264/api/User/change-password", b);
            if (response.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess("Đổi mật khẩu thành công");
                _navigationManager.NavigateTo("https://localhost:7022/Customer/User/ChangePassword", true); 
            }
            else
            {
                _toastService.ShowSuccess("Đổi mật khẩu thất bại");
            }
        }

        private void ShowPass()
        {
            if (TypeInput_Pass == "text")
            {
                TypeInput_Pass = "password";
                Icon_Pass = "fa-regular fa-eye-slash";
            }
            else
            {
                TypeInput_Pass = "text";
                Icon_Pass = "fa-regular fa-eye";
            }
        }
        private void ShowNewPass()
        {
            if (TypeInput_New == "text")
            {
                TypeInput_New = "password";
                Icon_New = "fa-regular fa-eye-slash";
            }
            else
            {
                TypeInput_New = "text";
                Icon_New = "fa-regular fa-eye";
            }
        }
        private void ShowCheckNewPass()
        {
            if (TypeInput_CheckNew == "text")
            {
                TypeInput_CheckNew = "password";
                Icon_CheckNew = "fa-regular fa-eye-slash";
            }
            else
            {
                TypeInput_CheckNew = "text";
                Icon_CheckNew = "fa-regular fa-eye";

            }
        }
    }
}
