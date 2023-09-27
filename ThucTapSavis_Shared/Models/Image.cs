using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PathImage { get; set; }
        public Guid ProductItemId { get; set; }
        public int Status { get; set; }

        public ProductItem ProductItems { get; set; }

    }
}
