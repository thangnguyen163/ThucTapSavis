﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel.Momo.Order
{
	public class OrderInfoModel
	{
		public string FullName { get; set; }
		public string? OrderId { get; set; }
		public string? OrderInfo { get; set; }
		public int? Amount { get; set; }
	}
}
