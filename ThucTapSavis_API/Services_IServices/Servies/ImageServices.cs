using Microsoft.EntityFrameworkCore;
using ThucTapSavis_API.Data;
using ThucTapSavis_API.Services_IServices.IServices;
using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.Services_IServices.Servies
{
    public class ImageServices : IImageServices
    {
        public MyDbContext context;
        public ImageServices(MyDbContext _context)
        {
            context = _context;
        }
        public async Task<Image> AddImage(Image image)
        {
            try
            {
                var a = await context.Images.AddAsync(image);
                context.SaveChanges();
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteImage(Guid Id)
        {
            try
            {
                var a = await context.Images.FindAsync(Id);
                context.Images.Remove(a);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Image>> GetAllImage()
        {
            var a = await context.Images.ToListAsync();
            return a;
        }

        public async Task<Image> GetAllImageById(Guid Id)
        {
            var a = await context.Images.FirstOrDefaultAsync(a => Id == Id);
            return a;
        }

        public async Task<List<Image>> GetAllImageByProduct(Guid Id)
        {
            var a = await context.Images.Where(x => x.ProductItemId == Id).ToListAsync();
            return a;
        }

        public async Task<Image> UpdateImage(Image image)
        {
            try
            {
                var a = await context.Images.FindAsync(image.Id);
                a.Status = image.Status;
                a.Name = image.Name;
                a.PathImage = image.PathImage;
                a.ProductItemId = image.ProductItemId;
                context.Images.Update(a);
                context.SaveChanges();
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
