using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;

namespace StoreManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        DB_StokEntities db = new DB_StokEntities();
        [Authorize]

        public ActionResult Index()
        {
            var list = db.Tbl_Sales.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewSale()
        {
            //Products
            List<SelectListItem> product = (from x in db.Tbl_Product.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.dropProduct = product;

            //Personel
            List<SelectListItem> staff = (from x in db.Tbl_Staff.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name +" "+ x.Surname,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.dropStaff = staff;

            //BU KISIMDA AUTOCOMPLETE YAPMAM GEREK


            //Customer
            List<SelectListItem> customer = (from x in db.Tbl_Customer.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name +" "+ x.Surname,
                                                     Value = x.ID.ToString()
                                                 }).ToList();
            ViewBag.dropCustomer = customer;

            return View();
        }

        [HttpPost]
        public ActionResult NewSale(Tbl_Sales sale)
        {
            var productList = db.Tbl_Product.Where(x => x.ID == sale.Tbl_Product.ID).FirstOrDefault();
            var staffList = db.Tbl_Staff.Where(x => x.ID == sale.Tbl_Staff.ID).FirstOrDefault();
            var customerList = db.Tbl_Customer.Where(x => x.ID == sale.Tbl_Customer.ID).FirstOrDefault();

            sale.Tbl_Product = productList;
            sale.Tbl_Staff = staffList;
            sale.Tbl_Customer = customerList;
            sale.Date =DateTime.Parse(DateTime.Now.ToString());
            db.Tbl_Sales.Add(sale);
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }
    }
}