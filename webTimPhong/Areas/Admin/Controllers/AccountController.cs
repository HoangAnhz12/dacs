using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using webTimPhong.Models;

namespace webTimPhong.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {

        ApplicationDbContext dbContext = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin/Account
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = dbContext.Users.OrderByDescending(x => x.Id).ToPagedList(pageIndex, pageSize);
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
        public ActionResult Edit(string id)
        {
            ViewBag.Role = new SelectList(dbContext.Roles.ToList(), "Name", "Name");
            var item = dbContext.Users.Find(id);
            return View(item);
        }
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit()
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            dbContext.Users.Attach(model);
        //            model.modifierdate = DateTime.Now;
        //            model.alias = DoAnWeb.Models.Common.Filter.FilterChar(model.title);
        //            dbContext.Entry(model).Property(x => x.title).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.description).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.link).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.alias).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.seokeywords).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.seotitle).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.seodescription).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.position).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.modifierdate).IsModified = true;
        //            dbContext.Entry(model).Property(x => x.modifierby).IsModified = true;
        //            dbContext.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(model);
        //    }
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {

                var oldUser = UserManager.FindById(model.Id);
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = dbContext.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                if (oldRoleName != model.Role)
                {
                    UserManager.RemoveFromRoles(model.Id, oldRoleName);
                    UserManager.AddToRole(model.Id, model.Role);
                }

                dbContext.Users.Attach(model);


                dbContext.Entry(model).State = EntityState.Modified;

                dbContext.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.Role = new SelectList(dbContext.Roles.ToList(), "Name", "Name");
            return View(model);

        }
    }
}