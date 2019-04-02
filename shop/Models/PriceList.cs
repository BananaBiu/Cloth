using System;
using System.Collections.Generic;

namespace shop.Models
{
    public partial class PriceList
    {
        public int ObjId { get; set; }
        public int? TheProduct { get; set; }
        public double? RealPrice { get; set; }
        public int? TheCustomerType { get; set; }

        public virtual CustomerType TheCustomerTypeNavigation { get; set; }
        public virtual Product TheProductNavigation { get; set; }
    }
}
