using System;
using System.Collections.Generic;

namespace shop.Models
{
    public class HomeIndexViewModel
    {
        public List<ProductList> newProducts { get; set; }
        public List<ProductList> manProducts { get; set; }
        public List<ProductList> womenProducts { get; set; }
        public List<ProductList> childProducts { get; set; }
        public List<ProductList> topProducts { get; set; }
        public List<ProductList> bestProducts { get; set; }
        public List<ProductCat> productCats { get; set; }
    }
    public class ProductList
    {
        public Product p { get; set; }
        public List<Prices> pList { get; set; }
    }
    public class ProductCat
    {
        public string typeName { get; set; }
        public List<ProductType> types { get; set; }
    }
    public class Prices
    {
        public string memberName { get; set; }
        public double realPrice { get; set; }
    }
    public class CartItem
    {
        public string productName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double realPrice { get; set; }
        public int qty { get; set; }
        public string Img { get; set; }
    }

    public class OrderList
    {
        public DateTime orderTime { get; set; }
        public double amt { get; set; }
        public string orderState { get; set; }
        public string productName { get; set; }
        public string smallImg { get; set; }
        public DateTime transTime { get; set; }
        public string name { get; set; }
        public string words { get; set; }
        public string receiptFile { get; set; }
    }
    public class OrderInfo
    {
        public double price { get; set; }
        public double realPrice { get; set; }
        public int theProduct { get; set; }
        public string productName { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
    public class OrderViewModel
    {
        public Customer curCustomer { get; set; }
        public Payment payment { get; set; }
        public List<OrderInfo> orders { get; set; }
        public List<Consignee> receivers { get; set; }
        public List<CustomerWords> words { get; set; }
        public int orderQty { get; set; }
    }
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
    public class PayRequestInfo
    {
        public string PostUrl { get; set; }
        public string MerId { get; set; }
        public string Amt { get; set; }
        public string PaymentTypeObjId { get; set; }
        public string MerTransId { get; set; }
        public string ReturnUrl { get; set; }
        public string CheckValue { get; set; }

    }
}
