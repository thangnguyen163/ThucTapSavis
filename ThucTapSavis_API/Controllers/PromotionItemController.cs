﻿using Microsoft.AspNetCore.Mvc;
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

		[HttpGet("getPromotionItem_Percent_by_productItemID/{id}")]
		public async Task<PromotionItem_VM> GetAllPromotion(Guid id)
		{
			var x = await _PromotionItem.GetPercentPromotionItem(id);
			return x;
		}

		[HttpGet("{Id}")]
		public async Task<PromotionItem> GetPromotionItemById(Guid Id)
		{
			var x = await _PromotionItem.GetPromotionItemById(Id);
			return x;
		}
		[HttpGet("getLstPromotionItem_Percent_by_productItemID")]
		public async Task<List<PromotionItem_VM>> GetLstPercentPromotionItem()
		{
			var x = await _PromotionItem.GetLstPercentPromotionItem();
			return x;
		}
		[HttpGet("PromotionItem_By_Promotion/{Id}")]
		public async Task<List<PromotionItem>> GetAllPromotionItemById(Guid Id)
		{
			var x = await _PromotionItem.GetAllPromotionItemById(Id);
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
			PromotionItem.Id = rvm.Id;
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

		[HttpDelete("delete_promotionItem_byId/{Id}")]
		public async Task<ActionResult<PromotionItem>> Delete(Guid Id)
		{
			await _PromotionItem.DeletePromotionItem(Id);
			return Ok();
		}

		[HttpDelete("PromotionItemByProductItem/{Id}")]
		public async Task<ActionResult<PromotionItem>> DeletePromotionItemByProductItemId(Guid Id)
		{
			await _PromotionItem.DeletePromotionItemByProductItemId(Id);
			return Ok();
		}

		[HttpDelete("PromotionItemByPromotionId/{Id}")]
		public async Task<ActionResult<PromotionItem>> DeletePromotionItemByPomotionId(Guid Id)
		{
			await _PromotionItem.DeletePromotionItemByPomotionId(Id);
			return Ok();
		}
	}
}