using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;
using System.Web.Security;

namespace StoreManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        DB_StokEntities db = new DB_StokEntities();
        // GET: Login
        public ActionResult Log()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Log(Tbl_Admin admin)
        {
            var info = db.Tbl_Admin.FirstOrDefault(x => x.kullanici == admin.kullanici && x.sifre == admin.sifre);
            if (info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.kullanici, false);
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return View();

            }
        }
    }
}