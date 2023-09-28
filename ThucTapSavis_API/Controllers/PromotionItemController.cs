using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/PromotionItem")]
	[ApiController]
	public class PromotionItemController : ControllerBase
	{
		private readonly IPromotionItemServices _PromotionItem;
		public PromotionItemController(IPromotionItemServices PromotionItem)
		{
			_PromotionItem = PromotionItem;
		}

		[HttpGet]
		public async Task<List<PromotionItem>> GetAllPromotionItem()
		{
			var PromotionItem = await _PromotionItem.GetAllPromotionItem();
			return PromotionItem;
		}
		[HttpGet("{Id}")]
		public async Task<PromotionItem> GetPromotionItemById(Guid Id)
		{
			var x = await _PromotionItem.GetPromotionItemById(Id);
			return x;
		}
		//public Guid Id { get; set; }
		//public Guid PromotionsId { get; set; }
		//public Guid ProductItemsId { get; set; }
		//public int Status { get; set; }
		[HttpPost("Add")]
		public async Task<ActionResult<PromotionItem>> PostPromotionItem(PromotionItem_VM rvm)
		{
			PromotionItem PromotionItem = new PromotionItem();
			PromotionItem.Id = Guid.NewGuid();
			PromotionItem.PromotionsId = rvm.PromotionsId;
			PromotionItem.ProductItemsId = rvm.ProductItemsId;
			PromotionItem.Status = rvm.Status;
			await _PromotionItem.AddPromotionItem(PromotionItem);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<PromotionItem>> PutPromotionItem(PromotionItem_VM rvm)
		{
			PromotionItem PromotionItem = await _PromotionItem.GetPromotionItemById(rvm.Id);
			PromotionItem.PromotionsId = rvm.PromotionsId;
			PromotionItem.ProductItemsId = rvm.ProductItemsId;
			PromotionItem.Status = rvm.Status;
			await _PromotionItem.UpdatePromotionItem(PromotionItem);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<PromotionItem>> Delete(Guid id)
		{
			await _PromotionItem.DeletePromotionItem(id);
			return Ok();
		}
	}
}
