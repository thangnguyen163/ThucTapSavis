﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
	public class ProductItem_VM
	{
		public Guid Id { get; set; }
		[RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Vui lòng chọn sản phẩm")]
		public Guid ProductId { get; set; }
		[RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Vui lòng chọn màu sắc")]
		public Guid? ColorId { get; set; } = Guid.Parse("00000000-0000-0000-0000-000000000000");
		[RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Vui lòng chọn size")]
		public Guid? SizeId { get; set; } = Guid.Parse("00000000-0000-0000-0000-000000000000");
		[Required(ErrorMessage = "Số lượng tồn không được để trống")]
		public int? AvaiableQuantity { get; set; }
		[Required(ErrorMessage = "Giá nhập không được để trống")]
		public int? PurchasePrice { get; set; }
		[Required(ErrorMessage = "Giá bán không được để trống")]
		public int? CostPrice { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn trạng thái")]
		public int Status { get; set; } = 0;
	}
}
