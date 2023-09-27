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
        public Guid UserId { get; set; }
        public string CreateDate { get; set; }
        public int TotalAmount { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }


        public User Users { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
