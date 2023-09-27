using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.Models
{
    public class ProductItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SizeId { get; set; }
        public int AvaiableQuantity { get; set; }
        public int PurchasePrice { get; set; }
        public int CostPrice { get; set; }
        public int Status { get; set; }

        public Product Products { get; set; }
        public Color Colors { get; set; }
        public Size Size { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
        public virtual ICollection<PromotionItem> PromotionsItems { get; set; }
    }
}
