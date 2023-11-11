using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/image")]
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
		[HttpGet("get_Image_Join_PI")]
		public async Task<IActionResult> Get_Image_Join_PI()
		{
            var a = await ImageServices.GetAllImage_PrductItem();
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
        public async Task<IActionResult> AddImage(Image_VM Image)
        {
            Image image = new Image();
            image.Id=Image.Id;
            image.Name=Image.Name;
            image.Status=Image.Status;
            image.PathImage=Image.PathImage;
            image.ProductItemId=Image.ProductItemId;
            
            var a = await ImageServices.AddImage(image);
            return Ok(a);
        }
        [HttpPut("update_Image")]
        public async Task<IActionResult> UpdateImage(Image_VM Image)
        {
            Image image = new Image();
            image.Name = Image.Name;
            image.Status = Image.Status;
            image.PathImage = Image.PathImage;
            image.ProductItemId = Image.ProductItemId;
            var a = await ImageServices.UpdateImage(image);
            return Ok(a);
        }
        [HttpDelete("delete_Image/{Id}")]
        public async Task<IActionResult> DeleteImage(Guid Id)
        {
            var a = await ImageServices.DeleteImage(Id);
            return Ok();
        }
    }
}
