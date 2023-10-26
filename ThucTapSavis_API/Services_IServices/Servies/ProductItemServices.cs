using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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
			var x = await context.ProductItems.Where(c => c.Id == Id).ToListAsync();
			return x;
		}

		//public Guid Id { get; set; }
		//public Guid ProductId { get; set; }
		//public string Name { get; set; }
		//public Guid ColorId { get; set; }
		//public string ColorName { get; set; }
		//public Guid SizeId { get; set; }
		//public string SizeName { get; set; }
		//public Guid CategoryID { get; set; }
		//public string CategoryName { get; set; }
		//public int AvaiableQuantity { get; set; }
		//public int PurchasePrice { get; set; }
		//public int CostPrice { get; set; }
		//public int Status { get; set; }
		public async Task<List<ProductItem_Show_VM>> GetAllProductItem_Show()
		{
			var list = (from prI in await context.ProductItems.ToListAsync()
						join pr in await context.Products.ToListAsync() on prI.ProductId equals pr.Id
						join s in await context.Sizes.ToListAsync() on prI.SizeId equals s.Id
						join c in await context.Colors.ToListAsync() on prI.ColorId equals c.Id
						join cate in await context.Categories.ToListAsync() on pr.CategoryId equals cate.Id
						select new ProductItem_Show_VM()
						{
							Id = prI.Id,
							ProductId = prI.ProductId,
							Name = pr.Name,
							ColorId = prI.ColorId,
							ColorName = c.Name,
							SizeId = prI.SizeId,
							SizeName = s.Name,
							CategoryID = pr.CategoryId,
							CategoryName = cate.Name,
							AvaiableQuantity = prI.AvaiableQuantity,
							PurchasePrice = prI.PurchasePrice,
							CostPrice = prI.CostPrice,
							Status = prI.Status,
						}).ToList();
			return list;
		}



		public async Task<List<ProductItem_Show_VM>> GetAllProductItemPromotionItem_Show(Guid Id)
		{
			var list = (from prI in await context.ProductItems.ToListAsync()
						join pr in await context.Products.ToListAsync() on prI.ProductId equals pr.Id
						join s in await context.Sizes.ToListAsync() on prI.SizeId equals s.Id
						join c in await context.Colors.ToListAsync() on prI.ColorId equals c.Id
						join cate in await context.Categories.ToListAsync() on pr.CategoryId equals cate.Id
						join h in await context.PromotionsItem.ToListAsync() on prI.Id equals h.ProductItemsId
						select new ProductItem_Show_VM()
						{
							Id = prI.Id,
							ProductId = prI.ProductId,
							Name = pr.Name,
							ColorId = prI.ColorId,
							ColorName = c.Name,
							SizeId = prI.SizeId,
							SizeName = s.Name,
							CategoryID = pr.CategoryId,
							CategoryName = cate.Name,
							AvaiableQuantity = prI.AvaiableQuantity,
							PurchasePrice = prI.PurchasePrice,
							CostPrice = prI.CostPrice,
							Status = prI.Status,
							PromotionItemId = h.PromotionsId,
						}).Where(x => x.PromotionItemId == Id).ToList();
			return list;
		}


		public async Task<ProductItem> GetProductItemById(Guid Id)
		{
			var x = await context.ProductItems.FirstOrDefaultAsync(c=>c.Id == Id);
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
