using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.IServices
{
    public interface IImageServices
    {
        public Task<Image> AddImage(Image image);
        public Task<Image> UpdateImage(Image image);
        public Task<bool> DeleteImage(Guid Id);
        public Task<List<Image>> GetAllImage();
        public Task<List<Image>> GetAllImageById(Guid Id);
    }
}
