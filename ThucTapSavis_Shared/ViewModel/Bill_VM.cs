using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
    public class Bill_VM
    {
        public Guid Id { get; set; }
        public string NguoiDat { get; set; }
        public string CreateDate { get; set; }
        public int TotalAmount { get; set; }
        public string Note { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDTNhan { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }
        public string DiaChiCuThe { get; set; }
        public int Status { get; set; }

    }
}
