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
		public string? FullName { get; set; }
		[Required(ErrorMessage = "Tên người dùng không được để trống")]
		public string? UserName { get; set; }
		[Required(ErrorMessage = "Mật khẩu không được để trống")]
		public string? Password { get; set; }
		[Required(ErrorMessage = "Mật khẩu mới không được để trống")]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự và chứa ít nhất một chữ và một số.")]
		public string NewPassword { get; set; }
		[Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
		public string ConfirmNewPassword { get; set; }
		public string? Email { get; set; }
		[Required(ErrorMessage = "Số điện thoại không được để trống")]
		public string? NumberPhone { get; set; }
		public string? Tinh { get; set; }
		public string? Huyen { get; set; }
		public string? Xa { get; set; }
		public string? DiaChiCuThe { get; set; }
		public int? Status { get; set; }
	}
}
