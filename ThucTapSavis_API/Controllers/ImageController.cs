using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices ImageServices;
        public ImageController(IImageServices _ImageServices)
        {
            ImageServices = _ImageServices;
        }
        [HttpGet("get_Image")]
        public async Task<IActionResult> Get()
        {
            var a = await ImageServices.GetAllImage();
            return Ok(a);
        }
        [HttpGet("get_Image_By_Product_Item")]
        public async Task<IActionResult> GetAllImageByProductItem(Guid Id)
        {
            var a = await ImageServices.GetAllImageById(Id);
            return Ok(a);
        }
        [HttpGet("get_Image_by_id")]
        public async Task<IActionResult> GetImageById(Guid Id)
        {
            var a = await ImageServices.GetAllImageById(Id);
            return Ok(a);
        }
        [HttpPost("add_Image")]
        public async Task<IActionResult> AddImage(Image Image)
        {
            var a = await ImageServices.AddImage(Image);
            return Ok(a);
        }
        [HttpPut("update_Image")]
        public async Task<IActionResult> UpdateImage(Image Image)
        {
            var a = await ImageServices.UpdateImage(Image);
            return Ok(a);
        }
        [HttpDelete("delete_Image")]
        public async Task<IActionResult> DeleteImage(Guid Id)
        {
            var a = await ImageServices.DeleteImage(Id);
            return Ok();
        }
    }
}
