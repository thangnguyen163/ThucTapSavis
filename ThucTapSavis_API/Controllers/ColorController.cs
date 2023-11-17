using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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
        public async Task<IActionResult> AddColor(Color_VM color)
        {
            Color color1 = new Color();
            color1.Id = color.Id;
            color1.Name = color.Name;
            color1.Status = 1;
            var a = await colorServices.AddColor(color1);
            return Ok(a);
        }
        [HttpPut("update_color")]
        public async Task<IActionResult> UpdateColor(Color_VM color)
        {
            Color color1 = new Color();
            color1.Id = color.Id;
            color1.Name = color.Name;
            color1.Status = color.Status;
            var a = await colorServices.UpdateColor(color1);
            return Ok(a);
        }
        [HttpDelete("delete_color/{Id}")]
        public async Task<IActionResult> DeleteColor(Guid Id)
        {
            var a = await colorServices.DeleteColor(Id);
            return Ok();
        }
    }
}
