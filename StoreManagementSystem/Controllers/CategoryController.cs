using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagementSystem.Models.Entity;

namespace StoreManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        DB_StokEntities db = new DB_StokEntities();
        [Authorize]

        // GET: Category
        public ActionResult Index()
        {
            var list = db.TbL_Category.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(TbL_Category data)
        {
            db.TbL_Category.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var catid = db.TbL_Category.Find(id);
            db.TbL_Category.Remove(catid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult UpdateCategory(int id)
        {
            var ctgrid = db.TbL_Category.Find(id);
            return View("UpdateCategory", ctgrid);
        }


        public ActionResult UpdateCategories(TbL_Category c)
        {
            var updcat = db.TbL_Category.Find(c.ID);
            updcat.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}