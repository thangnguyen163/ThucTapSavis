using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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
			var x = await context.PromotionsItem.Where(c => c.PromotionsId == Id).ToListAsync();
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

		public async Task<bool> DeletePromotionItemByProductItemId(Guid ProductItemId)
		{
            try
            {
				var a = await context.PromotionsItem.FirstOrDefaultAsync(x => x.ProductItemsId == ProductItemId);
				context.PromotionsItem.Remove(a);
				context.SaveChanges();
				return true;
			}
            catch (Exception)
            {
				return false;
            }
		}

        public async Task<bool> DeletePromotionItemByPomotionId(Guid Id)
        {
			try
			{
				var a = await context.PromotionsItem.FirstOrDefaultAsync(x => x.PromotionsId == Id);
				context.PromotionsItem.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

        public async Task<PromotionItem_VM> GetPercentPromotionItem(Guid id)
        {
			var _lst = await (from a in context.PromotionsItem
						join b in context.Promotions on a.PromotionsId equals b.Id
						join c in context.ProductItems on a.ProductItemsId equals c.Id
						select new PromotionItem_VM
						{
							Id = a.Id,
							ProductItemsId=a.ProductItemsId,
							Percent=b.Percent,
							PromotionsId=a.Id,
							Status=a.Status,
							ProductId = c.ProductId
						}).FirstOrDefaultAsync(a=>a.ProductItemsId==id||a.ProductId==id);
			return _lst;
        }

		public async Task<List<PromotionItem_VM>> GetLstPercentPromotionItem()
		{
			var _lst = await(from a in context.PromotionsItem
							 join b in context.Promotions on a.PromotionsId equals b.Id
							 join c in context.ProductItems on a.ProductItemsId equals c.Id
							 select new PromotionItem_VM
							 {
								 Id = a.Id,
								 ProductItemsId = a.ProductItemsId,
								 Percent = b.Percent,
								 PromotionsId = a.Id,
								 Status = a.Status,
								 ProductId = c.ProductId
							 }).ToListAsync();
			return _lst;
		}
	}
}
