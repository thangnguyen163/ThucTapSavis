﻿using ThucTapSavis_Shared.Models;
using ThucTapSavis_Shared.ViewModel;

namespace ThucTapSavis_API.Services_IServices.IServices
{
	public interface IBillItemServies
	{
		public Task<BillItem> AddBillItem(BillItem billItem);
		public Task<BillItem> UpdateBillItem(BillItem billItem);
		public Task<bool> DeleteBillItem(Guid Id);
		public Task<List<BillItem>> GetAllBillItem();
		public Task<BillItem> GetAllBillItemById(Guid Id);
		public Task<List<BillItem>> GetAllBillItemByBill(Guid Id);
		public Task<List<BillDetailShow>> GetBillItemsByBillId(Guid BillId);

	}
}
