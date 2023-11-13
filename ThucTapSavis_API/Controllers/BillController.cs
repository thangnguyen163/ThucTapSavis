using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillServices _billServices;
        public BillController(IBillServices billServices)
        {
            _billServices = billServices;
        }
        [HttpGet("get_all_bill")]
        public async Task<IActionResult> Get()
        {
            var a = await _billServices.GetAllBill();
            return Ok(a);
        }
        [HttpGet("get_bill_by_user")]
        public async Task<IActionResult> GetBillByUser(Guid UserId)
        {
            var a = await _billServices.GetAllBillByUser(UserId);
            return Ok(a);
        }
        [HttpGet("get_bill_by_id")]
        public async Task<IActionResult> GetBillById(Guid Id)
        {
            var a = await _billServices.GetAllBillById(Id);
            return Ok(a);
        }
        [HttpPost("add_bill")]
        public async Task<IActionResult> AddBill(Bill_VM bill)
        {

		//	public Guid Id { get; set; }
		//public string BillCode { get; set; }
		//public Guid UserId { get; set; }
		//public DateTime? CreateDate { get; set; }
		//public DateTime? ConfirmationDate { get; set; }
		//public DateTime? CompletionDate { get; set; }
		//public int? TotalAmount { get; set; }
		//public string PhuongThucTT { get; set; }
		//public string Note { get; set; }
		//public string TenNguoiNhan { get; set; }
		//public string SDTNhan { get; set; }
		//public string Tinh { get; set; }
		//public string Huyen { get; set; }
		//public string Xa { get; set; }
		//public string? DiaChiCuThe { get; set; }
		//public int Status { get; set; }
		Bill bill1 = new Bill();
            bill1.Id = bill.Id;
			bill1.BillCode = bill.BillCode;
			bill1.UserId = bill.UserId;
            bill1.CreateDate = bill.CreateDate;
			bill1.CompletionDate = bill.CompletionDate;
			bill1.ConfirmationDate = bill.ConfirmationDate;
			bill1.TotalAmount = bill.TotalAmount;
			bill1.PhuongThucTT = bill.PhuongThucTT;
            bill1.Note = bill.Note;
            bill1.SDTNhan = bill.SDTNhan;
            bill1.TenNguoiNhan = bill.TenNguoiNhan;
            bill1.Tinh = bill.Tinh;
            bill1.Xa = bill.Xa;
            bill1.Huyen = bill.Huyen;
            bill1.DiaChiCuThe= bill.DiaChiCuThe;
            bill1.Status = bill.Status;
            var a = await _billServices.AddBill(bill1);
            return Ok(a);
        }
        [HttpPut("update_bill")]
        public async Task<IActionResult> UpdateBill(Bill_VM bill)
        {
            Bill bill1 = new Bill();
			bill1.BillCode = bill.BillCode;
			bill1.UserId = bill.UserId;
			bill1.CreateDate = bill.CreateDate;
			bill1.CompletionDate = bill.CompletionDate;
			bill1.ConfirmationDate = bill.ConfirmationDate;
			bill1.TotalAmount = bill.TotalAmount;
			bill1.PhuongThucTT = bill.PhuongThucTT;
			bill1.Note = bill.Note;
			bill1.SDTNhan = bill.SDTNhan;
			bill1.TenNguoiNhan = bill.TenNguoiNhan;
			bill1.Tinh = bill.Tinh;
			bill1.Xa = bill.Xa;
			bill1.Huyen = bill.Huyen;
			bill1.DiaChiCuThe = bill.DiaChiCuThe;
			bill1.Status = bill.Status;
			var a = await _billServices.UpdateBill(bill1);
            return Ok(a);
        }
        [HttpDelete("delete_bill")]
        public async Task<IActionResult> DeleteBill(Guid Id)
        {
            var a = await _billServices.DeleteBill(Id);
            return Ok();
        }
    }
}
