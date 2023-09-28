using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
	public class SizeServices : ISizeServices
	{
		public MyDbContext context;
		public SizeServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<Size> AddSize(Size Size)
		{
			try
			{
				var a = await context.Sizes.AddAsync(Size);
				context.SaveChanges();
				return Size;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeleteSize(Guid Id)
		{
			try
			{
				var a = await context.Sizes.FindAsync(Id);
				context.Sizes.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<Size>> GetAllSize()
		{
			var a = await context.Sizes.ToListAsync();
			return a;
		}

		public async Task<List<Size>> GetAllSizeById(Guid Id)
		{
			var x = await context.Sizes.Where(c => c.Id == Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public Guid CategoryId { get; set; }
		//public int Status { get; set; }
		public async Task<Size> UpdateSize(Size Size)
		{
			try
			{
				var a = await context.Sizes.FindAsync(Size.Id);
				a.Name = Size.Name;
				a.Status = Size.Status;
				context.Sizes.Update(a);
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