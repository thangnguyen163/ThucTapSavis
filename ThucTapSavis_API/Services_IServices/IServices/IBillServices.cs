using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IBillServices
	{
		public Task<Bill> AddBill(Bill bill);
		public Task<Bill> UpdateBill(Bill bill);
		public Task<bool> DeleteBill(Guid Id);
		public Task<Bill> GetAllBillById(Guid Id);
		public Task<List<Bill>> GetAllBillByUser(Guid Id);
		public Task<List<Bill_ShowModel>> GetAllBill();
		public Task<List<Bill>> GetAllBill_VM();
	}
}
