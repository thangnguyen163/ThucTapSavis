using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.IServices
{
    public interface IBillItemServies
    {
        // Thang an cut
        Task<BillItem> AddBillItem (BillItem item); 
        // Thang an cut x2
    }
}
