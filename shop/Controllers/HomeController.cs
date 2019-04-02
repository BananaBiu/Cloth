using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shop.Models;

namespace shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly shopContext db;

        public HomeController(shopContext shopdb)
        {
            db = shopdb;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel ivm = new HomeIndexViewModel();
            ivm.newProducts = new List<ProductList>();
            ivm.manProducts = new List<ProductList>();
            ivm.womenProducts = new List<ProductList>();
            ivm.childProducts = new List<ProductList>();
            ivm.topProducts = new List<ProductList>();
            ivm.bestProducts = new List<ProductList>();
            ivm.productCats = new List<ProductCat>();
            //获取热销和推荐商品（各6种）

            var newProducts = db.Product.Take<Product>(4);
            
            foreach (var p in newProducts)
            {
               
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();
                
                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.newProducts.Add(pl);
            }
            var manProducts = db.Product.Take<Product>(8);
            foreach (var p in manProducts)
            {
                if (p.ObjId <= 4)
                { continue; }
                if (p.ObjId >8)
                { break; }
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();

                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.manProducts.Add(pl);
            }

            var womenProducts = db.Product.Take<Product>(12);
            foreach (var p in womenProducts)
            {
                if (p.ObjId <= 8)
                { continue; }
                if (p.ObjId > 12)
                { break; }
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();

                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.womenProducts.Add(pl);
            }

            var childProducts = db.Product.Take<Product>(16);
           
            foreach (var p in childProducts)
            {
                if (p.ObjId <= 12)
                { continue; }
               
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();
                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.childProducts.Add(pl);
            }
            var topProducts = db.Product.Where<Product>(m => m.ObjId > 0).OrderBy<Product, float>(m => (float)m.Price).Take<Product>(3);

            foreach (var p in topProducts)
            {
   

                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();
                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.topProducts.Add(pl);
            }
            var bestProducts = db.Product.Where<Product>(m => m.ObjId > 0).OrderByDescending<Product, float>(m => (float)m.Price).Take<Product>(3);
            foreach (var p in bestProducts)
            {


                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();
                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                ivm.bestProducts.Add(pl);
            }

            return View(ivm);
        }

        public IActionResult Catalog(int typeId, string typeName)
        {
            ViewBag.catalogName = typeName;
            List<ProductCat> productCats = new List<ProductCat>();
            List<ProductList> hotProducts = new List<ProductList>();
            foreach (var pt in db.ProductType.Where<ProductType>(m => m.ObjId > 0).GroupBy<ProductType, string>(m => m.ClassifyType))
            {
                ProductCat pc = new ProductCat();
                pc.typeName = pt.Key;
                pc.types = new List<ProductType>();
                foreach (var p in pt)
                {
                    pc.types.Add(new ProductType { ObjId = p.ObjId, ClassifyType = p.ClassifyType, TypeName = p.TypeName });
                }
                productCats.Add(pc);
            }
            var products = from p in db.Product where p.ProductState == 1 && (from t in db.ProductClass where t.TheProductType == typeId select t.TheProduct).Contains(p.ObjId) select p;
            foreach (var p in products)
            {
                ProductList pl = new ProductList();
                pl.p = new Product { ObjId = p.ObjId, ProductName = p.ProductName, Img = p.Img, Price = p.Price };
                pl.pList = new List<Prices>();
                var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == p.ObjId);
                foreach (var pclst in priceList)
                {
                    pl.pList.Add(new Prices
                    {
                        memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                        realPrice = (double)pclst.RealPrice
                    });
                }
                hotProducts.Add(pl);
            }
            ViewBag.productCats = productCats;
            ViewBag.catProducts = hotProducts;
            ViewBag.contBuy = Request.Path + Request.QueryString;
            return View();
        }

        public IActionResult Detail(int? id)
        {
            ViewBag.contBuy = Request.Headers["Referer"].ToString();
            //FlowerDbContext db = new FlowerDbContext();
            List<ProductCat> productCats = new List<ProductCat>();
            foreach (var pt in db.ProductType.Where<ProductType>(m => m.ObjId > 0).GroupBy<ProductType, string>(m => m.ClassifyType))
            {
                ProductCat pc = new ProductCat();
                pc.typeName = pt.Key;
                pc.types = new List<ProductType>();
                foreach (var p in pt)
                {
                    pc.types.Add(new ProductType { ObjId = p.ObjId, ClassifyType = p.ClassifyType, TypeName = p.TypeName });
                }
                productCats.Add(pc);
            }
            ViewBag.productCats = productCats;

            ProductList pl = new ProductList();
            pl.p = db.Product.Single<Product>(m => m.ObjId == id);
            pl.pList = new List<Prices>();
            var priceList = db.PriceList.Where<PriceList>(m => m.TheProduct == pl.p.ObjId);
            foreach (var pclst in priceList)
            {
                pl.pList.Add(new Prices
                {
                    memberName = db.CustomerType.Where<CustomerType>(m => m.ObjId == pclst.TheCustomerType).First<CustomerType>().TypeName,
                    realPrice = (double)pclst.RealPrice
                });
            }
            return View(pl);
        }
       
        public IActionResult Shop()
        {

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
