﻿using Microsoft.AspNetCore.Components;
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

        List<Promotion_VM> _lstPromotion = new List<Promotion_VM>();
        public static Promotion_VM _promotion_VM = new Promotion_VM();
        private int selectedValue = 0;
        private int selectedSort = 0;
        private int statusValue;
        private DateTime StartDateValue = new DateTime(2000, 1, 1);
        private DateTime EndDateValue = new DateTime(2000, 1, 1);
        private string? _promotionName = null;


        protected override async Task OnInitializedAsync()
        {
            _lstPromotion = await _httpClient.GetFromJsonAsync<List<Promotion_VM>>("https://localhost:7264/api/Promotion");
        }

        public async Task NavigationAddPromotion()
        {
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion/Add", true);
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

        public async Task Search()
        {
            _lstPromotion = await _httpClient.GetFromJsonAsync<List<Promotion_VM>>("https://localhost:7264/api/Promotion");
            _lstPromotion = _lstPromotion.Where(x => x.Name == null || x.Name == string.Empty || x.Name.ToLower().Contains(_promotionName.ToLower())).ToList();
        }
        // status 0 1 
        public async Task Loc()
        {
            _lstPromotion = await _httpClient.GetFromJsonAsync<List<Promotion_VM>>("https://localhost:7264/api/Promotion");

            if (selectedValue == 1)
            {
                statusValue = 1;
            }
            else if (selectedValue == 2)
            {
                statusValue = 0;
            }
            else
            {
                statusValue = 3; // selectValue = 0;
            }

            if (selectedSort == 0)
            {
                _lstPromotion = _lstPromotion.Where(x => (statusValue == 3 || x.Status == statusValue) && (StartDateValue == new DateTime(2000, 1, 1) || x.StartDate >= StartDateValue) && (EndDateValue == new DateTime(2000, 1, 1) || x.EndDate <= EndDateValue) && (selectedSort==0||selectedSort==1||selectedSort==2)).ToList();
            }
            else if (selectedSort == 1)
            {
                _lstPromotion = _lstPromotion.Where(x => (statusValue == 3 || x.Status == statusValue) && (StartDateValue == new DateTime(2000, 1, 1) || x.StartDate >= StartDateValue) && (EndDateValue == new DateTime(2000, 1, 1) || x.EndDate <= EndDateValue)).OrderByDescending(c => c.Percent).ToList();
            }
            else if (selectedSort == 2)
            {
                _lstPromotion = _lstPromotion.Where(x => (statusValue == 3 || x.Status == statusValue) && (StartDateValue == new DateTime(2000, 1, 1) || x.StartDate >= StartDateValue) && (EndDateValue == new DateTime(2000, 1, 1) || x.EndDate <= EndDateValue)).OrderBy(c => c.Percent).ToList();
            }


         
        }

        public async IAsyncEnumerable<Promotion_VM> SelectOnePromotion()
        {
            foreach (var promotion in _lstPromotion)
            {
                yield return promotion;
            }
        }
        public async Task AutoChangeStatusPromotion()
        {
            await foreach (var promotion in SelectOnePromotion())
            {
                if (promotion.EndDate < DateTime.Now)
                {
                    promotion.Status = 0;
                    await _httpClient.PutAsJsonAsync<Promotion_VM>("https://localhost:7264/api/promotion/update", promotion);
                }
            }

        }
    }
}
