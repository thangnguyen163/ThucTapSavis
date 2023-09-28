using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/Product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductServices _Product;
		public ProductController(IProductServices Product)
		{
			_Product = Product;
		}

		[HttpGet]
		public async Task<List<Product>> GetAllProduct()
		{
			var Product = await _Product.GetAllProduct();
			return Product;
		}
		[HttpGet("{Id}")]
		public async Task<Product> GetProductById(Guid Id)
		{
			var x = await _Product.GetProductById(Id);
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public Guid CategoryId { get; set; }
		//public int Status { get; set; }
		[HttpPost("Add")]
		public async Task<ActionResult<Product>> PostProduct(Product_VM rvm)
		{
			Product Product = new Product();
			Product.Id = Guid.NewGuid();
			Product.Name = rvm.Name;
			Product.CategoryId = rvm.CategoryId;
			Product.Status = rvm.Status;
			await _Product.AddProduct(Product);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<Product>> PutProduct(Product_VM rvm)
		{
			Product Product = await _Product.GetProductById(rvm.Id);
			Product.Name = rvm.Name;
			Product.CategoryId = rvm.CategoryId;
			Product.Status = rvm.Status;
			await _Product.UpdateProduct(Product);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<Product>> Delete(Guid id)
		{
			await _Product.DeleteProduct(id);
			return Ok();
		}
	}
}
