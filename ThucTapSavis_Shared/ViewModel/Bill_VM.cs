using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
    public class Bill_VM
    {
        public Guid Id { get; set; }
        public string BillCode { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? TotalAmount { get; set; }
        public string PhuongThucTT { get; set; }
        public string Note { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập thông tin này!")]
        public string TenNguoiNhan { get; set; }
		[Required(ErrorMessage = "Vui lòng nhập thông tin này!")]
		[RegularExpression(@"^0\d{9}$", ErrorMessage = "Thông tin không hợp lệ.")]
		public string SDTNhan { get; set; }
        [Required(ErrorMessage ="Vui lòng chọn tỉnh/ thành phố!")]
        public string Tinh { get; set; } = string.Empty;
		[Required(ErrorMessage = "Vui lòng chọn quận/ huyện/ thị xã!")]
		public string Huyen { get; set; } = string.Empty;
		[Required(ErrorMessage = "Vui lòng chọn xã/ phường!")]
		public string Xa { get; set; } = string.Empty;
		[Required(ErrorMessage = "Vui lòng nhập thông tin này!")]
		public string? DiaChiCuThe { get; set; }
        public int Status { get; set; }
        public int PhiShip { get; set; }

    }
}
