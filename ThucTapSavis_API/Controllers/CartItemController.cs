using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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
        [HttpGet("get_cartitem_by_id")]
        public async Task<IActionResult> GetCartItemById(Guid Id)
        {
            var a = await cartItemServies.GetAllCartItemById(Id);
            return Ok(a);
        }
        [HttpPost("add_cartitem")]
        public async Task<IActionResult> AddCartItem(CartItem_VM CartItem)
        {
            CartItem cartItem1=new CartItem();
            cartItem1.Id = CartItem.Id;
            cartItem1.ProductItemId = CartItem.ProductItemId;
            cartItem1.UserId= CartItem.UserId;
            cartItem1.Price = CartItem.Price;
            cartItem1.Quantity = CartItem.Quantity;
            cartItem1.Status = CartItem.Status;
            var a = await cartItemServies.AddCartItem(cartItem1);
            return Ok(a);
        }
        [HttpPut("update_cartitem")]
        public async Task<IActionResult> UpdateCartItem(CartItem CartItem)
        {
            CartItem cartItem1 = new CartItem();
            cartItem1.ProductItemId = CartItem.ProductItemId;
            cartItem1.UserId = CartItem.UserId;
            cartItem1.Price = CartItem.Price;
            cartItem1.Quantity = CartItem.Quantity;
            cartItem1.Status = CartItem.Status;
            var a = await cartItemServies.UpdateCartItem(cartItem1);
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
