using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
	public class BillServices : IBillServices
	{
		public MyDbContext context;
		public BillServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<Bill> AddBill(Bill bill)
		{
			try
			{
				var a = await context.Bills.AddAsync(bill);
				context.SaveChanges();
				return bill;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<bool> DeleteBill(Guid Id)
		{
			try
			{
				var a = await context.Bills.FindAsync(Id);
				context.Bills.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<Bill>> GetAllBill()
		{
			var a = await context.Bills.ToListAsync();
			return a;
		}

		public Task<List<Bill>> GetAllBillByUser(Guid Id)
		{
			throw new NotImplementedException();
		}

		public async Task<Bill> UpdateBill(Bill bill)
		{
			try
			{
				var a = await context.Bills.FindAsync(bill.Id);
				a.Status = bill.Status;
				a.Note = bill.Note;
				a.CreateDate = bill.CreateDate;
				a.TotalAmount = bill.TotalAmount;
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
