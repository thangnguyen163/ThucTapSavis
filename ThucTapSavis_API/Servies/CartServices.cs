using ThucTapSavis_API.Data;
using ThucTapSavis_API.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Servies
{
    public class CartServices : ICartServices
    {
        public MyDbContext context;
        public CartServices(MyDbContext _context)
        {
            context = _context;
        }
        public async Task<Cart> AddCart(Cart Cart)
        {
            try
            {
                var a = await context.Carts.AddAsync(Cart);
                context.SaveChanges();
                return Cart;
                     
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCart(Guid Id)
        {
            try
            {
                var a = await context.Carts.FindAsync(Id);
                a.Status = 0;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<Cart>> GetAllCart()
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> UpdateCart(Cart Cart)
        {
            try
            {
                var a = await context.Carts.FindAsync(Cart.UserId);
                a.Status = Cart.Status;
                a.Description = Cart.Description;
                context.SaveChanges();
                return Cart;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
