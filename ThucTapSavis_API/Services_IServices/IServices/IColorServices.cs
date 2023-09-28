using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IColorServices
	{
		public Task<Color> AddColor(Color color);
		public Task<Color> UpdateColor(Color color);
		public Task<bool> DeleteColor(Guid Id);
		public Task<List<Color>> GetAllColor();
		public Task<List<Color>> GetAllColorById(Guid Id);
	}
}
