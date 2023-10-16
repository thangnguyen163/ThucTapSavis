using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class PromotionServices : IPromotionServices
    {
		public MyDbContext context;
		public PromotionServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<Promotion> AddPromotion(Promotion Promotion)
		{
			try
			{
				var a = await context.Promotions.AddAsync(Promotion);
				context.SaveChanges();
				return Promotion;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeletePromotion(Guid Id)
		{
			try
			{
				var a = await context.Promotions.FindAsync(Id);
				context.Promotions.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<Promotion>> GetAllPromotion()
		{
			var a = await context.Promotions.ToListAsync();
			return a;
		}
		public async Task<Promotion> GetPromotionById(Guid Id)
		{
			var x = await context.Promotions.FirstOrDefaultAsync(c => c.Id == Id);
			return x;
		}
		public async Task<List<Promotion>> GetAllPromotionById(Guid Id)
		{
			var x = await context.Promotions.Where(c => c.Id == Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public string Code { get; set; }
		//public string Percent { get; set; }
		//public int Quantity { get; set; }
		//public DateTime StartDate { get; set; }
		//public DateTime EndDate { get; set; }
		//public string Description { get; set; }
		//public string Discount_Conditions { get; set; }
		//public int Status { get; set; }
		public async Task<Promotion> UpdatePromotion(Promotion Promotion)
		{
			try
			{
				var a = await context.Promotions.FindAsync(Promotion.Id);
				a.Name = Promotion.Name;
				a.Percent = Promotion.Percent;
				a.Quantity = Promotion.Quantity;
				a.StartDate = Promotion.StartDate;
				a.EndDate = Promotion.EndDate;
				a.Description = Promotion.Description;
				a.Status = Promotion.Status;
				context.Promotions.Update(a);
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
