using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;
using ThucTapSavis_Shared.ViewModel.DiaChi;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
    public partial class InforUser
    {
        HttpClient _client = new HttpClient();

        User_VM _user_VM = new User_VM();
        List<User> _lstUser_VM = new List<User>();
        [Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }

        public string Message { get; set; } = string.Empty;

        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind
        bool isModalOpenUpdateUser = false;
        bool isModalOpenUpdateAddress = false;

        private List<Province_VM> _lstTinhTp = new List<Province_VM>();
        private List<District_VM> _lstQuanHuyen = new List<District_VM>();
        private List<Ward_VM> _lstXaPhuong = new List<Ward_VM>();

        private List<Province_VM> _lstTinhTp_Data = new List<Province_VM>();
        private List<District_VM> _lstQuanHuyen_Data = new List<District_VM>();
        private List<Ward_VM> _lstXaPhuong_Data = new List<Ward_VM>();
        public string _TinhTp { get; set; }
        public string _QuanHuyen { get; set; }
        public string _XaPhuong { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _user_VM = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
            //var a = Guid.Parse("a4c10abe-eec2-40e6-9b6c-cf1221e9da78");
            //_user_VM = await _client.GetFromJsonAsync<User>($"https://localhost:7264/api/User/{a}");
            _lstTinhTp_Data = await _client.GetFromJsonAsync<List<Province_VM>>("https://api.npoint.io/ac646cb54b295b9555be");
            _lstTinhTp = _lstTinhTp_Data;
            _lstQuanHuyen_Data = await _client.GetFromJsonAsync<List<District_VM>>("https://api.npoint.io/34608ea16bebc5cffd42");
            _lstXaPhuong_Data = await _client.GetFromJsonAsync<List<Ward_VM>>("https://api.npoint.io/dd278dc276e65c68cdf5");
        }
        public async Task UpdateUser()
        {
            var a = await _client.PutAsJsonAsync($"https://localhost:7264/api/User/update-user", _user_VM);
            if (a.IsSuccessStatusCode)
            {
                ClosePopup("UpdateUser");
                _toastService.ShowSuccess("Cập nhật thông tin người dùng thành công");
            }
            else
            {
                _toastService.ShowSuccess("Cập nhật thông tin người dùng thành công");
            }
        }
        public async Task LoadUser(Guid Id)
        {
            OpenPopup("UpdateUser");
            var a = await _client.GetFromJsonAsync<User>($"https://localhost:7264/api/User/{Id}");
            _user_VM.Id = a.Id;
            _user_VM.FullName = a.FullName;
            _user_VM.Email = a.Email;
            _user_VM.NumberPhone = a.NumberPhone;
            _user_VM.UserName = a.UserName;
            _user_VM.DiaChiCuThe = a.DiaChiCuThe;
            _user_VM.Tinh = a.Tinh;
            _user_VM.Huyen = a.Huyen;
            _user_VM.Xa = a.Xa;
        }

        public async Task ChonTinhTP()
        {
            if (_user_VM.Tinh == _TinhTp) return;
            _lstQuanHuyen.Clear();
            _lstXaPhuong.Clear();
            _user_VM.Huyen = string.Empty;
            _user_VM.Xa = string.Empty;
            if (_user_VM.Tinh == string.Empty) return;
            Province_VM chon = new Province_VM();
            chon = _lstTinhTp_Data.FirstOrDefault(c => c.Name == _user_VM.Tinh);
            _lstQuanHuyen = _lstQuanHuyen_Data.Where(c => c.ProvinceId == chon.Id).ToList();
            _TinhTp = _user_VM.Tinh;
        }

        public async Task ChonQuanHuyen()
        {
            if (_user_VM.Huyen == _QuanHuyen) return;
            _lstXaPhuong.Clear();
            _user_VM.Xa = string.Empty;
            if (_user_VM.Huyen == string.Empty) return;
            District_VM chon = _lstQuanHuyen.FirstOrDefault(c => c.Name == _user_VM.Huyen);
            _lstXaPhuong = _lstXaPhuong_Data.Where(c => c.DistrictId == chon.Id).ToList();
            _QuanHuyen = _user_VM.Huyen;
        }

        public async Task ChonXaPhuong()
        {
            _XaPhuong = _user_VM.Xa;
        }

        private void SetModalState(bool isOpen, string modalType)
        {
            switch (modalType)
            {
                case "UpdateUser":
                    isModalOpenUpdateUser = isOpen;
                    break;
                case "UpdateAddress":
                    isModalOpenUpdateAddress = isOpen;
                    break;
                default:
                    break;
            }
        }
        private void OpenPopup(string modalType)
        {
            SetModalState(true, modalType);
        }

        private void ClosePopup(string modalType)
        {
            SetModalState(false, modalType);
        }
    }
}
