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
        [HttpGet("get_bill")]
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
            Bill bill1 = new Bill();
            bill1.Id = bill.Id;
            bill1.UserId = bill.UserId;
            bill1.CreateDate = bill.CreateDate;
            bill1.TotalAmount = bill.TotalAmount;
            bill1.Note = bill.Note;
            bill1.TenNguoiNhan = bill.TenNguoiNhan;
            bill1.Tinh = bill.Tinh;
            bill1.Xa = bill1.Xa;
            bill1.Huyen = bill1.Huyen;
            bill1.DiaChiCuThe= bill1.DiaChiCuThe;
            bill1.Status = bill1.Status;
            var a = await _billServices.AddBill(bill1);
            return Ok(a);
        }
        [HttpPut("update_bill")]
        public async Task<IActionResult> UpdateBill(Bill_VM bill)
        {
            Bill bill1 = new Bill();
            bill1.UserId = bill.UserId;
            bill1.CreateDate = bill.CreateDate;
            bill1.TotalAmount = bill.TotalAmount;
            bill1.Note = bill.Note;
            bill1.TenNguoiNhan = bill.TenNguoiNhan;
            bill1.Tinh = bill.Tinh;
            bill1.Xa = bill1.Xa;
            bill1.Huyen = bill1.Huyen;
            bill1.DiaChiCuThe = bill1.DiaChiCuThe;
            bill1.Status = bill1.Status;
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
