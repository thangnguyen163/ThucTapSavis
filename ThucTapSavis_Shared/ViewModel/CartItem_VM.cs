using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
    public class CartItem_VM
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductItemId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}
