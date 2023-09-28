using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/billitem")]
    [ApiController]
    public class BillItemController : ControllerBase
    {
        private readonly IBillItemServies _billItemServies;
        public BillItemController(IBillItemServies billItemServies)
        {
            _billItemServies = billItemServies;
        }
        [HttpGet("get_billitem")]
        public async Task<IActionResult> GetAllBillItem()
        {
            var a = await _billItemServies.GetAllBillItem();
            return Ok(a);
        }
        [HttpGet("get_billitem_byBill")]
        public async Task<IActionResult> GetAllBillItemByBill(Guid Id)
        {
            var a = await _billItemServies.GetAllBillItemByBill(Id);
            return Ok(a);
        }
        [HttpPost("add_billitem")]
        public async Task<IActionResult> AddBillItem(BillItem billItem)
        {
            var a = await _billItemServies.AddBillItem(billItem);
            return Ok(a);
        }
        [HttpPut("update_billitem")]
        public async Task<IActionResult> UpdateBillItem(BillItem billItem)
        {
            var a = await _billItemServies.UpdateBillItem(billItem);
            return Ok(a);
        }
        [HttpDelete("delete_billitem")]
        public async Task<IActionResult> DeleteBillItem(Guid id)
        {
            var a = await _billItemServies.DeleteBillItem(id);
            return Ok(a);
        }

    }
}
