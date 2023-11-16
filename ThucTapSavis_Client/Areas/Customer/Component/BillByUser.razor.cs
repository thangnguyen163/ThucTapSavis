using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
    public partial class BillByUser
    {
        [Inject] NavigationManager _navigationManager { get; set; }
        HttpClient _httpClient = new HttpClient();
        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; }
        [Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
        public static Bill_VM _bill_VM = new Bill_VM();
        List<Bill_VM> _lstBills = new List<Bill_VM>();
        User_VM _user = new User_VM();

        protected override async Task OnInitializedAsync()
        {

            //_user = SessionServices.GetUserFromSession_User_VM(_ihttpcontextaccessor.HttpContext.Session, "User");
            _user.Id = Guid.Parse("861a5ad4-5890-46bf-95a5-fc85ae80367d");
            //var a = Guid.Parse("c416a2f2-4a08-4787-ac30-4c856e9abf1a");
            //_user = await _httpClient.GetFromJsonAsync<User>($"https://localhost:7141/api/user/get_user_by_id/{a}");
            _lstBills = await _httpClient.GetFromJsonAsync<List<Bill_VM>>($"https://localhost:7264/api/bill/get_bill_by_user?UserId={_user.Id}");
            _lstBills = _lstBills.OrderByDescending(x => x.CreateDate).ToList();
        }
        public async Task NavBillItem(Bill_VM bill_VM)
        {
            _bill_VM = bill_VM;
            _navigationManager.NavigateTo("https://localhost:7022/Customer/User/BillItemByBill", true);
        }
    }
}
