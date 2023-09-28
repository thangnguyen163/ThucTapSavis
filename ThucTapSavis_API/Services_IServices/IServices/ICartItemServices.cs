using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface ICartItemServices
    {
        public Task<CartItem> AddCartItem(CartItem CartItem);
        public Task<CartItem> UpdateCartItem(CartItem CartItem);
        public Task<bool> DeleteCartItem(Guid Id);
        public Task<List<CartItem>> GetAllCartItem();
        public Task<List<CartItem>> GetAllCartItemByCart(Guid Id);
    }
}
