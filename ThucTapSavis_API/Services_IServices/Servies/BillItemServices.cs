using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class BillItemServices : IBillItemServies
    {
        public MyDbContext context;
        public BillItemServices(MyDbContext _context)
        {
            context = _context;
        }
        public async Task<BillItem> AddBillItem(BillItem billItem)
        {
            try
            {
                var a = await context.BillItems.AddAsync(billItem);
                context.SaveChanges();
                return billItem;
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public async Task<bool> DeleteBillItem(Guid Id)
        {
            try
            {
                var a = await context.BillItems.FindAsync(Id);
                context.BillItems.Remove(a);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<List<BillItem>> GetAllBillItem()
        {
            var a = await context.BillItems.ToListAsync();
            return a;
        }

        public async Task<List<BillItem>> GetAllBillItemByBill(Guid Id)
        {
            var a = await context.BillItems.Where(b => b.Id == Id).ToListAsync();
            return a;
        }

        public async Task<BillItem>GetAllBillItemById(Guid Id)
        {
            var a = await context.BillItems.FirstOrDefaultAsync(a=>Id == Id);
            return a;
        }

        public async Task<BillItem> UpdateBillItem(BillItem billItem)
        {
            try
            {
                var a = await context.BillItems.FindAsync(billItem.Id);
                a.ProductItemsId = billItem.ProductItemsId;
                a.BillId = billItem.BillId;
                a.Quantity = billItem.Quantity;
                a.Status = billItem.Status;
                context.BillItems.Update(a);
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
