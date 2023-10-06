using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices CategoryServices;
        public CategoryController(ICategoryServices _CategoryServices)
        {
            CategoryServices = _CategoryServices;
        }
        [HttpGet("get_category")]
        public async Task<IActionResult> Get()
        {
            var a = await CategoryServices.GetAllCategory();
            return Ok(a);
        }
        [HttpGet("get_category_by_id")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var a = await CategoryServices.GetAllCategoryById(Id);
            return Ok(a);
        }
        [HttpPost("add_category")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var a = await CategoryServices.AddCategory(category);
            return Ok(a);
        }
        [HttpPut("update_category")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var a = await CategoryServices.UpdateCategory(category);
            return Ok(a);
        }
        [HttpDelete("delete_category")]
        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            var a = await CategoryServices.DeleteCategory(Id);
            return Ok();
        }   
    }
}
