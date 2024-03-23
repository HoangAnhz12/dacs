using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;

namespace webTimPhong.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View(dbContext.Roles.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
                rolemanager.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var item = dbContext.Roles.Find(id);
            if (item != null)
            {
                dbContext.Roles.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}