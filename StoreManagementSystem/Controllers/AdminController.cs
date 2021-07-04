using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;

namespace StoreManagementSystem.Controllers
{
    public class AdminController : Controller
    {

        DB_StokEntities db = new DB_StokEntities();
        [Authorize]

        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult newAdmin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult newAdmin(Tbl_Admin admin)
        {
            db.Tbl_Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}