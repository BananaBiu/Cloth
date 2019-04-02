using System;
using System.Collections.Generic;

namespace shop.Models
{
    public partial class Consignee
    {
        public Consignee()
        {
            Order = new HashSet<Order>();
        }

        public int ObjId { get; set; }
        public string Name { get; set; }

        public int? TheCustomer { get; set; }
        public string StreetName { get; set; }

        public int? ZipCode { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }


        public virtual ICollection<Order> Order { get; set; }

        public virtual Customer TheCustomerNavigation { get; set; }
    }
}
