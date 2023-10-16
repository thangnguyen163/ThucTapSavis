using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ThucTapSavis_Client.Areas.Admin.Controllers;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class Promotion
    {
        HttpClient _httpClient = new HttpClient();
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] PromotionController _navPromotion { get; set; }
 
        List<Promotion_VM> _lstPromotion =new List<Promotion_VM>();
        public static Promotion_VM _promotion_VM = new Promotion_VM();  


        protected override async Task OnInitializedAsync()
        {
            _lstPromotion = await _httpClient.GetFromJsonAsync<List<Promotion_VM>>("https://localhost:7264/api/Promotion");
        }

        public async Task NavigationAddPromotion()
        {
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion/Add",true);
        }


        public async Task NavigationUpdatePromotion(Promotion_VM promotionVM)
        {
            _promotion_VM = promotionVM;
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion/Update", true);
        }
        public async Task DeletePromotion(Promotion_VM promotionVM)
        {
            _promotion_VM = promotionVM;
            _promotion_VM.Status = 0;
            var a = await _httpClient.PutAsJsonAsync<Promotion_VM>("https://localhost:7264/api/Promotion/Update/", _promotion_VM);
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion", true);
        }


    }
}
