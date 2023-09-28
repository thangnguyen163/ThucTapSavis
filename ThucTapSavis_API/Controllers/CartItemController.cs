using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/cartitem")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemServices cartItemServies;
        public CartItemController(ICartItemServices _cartItemServies)
        {
            cartItemServies = _cartItemServies;
        }
        [HttpGet("get_cartitem")]
        public async Task<IActionResult> GetAllCartItem()
        {
            var a = await cartItemServies.GetAllCartItem();
            return Ok(a);
        }
        [HttpGet("get_cartitem_byCart")]
        public async Task<IActionResult> GetAllCartItemByCart(Guid Id)
        {
            var a = await cartItemServies.GetAllCartItemByCart(Id);
            return Ok(a);
        }
        [HttpPost("add_cartitem")]
        public async Task<IActionResult> AddCartItem(CartItem CartItem)
        {
            var a = await cartItemServies.AddCartItem(CartItem);
            return Ok(a);
        }
        [HttpPut("update_cartitem")]
        public async Task<IActionResult> UpdateCartItem(CartItem CartItem)
        {
            var a = await cartItemServies.UpdateCartItem(CartItem);
            return Ok(a);
        }
        [HttpDelete("delete_cartitem")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            var a = await cartItemServies.DeleteCartItem(id);
            return Ok(a);
        }
    }
}
