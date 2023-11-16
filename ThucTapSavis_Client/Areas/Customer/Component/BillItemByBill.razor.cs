using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Customer.Component
{
    public partial class BillItemByBill
    {
        [Inject] NavigationManager _navigationManager { get; set; }
        HttpClient _httpClient = new HttpClient();
        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; }

        public Bill_VM _bill = new Bill_VM();
        Bill_ShowModel _bill_ShowModel = new Bill_ShowModel();

        BillItem_VM _billItem = new BillItem_VM();
        List<BillDetailShow> _lstBillItems = new List<BillDetailShow>();

        protected async override Task OnInitializedAsync()
        {
            _bill = BillByUser._bill_VM;
            var a = await _httpClient.GetFromJsonAsync<List<Bill_ShowModel>>("https://localhost:7264/api/bill/get_all_bill");
            _bill_ShowModel = a.FirstOrDefault(x => x.Id == _bill.Id);
            _lstBillItems = await _httpClient.GetFromJsonAsync<List<BillDetailShow>>($"https://localhost:7264/api/billitem/get_billitem_by_BillId/{_bill.Id}");
        }
        public async Task CancelOrder(string billCode)
        {
            var b= await _httpClient.GetFromJsonAsync<List<Bill_VM>>("https://localhost:7264/api/bill/get_bill_VM");
            Bill_VM bill=b.FirstOrDefault(x=>x.BillCode==billCode);
            bill.Status = 0;
            var a = await _httpClient.PutAsJsonAsync<Bill_VM>("https://localhost:7264/api/bill/update_bill",bill);
            if (a.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("https://localhost:7022/Customer/User/BillItemByBill", true);
                _toastService.ShowSuccess("Huỷ đơn hàng thành công");
            }
            else
            {
                _toastService.ShowError("Huỷ đơn hàng thất bại");
            }
        }
    }
}
