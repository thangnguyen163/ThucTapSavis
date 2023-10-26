using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IPromotionItemServices
	{
		public Task<PromotionItem> AddPromotionItem(PromotionItem PromotionItem);
		public Task<PromotionItem> UpdatePromotionItem(PromotionItem PromotionItem);
		public Task<bool> DeletePromotionItem(Guid Id);
		public Task<List<PromotionItem>> GetAllPromotionItem();
		public Task<List<PromotionItem>> GetAllPromotionItemById(Guid Id);
		public Task<PromotionItem> GetPromotionItemById(Guid Id);

		public Task<bool> DeletePromotionItemByProductItemId(Guid Id);
		public Task<bool> DeletePromotionItemByPomotionId(Guid Id);
	}
}
