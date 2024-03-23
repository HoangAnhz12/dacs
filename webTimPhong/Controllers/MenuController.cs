using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;

namespace webTimPhong.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuRoomCategory()
        {
            var items = db.ROOMCategories.ToList();
            return PartialView("_MenuRoomCategory", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.ROOMCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = db.ROOMCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }

    }
}