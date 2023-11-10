﻿using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Text;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Bill
    {
        HttpClient _client = new HttpClient();
        List<Bill_ShowModel> _lstbill = new List<Bill_ShowModel>();
        public static Bill_ShowModel _billModel = new Bill_ShowModel();
        public static Bill_ShowModel Search = new Bill_ShowModel();

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public DateTime startdate { get; set; }
        public DateTime datecheck { get; set; }
        public DateTime enddate { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _lstbill = await _client.GetFromJsonAsync<List<Bill_ShowModel>>("https://localhost:7264/api/bill/get_all_bill");
        }
        public async Task ClickDetailBill(Bill_ShowModel bill_ShowModel)
        {
            _billModel = bill_ShowModel;
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Bill/BillDetail", true);

        }
        public async Task LocHangLoat()
        {
            _lstbill = await _client.GetFromJsonAsync<List<Bill_ShowModel>>("https://localhost:7264/api/bill/get_all_bill");

            _lstbill = _lstbill.Where(c =>
                                (Search.BillCode == null ||
                                Search.BillCode == "0" ||
                                c.BillCode.ToLower().Contains(Search.BillCode.ToLower())) &&
                                (Search.UserName == null ||
                                Search.UserName == "0" ||
                                RemoveDiacritics(c.UserName.ToLower()).Contains(RemoveDiacritics(Search.UserName.ToLower()))) &&
                                ((startdate == default && enddate == default) ||
                                startdate == default ||
                                enddate == default ||
                                (c.CreateDate > startdate && c.CreateDate < enddate))).ToList();
        }
        public static string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }
        public void HandleDatetimeChange(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out DateTime result))
            {
                startdate = result;
            }
        }
        public void HandleDatetimeEndChange(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out DateTime result))
            {
                enddate = result;
            }
        }
    }
}
