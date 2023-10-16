using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class AddPromotion
    {
        HttpClient _httpClient = new HttpClient();
        [Inject] NavigationManager _navigationManager { get; set; }
        List<Product_VM> _lstProduct = new List<Product_VM>();
        List<ProductItem_Show_VM> _lstProductItem = new List<ProductItem_Show_VM>();
        List<Image_VM> _lstImg = new List<Image_VM>();
        Promotion_VM _promotion = new Promotion_VM();
        PromotionItem_VM _promotionItem = new PromotionItem_VM();
        List<Guid> _lstProductSelect = new List<Guid>();
        List<Guid> _lstProductItemSelect = new List<Guid>();
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        //public DateTime StartDateView = DateTime + Time;
        protected override async Task OnInitializedAsync()
        {
            _lstProduct = await _httpClient.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
            _lstImg = await _httpClient.GetFromJsonAsync<List<Image_VM>>("https://localhost:7264/api/Image/get_Image");
        }

        public async Task Add()
        {
            var a = await _httpClient.PostAsJsonAsync<Promotion_VM>("https://localhost:7264/api/Promotion/Add", _promotion);
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion", true);
        }

        public async Task AddPromotionItem()
        {
            var c = _promotion.Id = Guid.NewGuid();
            var a = await _httpClient.PostAsJsonAsync<Promotion_VM>("https://localhost:7264/api/Promotion/Add", _promotion);


            foreach (var item in _lstProductItemSelect)
            {
                _promotionItem.Id = Guid.NewGuid();
                _promotionItem.PromotionsId = c;
                _promotionItem.ProductItemsId = item;
                _promotionItem.Status = 1;

                var b = await _httpClient.PostAsJsonAsync("https://localhost:7264/api/PromotionItem/Add", _promotionItem);
            }
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion", true);
        }
        private async Task ToggleProductSelection(Guid productId)
        {
            _lstProductItem = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
            if (_lstProductSelect.Contains(productId))
            {
                _lstProductSelect.Remove(productId);
            }
            else
            {
                _lstProductSelect.Add(productId);
            }
            _lstProductItem = _lstProductItem.Where(p => _lstProductSelect.Contains(p.ProductId)).ToList();
        }

        private async Task ToggleProductItemSelection(Guid productItemId)
        {
            if (_lstProductItemSelect.Contains(productItemId))
            {
                _lstProductItemSelect.Remove(productItemId);
            }
            else
            {
                _lstProductItemSelect.Add(productItemId);
            }

        }


    }
}
