using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
	public class User_VM
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string NumberPhone { get; set; }
		public bool Sex { get; set; }
		public string Tinh { get; set; }
		public string Huyen { get; set; }
		public string Xa { get; set; }
		public string DiaChiCuThe { get; set; }
		public int Status { get; set; }
	}
}
