using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class ProductItemServices : IProductItemServices
    {
		public MyDbContext context;
		public ProductItemServices(MyDbContext _context)
		{
			context = _context;
		}
		public async Task<ProductItem> AddProductItem(ProductItem ProductItem)
		{
			try
			{
				var a = await context.ProductItems.AddAsync(ProductItem);
				context.SaveChanges();
				return ProductItem;
			}
			catch (Exception e)
			{

				return null;
			}

		}

		public async Task<bool> DeleteProductItem(Guid Id)
		{
			try
			{
				var a = await context.ProductItems.FindAsync(Id);
				context.ProductItems.Remove(a);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<List<ProductItem>> GetAllProductItem()
		{
			var a = await context.ProductItems.ToListAsync();
			return a;
		}

		public async Task<List<ProductItem>> GetAllProductItemById(Guid Id)
		{
			var x = await context.ProductItems.Where(c=>c.Id ==Id).ToListAsync();
			return x;
		}
		//public Guid Id { get; set; }
		//public Guid ProductId { get; set; }
		//public Guid ColorId { get; set; }
		//public Guid SizeId { get; set; }
		//public int AvaiableQuantity { get; set; }
		//public int PurchasePrice { get; set; }
		//public int CostPrice { get; set; }
		//public int Status { get; set; }
		public async Task<ProductItem> UpdateProductItem(ProductItem ProductItem)
		{
			try
			{
				var a = await context.ProductItems.FindAsync(ProductItem.Id);
				a.ProductId = ProductItem.ProductId;
				a.ColorId = ProductItem.ColorId;
				a.SizeId = ProductItem.SizeId;
				a.AvaiableQuantity = ProductItem.AvaiableQuantity;
				a.PurchasePrice = ProductItem.PurchasePrice;
				a.CostPrice = ProductItem.CostPrice;
				a.Status = ProductItem.Status;
				context.ProductItems.Update(a);
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
