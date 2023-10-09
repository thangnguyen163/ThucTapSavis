using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices cartServices;
        public CartController(ICartServices _cartServices)
        {
            cartServices = _cartServices;
        }
        [HttpGet("get_cart")]
        public async Task<IActionResult> Get()
        {
            var a = await cartServices.GetAllCart();
            return Ok(a);
        }
        [HttpGet("get_cart_by_id")]
        public async Task<IActionResult> GetCartById(Guid Id)
        {
            var a = await cartServices.GetCartById(Id);
            return Ok(a);
        }
        [HttpPost("add_cart")]
        public async Task<IActionResult> AddCart(Cart_VM cart)
        {
            Cart cart1 = new Cart();
            cart1.UserId = cart.UserId;
            cart1.Description = cart.Description;
            cart1.Status = cart.Status;
            var a = await cartServices.AddCart(cart1);
            return Ok(a);
        }
        [HttpPut("update_cart")]
        public async Task<IActionResult> UpdateCart(Cart_VM cart)
        {
            Cart cart1 = new Cart();
            cart1.Description = cart.Description;
            cart1.Status = cart.Status;
            var a = await cartServices.UpdateCart(cart1);
            return Ok(a);
        }
        [HttpDelete("delete_cart")]
        public async Task<IActionResult> DeleteCart(Guid Id)
        {
            var a = await cartServices.DeleteCart(Id);
            return Ok();
        }
    }
}
