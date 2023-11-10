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
