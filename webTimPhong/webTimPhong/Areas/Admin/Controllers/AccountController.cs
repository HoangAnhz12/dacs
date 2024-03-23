using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using webTimPhong.Models;

namespace webTimPhong.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Account
        public ActionResult Index()
        {
            // database AspNetUsers 
            var items = dbContext.Users;
            return View(items);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult edit(UserControl model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbContext.Users.Attach(model);
        //        dbContext.Entry(model).Property(x => x.Gmail).ismodified = true;
        //        dbContext.Entry(model).Property(x => x.).ismodified = true;
        //        dbContext.Entry(model).Property(x => x.description).ismodified = true;
        //        //Dung paas
        //        // dbContext.Entry(model).Property(x => x.link).ismodified = true;
        //        return RedirectToAction("index");
        //    }
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var item = dbContext.Users.Find(id);
            if (item != null)
            {
                dbContext.Users.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}