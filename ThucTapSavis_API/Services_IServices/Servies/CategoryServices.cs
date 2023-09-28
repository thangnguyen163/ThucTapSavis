using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class CategoryServices : ICategoryServices
    {
        public MyDbContext context;
        public CategoryServices(MyDbContext _context)
        {
            context = _context;
        }

        public async Task<Category> AddCategory(Category Category)
        {
            try
            {
                var a = await context.Categories.AddAsync(Category);
                context.SaveChanges();
                return Category;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategory(Guid Id)
        {
            try
            {
                var a = await context.Categories.FindAsync(Id);
                a.Status = 0;
                context.Categories.Update(a);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var a = await context.Categories.ToListAsync();
            return a;
        }

        public async Task<Category> GetAllCategoryById(Guid Id)
        {
            var a = await context.Categories.FirstOrDefaultAsync(a => Id == Id);
            return a;
        }

        public async Task<Category> UpdateCategory(Category Category)
        {
            try
            {
                var a = await context.Categories.FindAsync(Category.Id);
                a.Status = Category.Status;
                a.Name = Category.Name;
                context.Categories.Update(a);
                context.SaveChanges();
                return a;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
