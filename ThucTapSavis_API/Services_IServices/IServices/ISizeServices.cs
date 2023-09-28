using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface ISizeServices
    {
		public Task<Size> AddSize(Size Size);
		public Task<Size> UpdateSize(Size Size);
		public Task<bool> DeleteSize(Guid Id);
		public Task<List<Size>> GetAllSize();
		public Task<List<Size>> GetAllSizeById(Guid Id);
		public Task<Size> GetSizeById(Guid Id);
	}
}
