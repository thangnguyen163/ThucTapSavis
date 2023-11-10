using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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

		public async Task<List<Bill_ShowModel>> GetAllBill()
		{
			var lst = (from a in context.Bills
					   join b in context.Users on a.UserId equals b.Id
					   select new Bill_ShowModel
					   {
						   Id = a.Id,
						   UserId = a.UserId,
						   UserName = b.UserName,
						   BillCode = a.BillCode,
						   TotalAmount = a.TotalAmount,
						   CreateDate = a.CreateDate,
						   ConfirmationDate = a.ConfirmationDate,
						   CompletionDate = a.CompletionDate,
						   Note = a.Note,
						   Status = a.Status,
						   Tinh=a.Tinh,
						   Huyen=a.Huyen,
						   Xa=a.Xa,
						   DiaChiCuThe= a.DiaChiCuThe,
						   TenNguoiNhan	=a.TenNguoiNhan,
						   SDTNhan=a.SDTNhan,
					   }).ToList();
			return lst;
		}

        public async Task<Bill> GetAllBillById(Guid Id)
        {
			var a = await context.Bills.FirstOrDefaultAsync(a => Id == Id);
			return a;
		}

        public async Task<List<Bill>> GetAllBillByUser(Guid Id)
		{
			var a = await context.Bills.Where(x => x.UserId == Id).ToListAsync();
			return a;
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
				a.DiaChiCuThe= bill.DiaChiCuThe;
				a.Tinh = bill.Tinh;
				a.Huyen = bill.Huyen;
				a.Xa = bill.Xa;
				a.SDTNhan = bill.SDTNhan;
				a.TenNguoiNhan= bill.TenNguoiNhan;
				context.Bills.Update(a);
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
