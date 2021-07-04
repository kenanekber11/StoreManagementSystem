using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;
namespace StoreManagementSystem.Controllers
{ 
    public class ProductController : Controller
      {
        DB_StokEntities db = new DB_StokEntities();
        [Authorize]

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Tbl_Product.Where(x => x.Status == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> categoryList = (from x in db.TbL_Category.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.droplist = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Tbl_Product product)
        {
            var ctgr = db.TbL_Category.Where(x => x.ID == product.TbL_Category.ID).FirstOrDefault();
            product.TbL_Category = ctgr;
            product.Status = true;
            db.Tbl_Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult updateProduct(int id)
        {
            List<SelectListItem> categories = (from p in db.TbL_Category.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = p.Name,
                                                   Value = p.ID.ToString()
                                               }).ToList();

            ViewBag.catlist = categories;
            var prod = db.Tbl_Product.Find(id);
            return View("updateProduct", prod);
        }

        public ActionResult UpdateProducts(Tbl_Product product)
        {
            var p = db.Tbl_Product.Find(product.ID);
            p.Brand = product.Brand;
            p.Name = product.Name;
            p.PurchasePrice = product.PurchasePrice;
            p.SellPrice = product.SellPrice;
            p.Stock = product.Stock;
            var cat = db.TbL_Category.Where(x => x.ID == product.TbL_Category.ID).FirstOrDefault();
            p.CategoryID = cat.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
           
        public ActionResult DeleteProduct(Tbl_Product p)
        {
            var findproduct = db.Tbl_Product.Find(p.ID);
            findproduct.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}