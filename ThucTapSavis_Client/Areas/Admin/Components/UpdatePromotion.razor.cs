using Microsoft.AspNetCore.Components;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_Client.Areas.Admin.Components
{
    public partial class UpdatePromotion
    {
        HttpClient _httpClient = new HttpClient();
        [Inject] NavigationManager _navigationManager { get; set; }
        List<Product_VM> _lstProduct = new List<Product_VM>();
        List<ProductItem_Show_VM> _lstProductItem = new List<ProductItem_Show_VM>();
        List<Image_VM> _lstImg = new List<Image_VM>();
        Promotion_VM _promotion = new Promotion_VM();
        List<ProductItem_Show_VM> _productItemByPromotion = new List<ProductItem_Show_VM>();
        PromotionItem_VM _promotionItem = new PromotionItem_VM();
        List<Guid> _lstProductSelect = new List<Guid>();
        List<Guid> _lstProductItemSelect = new List<Guid>();

        List<PromotionItem_VM> _lstPromotionItem = new List<PromotionItem_VM>();
        List<Product_VM> _lstProductReturn = new List<Product_VM>();
        List<ProductItem_Show_VM> _lstPrI_show_VM = new List<ProductItem_Show_VM>();

        protected override async Task OnInitializedAsync()
        {
            _lstProduct = await _httpClient.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
            _lstImg = await _httpClient.GetFromJsonAsync<List<Image_VM>>("https://localhost:7264/api/Image/get_Image");
            _promotion = Promotion._promotion_VM;

            _lstPromotionItem =await _httpClient.GetFromJsonAsync<List<PromotionItem_VM>>($"https://localhost:7264/api/PromotionItem/PromotionItem_By_Promotion/{_promotion.Id}");
            _lstPrI_show_VM = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
            _lstProductItem = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");

            foreach (var a in _lstPromotionItem)
            {
                _lstProductItemSelect.Add(a.ProductItemsId);
               
            }
            foreach (var a in _lstPrI_show_VM)
            {
                foreach (var b in _lstProductItemSelect)
                {
                    if (a.Id==b)
                    {
                        _lstProductSelect.Add(a.ProductId);
                    }
                }
            }
            _lstProductSelect = _lstProductSelect.Distinct().ToList();
            _lstProductItem = _lstProductItem.Where(p => _lstProductSelect.Contains(p.ProductId)).ToList();
        }

        public async Task Update()
        {
            var a = await _httpClient.PutAsJsonAsync<Promotion_VM>("https://localhost:7264/api/Promotion/Update/", _promotion);
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion", true);
        }

        private async Task LoadPromotionItem(Guid Id)
        {
            _productItemByPromotion = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>($"https://localhost:7264/api/PromotionItem/PromotionItem_By_Promotion/{Id}");
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
