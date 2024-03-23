using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;
using webTimPhong.Models.EF;

namespace webTimPhong.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Picture
        public ActionResult Index(int id)
        {
            ViewBag.RoomId = id;
            var items = db.PICTUREs.Where(x => x.RoomId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int RoomId, string url)
        {
            db.PICTUREs.Add(new PICTURE
            {
                RoomId = RoomId,
                Image = url,
                IsActive = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.PICTUREs.Find(id);
            db.PICTUREs.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
