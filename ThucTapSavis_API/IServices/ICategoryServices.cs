using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.IServices
{
    public interface ICategoryServices
    {
        public Task<Category> AddCategory(Category Category);
        public Task<Category> UpdateCategory(Category Category);
        public Task<bool> DeleteCategory(Guid Id);
        public Task<List<Category>> GetAllCategory();
        public Task<List<Category>> GetAllCategoryById(Guid Id);
    }
}
