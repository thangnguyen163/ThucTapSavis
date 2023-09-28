using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface IPromotionServices
    {
		public Task<Promotion> AddPromotion(Promotion Promotion);
		public Task<Promotion> UpdatePromotion(Promotion Promotion);
		public Task<bool> DeletePromotion(Guid Id);
		public Task<List<Promotion>> GetAllPromotion();
		public Task<List<Promotion>> GetAllPromotionById(Guid Id);
	}
}
