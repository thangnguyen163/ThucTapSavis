using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

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
        [HttpGet("get_category_by_id/{Id}")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var a = await CategoryServices.GetAllCategoryById(Id);
            return Ok(a);
        }
        [HttpPost("add_category")]
        public async Task<IActionResult> AddCategory(Category_VM category)
        {
            Category category1 = new Category();
            category1.Id=category.Id;
            category1.Name=category.Name;
            category1.Status=1;
            var a = await CategoryServices.AddCategory(category1);
            return Ok(a);
        }
        [HttpPut("update_category")]
        public async Task<IActionResult> UpdateCategory(Category_VM category)
        {
            Category category1 = new Category();
            category1.Name = category.Name;
            category1.Status = category.Status;
            var a = await CategoryServices.UpdateCategory(category1);
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
