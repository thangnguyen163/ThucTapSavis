using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public string BillCode { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? TotalAmount { get; set; }
        public string PhuongThucTT { get; set; }
        public string? Note { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDTNhan { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }
        public string? DiaChiCuThe { get; set; }
        public int Status { get; set; }
		public int PhiShip { get; set; }

		public User Users { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
