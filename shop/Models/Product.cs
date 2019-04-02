using System;
using System.Collections.Generic;

namespace shop.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
            PriceList = new HashSet<PriceList>();
            ProductClass = new HashSet<ProductClass>();
        }
        public int ObjId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string Img { get; set; }
        public int? ProductState { get; set; }


        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<PriceList> PriceList { get; set; }
        public virtual ICollection<ProductClass> ProductClass { get; set; }
    }
}
