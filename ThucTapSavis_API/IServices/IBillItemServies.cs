using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.IServices
{
    public interface IBillItemServies
    {
        Task<BillItem> AddBillItem (BillItem item); 
    }
}
