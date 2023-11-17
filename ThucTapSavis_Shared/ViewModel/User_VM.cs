using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
	public class User_VM
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage ="Họ và tên không được để trống")]
		public string? FullName { get; set; }=String.Empty;
		[Required(ErrorMessage = "Tên người dùng không được để trống")]
		public string? UserName { get; set; } = String.Empty;
		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		public string? Password { get; set; } = String.Empty;
		[Required(ErrorMessage = "Mật khẩu mới không được để trống")]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự và chứa ít nhất một chữ và một số.")]
		public string NewPassword { get; set; } = String.Empty;
		[Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
		public string ConfirmNewPassword { get; set; } = String.Empty;
		public string? Email { get; set; } = String.Empty;
		[Required(ErrorMessage = "Số điện thoại không được để trống")]
		[RegularExpression(@"^(\+84|0)\d{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
		public string? NumberPhone { get; set; } = String.Empty;
		public string? Tinh { get; set; }
		public string? Huyen { get; set; }
		public string? Xa { get; set; }
		public string? DiaChiCuThe { get; set; }
		public int? Status { get; set; }

		public Guid IdRole { get; set; }
		public string RoleName { get; set; }
	}
}
