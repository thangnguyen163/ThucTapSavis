using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class ProductServices : IProductServices
	{
		public MyDbContext context;
		public ProductServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<Product> AddProduct(Product Product)
		{
			try
			{
				var a = await context.Products.AddAsync(Product);
				context.SaveChanges();
				return Product;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeleteProduct(Guid Id)
		{
			try
			{
				var a = await context.Products.FindAsync(Id);
				context.Products.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<Product>> GetAllProduct()
		{
			var a = await context.Products.ToListAsync();
			return a;
		}
		public async Task<Product> GetProductById(Guid Id)
		{
			var x = await context.Products.FirstOrDefaultAsync(c => c.Id == Id);
			return x;
		}
		public async Task<List<Product>> GetAllProductById(Guid Id)
		{
			var x = await context.Products.Where(c => c.Id == Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public Guid CategoryId { get; set; }
		//public int Status { get; set; }
		public async Task<Product> UpdateProduct(Product Product)
		{
			try
			{
				var a = await context.Products.FindAsync(Product.Id);
				a.Name = Product.Name;
				a.CategoryId = Product.CategoryId;
				a.Status = Product.Status;
				context.Products.Update(a);
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
