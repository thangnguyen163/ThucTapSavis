using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface ICartServices
    {
        public Task<Cart> AddCart(Cart Cart);
        public Task<Cart> UpdateCart(Cart Cart);
        public Task<bool> DeleteCart(Guid Id);
        public Task<List<Cart>> GetAllCart();
        public Task<Cart> GetCartById(Guid Id);

    }
}
