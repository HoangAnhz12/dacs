using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;
using webTimPhong.Models.EF;

namespace webTimPhong.Areas.Admin.Controllers
{
//    [Authorize(Roles = "Admin,Employee")]
    public class RoomCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/RoomCategory
        public ActionResult Index()
        {
            var items = db.ROOMCategories;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RoomCategory model)
        {
            if (ModelState.IsValid)
            {
                model.Createddate = DateTime.Now;
                model.Modifierdate = DateTime.Now;
                model.Alias = webTimPhong.Models.Common.Filter.FilterChar(model.Title);
                db.ROOMCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.ROOMCategories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomCategory model)
        {
            if (ModelState.IsValid)
            {
                model.Modifierdate = DateTime.Now;
                model.Alias = webTimPhong.Models.Common.Filter.FilterChar(model.Title);
                db.ROOMCategories.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
