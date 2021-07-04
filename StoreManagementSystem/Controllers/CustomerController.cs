using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace StoreManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        DB_StokEntities db = new DB_StokEntities();
        [Authorize]

        // GET: Customer
        public ActionResult Index(int page=1)
        {

            var customerList = db.Tbl_Customer.Where(x=>x.Status==true).ToList().ToPagedList(page, 2);
            return View(customerList);
        }

        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Tbl_Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Tbl_Customer.Add(customer);
            customer.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(Tbl_Customer customer)
        {
            var x = db.Tbl_Customer.Find(customer.ID);
            x.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            var y = db.Tbl_Customer.Find(id);
            return View("UpdateCustomer", y);
        }


        public ActionResult UpdateCustomers(Tbl_Customer data)
        {
            var customerData = db.Tbl_Customer.Find(data.ID);
            customerData.Name = data.Name;
            customerData.Surname = data.Surname;
            customerData.City = data.City;
            customerData.Balance = data.Balance;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}