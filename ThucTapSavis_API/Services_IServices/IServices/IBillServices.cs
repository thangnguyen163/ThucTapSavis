using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IBillServices
	{
		public Task<Bill> AddBill(Bill bill);
		public Task<Bill> UpdateBill(Bill bill);
		public Task<bool> DeleteBill(Guid Id);
		public Task<List<Bill>> GetAllBill();
		public Task<List<Bill>> GetAllBillByUser(Guid Id);
	}
}
