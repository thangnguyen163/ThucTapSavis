using ThucTapSavis_Shared.ViewModel.Momo;
using ThucTapSavis_Shared.ViewModel.Momo.Order;

namespace ThucTapSavis_API.Services_IServices.IServices
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model);
    }
}
