using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.Models
{
    public class BillItem
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid ProductItemsId { get; set; }
        public int Quantity { get; set; }
        public int? Price { get; set; }
        public int Status { get; set; }


        public Bill Bills { get; set; }
        public ProductItem ProductItems { get; set; }
    }
}
