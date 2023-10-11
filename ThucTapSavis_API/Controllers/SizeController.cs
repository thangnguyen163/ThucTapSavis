using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
	[Route("api/Size")]
	[ApiController]
	public class SizeController : ControllerBase
	{
		private readonly ISizeServices _Size;
		public SizeController(ISizeServices Size)
		{
			_Size = Size;
		}

		[HttpGet("get_size")]
		public async Task<List<Size>> GetAllSize()
		{
			var Size = await _Size.GetAllSize();
			return Size;
		}
		[HttpGet("{Id}")]
		public async Task<Size> GetSizeById(Guid Id)
		{
			var x = await _Size.GetSizeById(Id);
			return x;
		}
		//public Guid Id { get; set; }
		//public string Name { get; set; }
		//public int Status { get; set; }
		[HttpPost("Add")]
		public async Task<ActionResult<Size>> PostSize(Size_VM rvm)
		{
			Size Size = new Size();
			Size.Id = Guid.NewGuid();
			Size.Name = rvm.Name;
			Size.Status = rvm.Status;
			await _Size.AddSize(Size);
			return Ok();
		}
		[HttpPut("update")]
		public async Task<ActionResult<Size>> PutSize(Size_VM rvm)
		{
			Size Size = await _Size.GetSizeById(rvm.Id);
			Size.Name = rvm.Name;
			Size.Status = rvm.Status;
			await _Size.UpdateSize(Size);
			return Ok();
		}
		[HttpDelete("Id")]
		public async Task<ActionResult<Size>> Delete(Guid id)
		{
			await _Size.DeleteSize(id);
			return Ok();
		}
	}
}
