﻿using Microsoft.AspNetCore.Components;
using ThucTapSavis_Client.SessionService;
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

        List<Guid> _lstProductItemSelect_Them = new List<Guid>();
        List<Guid> _lstProductItemSelect_Xoa = new List<Guid>();

        public bool SelectAllCheckboxProductItem { get;set; }=false;
        public bool SelectAllCheckboxProduct = false;
        [Inject] Blazored.Toast.Services.IToastService _toastService { get; set; } // Khai báo khi cần gọi ở code-behind

        [Inject] public IHttpContextAccessor _ihttpcontextaccessor { get; set; }
        User_VM _user_VM = new User_VM();
        protected override async Task OnInitializedAsync()
        {
                _lstProduct = await _httpClient.GetFromJsonAsync<List<Product_VM>>("https://localhost:7264/api/Product/get_product");
                _lstImg = await _httpClient.GetFromJsonAsync<List<Image_VM>>("https://localhost:7264/api/Image/get_Image");
                _promotion = Promotion._promotion_VM;

                _lstPromotionItem = await _httpClient.GetFromJsonAsync<List<PromotionItem_VM>>($"https://localhost:7264/api/PromotionItem/PromotionItem_By_Promotion/{_promotion.Id}");
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
                        if (a.Id == b)
                        {
                            _lstProductSelect.Add(a.ProductId);
                        }
                    }
                }
                _lstProductSelect = _lstProductSelect.Distinct().ToList();
                _lstProductItem = _lstProductItem.Where(p => _lstProductSelect.Contains(p.ProductId)).ToList();

                if (_lstProductItemSelect.Count == _lstProductItem.Select(x => x.Id).ToList().Count && _lstProductItem.Select(x => x.Id).ToList().Count != 0)
                {
                    SelectAllCheckboxProductItem = true;
                }
                else
                {
                    SelectAllCheckboxProductItem = false;
                }
            
        }

        public async Task Update()
        {
            var a = await _httpClient.PutAsJsonAsync<Promotion_VM>("https://localhost:7264/api/Promotion/Update/", _promotion);
            var c = _promotion.Id;
            var d = await _httpClient.GetFromJsonAsync<List<PromotionItem_VM>>("https://localhost:7264/api/PromotionItem");
            if (_lstProductItemSelect_Them.Count > 0)
            {
                foreach (var item in _lstProductItemSelect_Them)
                {
                    foreach (var ab in d)
                    {
                        if (ab.ProductItemsId == item)
                        {
                            var f = await _httpClient.DeleteAsync($"https://localhost:7264/api/PromotionItem/delete_promotionItem_byId/{ab.Id}");
                        }
                    }
                    if (!_lstPromotionItem.Any(x => x.ProductItemsId == item) || !_lstPromotionItem.Any(x => x.PromotionsId == c))
                    {
                        _promotionItem.Id = Guid.NewGuid();
                        _promotionItem.PromotionsId = c;
                        _promotionItem.ProductItemsId = item;
                        _promotionItem.Status = 1;
                        var b = await _httpClient.PostAsJsonAsync("https://localhost:7264/api/PromotionItem/Add", _promotionItem);
                        var productItem = await _httpClient.GetFromJsonAsync<ProductItem_VM>($"https://localhost:7264/api/ProductItem/{item}");
                        productItem.PriceAfterReduction = productItem.CostPrice - (productItem.CostPrice * _promotion.Percent) / 100;
                        var t = await _httpClient.PutAsJsonAsync("https://localhost:7264/api/ProductItem/update", productItem);
                    }  
                    
                }
            }
            if (_lstProductItemSelect_Xoa.Count > 0)
            {
                foreach (var item in _lstProductItemSelect_Xoa)
                {
                    var b = await _httpClient.DeleteAsync($"https://localhost:7264/api/PromotionItem/PromotionItemByProductItem/{item}");
                }
                var e = await _httpClient.GetFromJsonAsync<List<ProductItem_VM>>($"https://localhost:7264/api/ProductItem/ProductItem_By_PromotionId/{_promotion.Id}");
                foreach (var item in e)
                {
                    var productItem = await _httpClient.GetFromJsonAsync<ProductItem_VM>($"https://localhost:7264/api/ProductItem/{item}");
                    productItem.PriceAfterReduction = productItem.CostPrice;
                    var t = await _httpClient.PutAsJsonAsync("https://localhost:7264/api/ProductItem/update", productItem);
                }
            }
            _navigationManager.NavigateTo("https://localhost:7022/Admin/Promotion", true);
        }

        private async Task LoadPromotionItem(Guid Id)
        {
            _productItemByPromotion = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>($"https://localhost:7264/api/ProductItem/ProductItem_By_PromotionId/{Id}");
        }

        private async Task ToggleProductSelection(Guid productId)
        {
            _lstProductItem = await _httpClient.GetFromJsonAsync<List<ProductItem_Show_VM>>("https://localhost:7264/api/ProductItem/show");
            //_lstProductItemSelect.Clear();
            if (_lstProductSelect.Contains(productId))
            {
                _lstProductSelect.Remove(productId);
                _lstProductItemSelect_Xoa.Clear();
                _lstProductItemSelect_Xoa = _lstProductItem.Select(x => x.Id).ToList();
                //_lstProductItemSelect_Them.Clear();
                SelectAllCheckboxProductItem = false;
            }
            else
            {
                foreach (var a in _lstPromotionItem)
                {
                    _lstProductItemSelect.Add(a.ProductItemsId);
                }
                _lstProductItemSelect_Xoa.Clear();
                _lstProductSelect.Add(productId);
            }
            _lstProductItem = _lstProductItem.Where(p => _lstProductSelect.Contains(p.ProductId)).ToList();
            if (_lstProductItemSelect.Count == _lstProductItem.Select(x => x.Id).ToList().Count && _lstProductItem.Select(x => x.Id).ToList().Count != 0)
            {
                SelectAllCheckboxProductItem = true;
            }
            else
            {
                SelectAllCheckboxProductItem = false;
            }

        }

        private async Task ToggleProductItemSelection(Guid productItemId)
        {
            if (_lstProductItemSelect.Contains(productItemId))
            {
                _lstProductItemSelect.Remove(productItemId);
                _lstProductItemSelect_Them.Remove(productItemId);
                _lstProductItemSelect_Xoa.Add(productItemId);
            }
            else
            {
                _lstProductItemSelect.Add(productItemId);
                _lstProductItemSelect_Them.Add(productItemId);
                _lstProductItemSelect_Xoa.Remove(productItemId);
            }
        }

        private void ToggleAllItems(ChangeEventArgs e)
        {

            if ((bool)e.Value == true)
            {
                _lstProductItemSelect = _lstProductItem.Select(x => x.Id).ToList();
                _lstProductItemSelect_Them.Clear();
                _lstProductItemSelect_Them = _lstProductItemSelect;
                _lstProductItemSelect_Xoa.Clear();

            }
            else
            {
                _lstProductItemSelect_Xoa.Clear();
                _lstProductItemSelect_Xoa= _lstProductItem.Select(x => x.Id).ToList();
                _lstProductItemSelect_Them.Clear();
                _lstProductItemSelect.Clear();
            }
        }

        private bool SelectAllChangedProductItem
        {
            get => SelectAllCheckboxProductItem;
            set
            {
                SelectAllCheckboxProductItem = value;
                if (SelectAllCheckboxProductItem)
                {
                    _lstProductItemSelect= _lstProductItem.Select(x=>x.Id).Distinct().ToList();
                }
            }
        }

    }
}
