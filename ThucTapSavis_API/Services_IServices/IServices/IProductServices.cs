using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface IProductServices
    {
		public Task<Product> AddProduct(Product Product);
		public Task<Product> UpdateProduct(Product Product);
		public Task<bool> DeleteProduct(Guid Id);
		public Task<List<Product>> GetAllProduct();
		public Task<List<Product>> GetAllProductById(Guid Id);
		public Task<Product> GetProductById(Guid Id);
	}
}
