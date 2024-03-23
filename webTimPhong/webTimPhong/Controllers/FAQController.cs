using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;
using webTimPhong.Models.EF;

namespace webTimPhong.Controllers
{
    public class FAQController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: FAQ
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FAQ model)
        {
            if (ModelState.IsValid)
            {
                db.fAQs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}