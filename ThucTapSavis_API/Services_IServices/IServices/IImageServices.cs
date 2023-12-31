﻿using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface IImageServices
    {
        public Task<Image> AddImage(Image image);
        public Task<Image> UpdateImage(Image image);
        public Task<bool> DeleteImage(Guid Id);
        public Task<List<Image>> GetAllImage();
        public Task<Image> GetAllImageById(Guid Id);
        public Task<List<Image>> GetAllImageByProduct(Guid Id);
        public Task<List<Image_Join_ProductItem>> GetAllImage_PrductItem();
    }
}
