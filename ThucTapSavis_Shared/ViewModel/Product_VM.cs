using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
	public class Product_VM
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public int Status { get; set; }
	}
}
