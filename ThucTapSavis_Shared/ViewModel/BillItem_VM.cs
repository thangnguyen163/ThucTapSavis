﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapSavis_Shared.ViewModel
{
    public class BillItem_VM
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public Guid ProductItemsId { get; set; }
//        public string Color { get; set; }
        public int Quantity { get; set; }
        public int? Price { get; set; }
        public int Status { get; set; }


    }
}
