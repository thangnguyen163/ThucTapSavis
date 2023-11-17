using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class BillDetail
    {
        HttpClient _client = new HttpClient();
        Bill_ShowModel _billModel = new Bill_ShowModel();
        List<BillDetailShow> _lstBillDetail = new List<BillDetailShow>();
        Bill_VM b = new Bill_VM();
        [Inject]
        NavigationManager nav { get; set; }

        Bill bil = new Bill();
        public int? _tongtien { get; set; } = 0;
        public string texttongtien { get; set; }
        public int Phiship { get; set; }
        public string Note { get; set; }
        public string Suggest_number_1 { get; set; } = string.Empty;
        public string Suggest_number_2 { get; set; } = string.Empty;
        public bool displayButton { get; set; }
        public string CheckFee { get; set; }
        public string CheckNote { get; set; }
        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

        [Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
        User_VM _user_VM = new User_VM();

        protected override async Task OnInitializedAsync()
        {
                _billModel = Bill._billModel;
                _billModel.Id = Bill._billModel.Id;
                _lstBillDetail = await _client.GetFromJsonAsync<List<BillDetailShow>>($"https://localhost:7264/api/billitem/get_billitem_by_BillId/{_billModel.Id}");

                foreach (var item in _lstBillDetail)
                {
                    _tongtien += item.Quantity * item.PriceAfter;
                }
                texttongtien = NumberToText(Convert.ToDouble(_tongtien));
                displayButton = false;
           
        }
        public void ReturnBill()
        {
            nav.NavigateTo("https://localhost:7022/Admin/Bill", true);
        }
        public async Task UpdateConfirmShipping()
        {
            if (Phiship == null && Note == null)
            {
                CheckFee = "Không được để trống số tiền";
                CheckNote = "Không được bỏ trống ghi chú";
            }
            else
            {
                Bill_VM b = await _client.GetFromJsonAsync<Bill_VM>($"https://localhost:7264/api/billitem/get_billitem_by_id/{_billModel.Id}");
                b.Note = Note;
                b.Status = 2;
                var status = await _client.PutAsJsonAsync("https://localhost:7264/api/bill/update_bill", b);
                if (status.IsSuccessStatusCode)
                {
                    nav.NavigateTo("https://localhost:7022/Admin/Bill/BillDetail", true);
                }
            }
        }
        public async Task CancelBill(Guid BillID)
        {
            Bill_VM b = await _client.GetFromJsonAsync<Bill_VM>($"https://localhost:7264/api/bill/get_bill_by_id/{BillID}");

            b.Status = 0;
            var status = await _client.PutAsJsonAsync("https://localhost:7264/api/bill/update_bill", b);
            if (status.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess("Đơn hàng đã bị huỷ");
                nav.NavigateTo("https://localhost:7022/Admin/Bill", true);
            }
        }
        public async Task ConfirmBill(Guid BillID)
        {
            Bill_VM b = await _client.GetFromJsonAsync<Bill_VM>($"https://localhost:7264/api/bill/get_bill_by_id/{BillID}");

            b.Status = 2;
            var status = await _client.PutAsJsonAsync("https://localhost:7264/api/bill/update_bill", b);
            if (status.IsSuccessStatusCode)
            {
                _toastService.ShowSuccess("Đơn hàng đã được xác nhận");
                nav.NavigateTo("https://localhost:7022/Admin/Bill", true);
            }
        }
        private void CheckNoteNull(ChangeEventArgs e)
        {
            var Note = e.Value.ToString();
            if (Note.Trim() == null || Note.Trim() == string.Empty)
            {
                CheckNote = "Không được bỏ trống ghi chú";
            }
            else
            {
                CheckNote = null;
            }
        }

        static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }
            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");

        }

    }
}
