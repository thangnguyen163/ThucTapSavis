using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Size
    {
        HttpClient _httpClient = new HttpClient();
        public Size_VM size_VM = new Size_VM();
        [Inject] NavigationManager navigationManager { get; set; }
        List<Size_VM> size = new List<Size_VM>();
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
                size = await _httpClient.GetFromJsonAsync<List<Size_VM>>("https://localhost:7264/api/Size/get_size");
            }
            
        }
        public async Task AddSize()
        {
            size_VM.Id = Guid.NewGuid();

            await _httpClient.PostAsJsonAsync<Size_VM>("https://localhost:7264/api/Size/Add", size_VM);
            navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Size", true);


        }
        public async Task UpdateSize(Size_VM size)
        {
            await _httpClient.PutAsJsonAsync<Size_VM>("https://localhost:7264/api/Size/update", size);
            navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Size", true);
        }
        public async void DeleteSize(Guid Id)
        {
            await _httpClient.DeleteAsync("https://localhost:7264/api/Size/delete/{Id}");
            navigationManager.NavigateTo("https://localhost:7022/Admin/ThuocTinh/Size", true);
        }
        public async Task LoadForm(Size_VM rvm)
        {
            size_VM.Id = rvm.Id;
            size_VM.Name = rvm.Name;
            size_VM.Status = rvm.Status;
        }
    }
}
