using ThucTapSavis_Shared.ViewModel.Momo;
using ThucTapSavis_Shared.ViewModel.Momo.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_API.Services_IServices.IServices;

namespace ThucTapSavis_API.Controllers
{
    [Route("api/Momo")]
    [ApiController]
    public class MomoController : ControllerBase
    {
        private IMomoService _momoService;

        public MomoController(IMomoService momoService)
        {
            _momoService = momoService;
        }
        [HttpPost("CreatePaymentAsync")]
        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model)
        {
            try
            {
                var x = await _momoService.CreatePaymentAsync(model);
                return x;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
