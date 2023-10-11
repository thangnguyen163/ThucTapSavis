using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/ProductItem")]
	[ApiController]
	public class ProductItemController : ControllerBase
	{
		private readonly IProductItemServices _ProductItem;
		public ProductItemController(IProductItemServices ProductItem)
		{
			_ProductItem = ProductItem;
		}

		[HttpGet]
		public async Task<List<ProductItem>> GetAllProductItem()
		{
			var ProductItem = await _ProductItem.GetAllProductItem();
			return ProductItem;
		}
        [HttpGet("show")]
        public async Task<List<ProductItem_Show_VM>> GetAllProductItem_Show()
        {
            var ProductItem = await _ProductItem.GetAllProductItem_Show();
            return ProductItem;
        }
        [HttpGet("{Id}")]
		public async Task<ProductItem> GetProductItemById(Guid Id)
		{
			var x = await _ProductItem.GetProductItemById(Id);
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
		[HttpPost("Add")]
		public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem_VM rvm)
		{
			ProductItem ProductItem = new ProductItem();
			ProductItem.Id = rvm.Id;
			ProductItem.ProductId = rvm.ProductId;
			ProductItem.ColorId = rvm.ColorId;
			ProductItem.SizeId = rvm.SizeId;
			ProductItem.AvaiableQuantity = rvm.AvaiableQuantity;
			ProductItem.PurchasePrice = rvm.PurchasePrice;
			ProductItem.CostPrice = rvm.CostPrice;
			ProductItem.Status = rvm.Status;
			await _ProductItem.AddProductItem(ProductItem);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<ProductItem>> PutProductItem(ProductItem_VM rvm)
		{
			ProductItem ProductItem = await _ProductItem.GetProductItemById(rvm.Id);
			ProductItem.ProductId = rvm.ProductId;
			ProductItem.ColorId = rvm.ColorId;
			ProductItem.SizeId = rvm.SizeId;
			ProductItem.AvaiableQuantity = rvm.AvaiableQuantity;
			ProductItem.PurchasePrice = rvm.PurchasePrice;
			ProductItem.CostPrice = rvm.CostPrice;
			ProductItem.Status = rvm.Status;
			await _ProductItem.UpdateProductItem(ProductItem);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<ProductItem>> Delete(Guid id)
		{
			await _ProductItem.DeleteProductItem(id);
			return Ok();
		}
	}
}
