using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorServices colorServices;
        public ColorController(IColorServices _colorServices)
        {
            colorServices = _colorServices;
        }
        [HttpGet("get_color")]
        public async Task<IActionResult> Get()
        {
            var a = await colorServices.GetAllColor();
            return Ok(a);
        }
        [HttpGet("get_color_by_id")]
        public async Task<IActionResult> GetColorById(Guid Id)
        {
            var a = await colorServices.GetAllColorById(Id);
            return Ok(a);
        }
        [HttpPost("add_color")]
        public async Task<IActionResult> AddColor(Color color)
        {
            var a = await colorServices.AddColor(color);
            return Ok(a);
        }
        [HttpPut("put_color")]
        public async Task<IActionResult> UpdateColor(Color color)
        {
            var a = await colorServices.UpdateColor(color);
            return Ok(a);
        }
        [HttpDelete("delete_color")]
        public async Task<IActionResult> DeleteColor(Guid Id)
        {
            var a = await colorServices.DeleteColor(Id);
            return Ok();
        }
    }
}
