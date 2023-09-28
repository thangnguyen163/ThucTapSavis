using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class PromotionItemServices : IPromotionItemServices
    {
		public MyDbContext context;
		public PromotionItemServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<PromotionItem> AddPromotionItem(PromotionItem PromotionItem)
		{
			try
			{
				var a = await context.PromotionsItem.AddAsync(PromotionItem);
				context.SaveChanges();
				return PromotionItem;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeletePromotionItem(Guid Id)
		{
			try
			{
				var a = await context.PromotionsItem.FindAsync(Id);
				context.PromotionsItem.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<PromotionItem>> GetAllPromotionItem()
		{
			var a = await context.PromotionsItem.ToListAsync();
			return a;
		}
		public async Task<PromotionItem> GetPromotionItemById(Guid Id)
		{
			var x = await context.PromotionsItem.FirstOrDefaultAsync(c => c.Id == Id);
			return x;
		}
		public async Task<List<PromotionItem>> GetAllPromotionItemById(Guid Id)
		{
			var x = await context.PromotionsItem.Where(c => c.Id == Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public Guid PromotionsId { get; set; }
		//public Guid ProductItemsId { get; set; }
		//public int Status { get; set; }
		public async Task<PromotionItem> UpdatePromotionItem(PromotionItem PromotionItem)
		{
			try
			{
				var a = await context.PromotionsItem.FindAsync(PromotionItem.Id);
				a.PromotionsId = PromotionItem.PromotionsId;
				a.ProductItemsId = PromotionItem.ProductItemsId;
				a.Status = PromotionItem.Status;
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
