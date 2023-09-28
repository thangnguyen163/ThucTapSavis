using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IProductItemServices
	{
		public Task<ProductItem> AddProductItem(ProductItem ProductItem);
		public Task<ProductItem> UpdateProductItem(ProductItem ProductItem);
		public Task<bool> DeleteProductItem(Guid Id);
		public Task<List<ProductItem>> GetAllProductItem();
		public Task<List<ProductItem>> GetAllProductItemById(Guid Id);
		public Task<ProductItem> GetProductItemById(Guid Id);
	}
}
