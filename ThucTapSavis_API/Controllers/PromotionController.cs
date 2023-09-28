using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/Promotion")]
	[ApiController]
	public class PromotionController : ControllerBase
	{
		private readonly IPromotionServices _Promotion;
		public PromotionController(IPromotionServices Promotion)
		{
			_Promotion = Promotion;
		}

		[HttpGet]
		public async Task<List<Promotion>> GetAllPromotion()
		{
			var Promotion = await _Promotion.GetAllPromotion();
			return Promotion;
		}
		[HttpGet("{Id}")]
		public async Task<Promotion> GetPromotionById(Guid Id)
		{
			var x = await _Promotion.GetPromotionById(Id);
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public string Code { get; set; }
		//public string Percent { get; set; }
		//public int Quantity { get; set; }
		//public DateTime StartDate { get; set; }
		//public DateTime EndDate { get; set; }
		//public string Description { get; set; }
		//public string Discount_Conditions { get; set; }
		//public int Status { get; set; }
		[HttpPost("Add")]
		public async Task<ActionResult<Promotion>> PostPromotion(Promotion_VM rvm)
		{
			Promotion Promotion = new Promotion();
			Promotion.Id = Guid.NewGuid();
			Promotion.Name = rvm.Name;
			Promotion.Code = rvm.Code;
			Promotion.Percent = rvm.Percent;
			Promotion.Quantity = rvm.Quantity;
			Promotion.StartDate = rvm.StartDate;
			Promotion.EndDate = rvm.EndDate;
			Promotion.Description = rvm.Description;
			Promotion.Discount_Conditions = rvm.Discount_Conditions;
			Promotion.Status = rvm.Status;
			await _Promotion.AddPromotion(Promotion);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<Promotion>> PutPromotion(Promotion_VM rvm)
		{
			Promotion Promotion = await _Promotion.GetPromotionById(rvm.Id);
			Promotion.Name = rvm.Name;
			Promotion.Code = rvm.Code;
			Promotion.Percent = rvm.Percent;
			Promotion.Quantity = rvm.Quantity;
			Promotion.StartDate = rvm.StartDate;
			Promotion.EndDate = rvm.EndDate;
			Promotion.Description = rvm.Description;
			Promotion.Discount_Conditions = rvm.Discount_Conditions;
			Promotion.Status = rvm.Status;
			await _Promotion.UpdatePromotion(Promotion);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<Promotion>> Delete(Guid id)
		{
			await _Promotion.DeletePromotion(id);
			return Ok();
		}
	}
}
