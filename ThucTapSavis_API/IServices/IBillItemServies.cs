﻿using ThucTapSavis_Shared.Models;

namespace ThucTapSavis_API.IServices
{
    public interface IBillItemServies
    {
        public Task<BillItem> AddBillItem (BillItem billItem); 
        public Task<BillItem> UpdateBillItem (BillItem billItem); 
        public Task<bool> DeleteBillItem (Guid Id); 
        public Task<List<BillItem>> GetAllBillItem (); 
        public Task<List<BillItem>> GetAllBillItemByBill (Guid Id); 
    }
}
