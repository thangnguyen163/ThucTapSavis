using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class CartItemServices : ICartItemServices
    {
        public MyDbContext context;
        public CartItemServices(MyDbContext _context)
        {
            context = _context;
        }
        public async Task<CartItem> AddCartItem(CartItem CartItem)
        {
            try
            {
                var a = await context.CartItems.AddAsync(CartItem);
                context.SaveChanges();
                return CartItem;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCartItem(Guid Id)
        {
            try
            {
                var a = await context.CartItems.FindAsync(Id);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CartItem>> GetAllCartItem()
        {
            try
            {
                var a = await context.CartItems.ToListAsync();
                return a;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<List<CartItem>> GetAllCartItemByCart(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> UpdateCartItem(CartItem CartItem)
        {
            try
            {
                var a = await context.CartItems.FindAsync(CartItem.Id);
                a.Status = CartItem.Status;
                a.ProductItemId = CartItem.ProductItemId;
                a.Quantity = CartItem.Quantity;
                a.Price = CartItem.Price;
                context.CartItems.Update(a);
                context.SaveChanges();
                return a;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
