using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public partial class Customer
    {

        public Customer()
        {
            Consignee = new HashSet<Consignee>();
            Order = new HashSet<Order>();
        }
        public int ObjId { get; set; }
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int? TheCustomerType { get; set; }
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }


        public DateTime? RegistDate { get; set; }


        public virtual ICollection<Consignee> Consignee { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual CustomerType TheCustomerTypeNavigation { get; set; }
    }
}
