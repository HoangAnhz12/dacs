using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using webTimPhong.Models;
using webTimPhong.Models.EF;

namespace webTimPhong.Areas.Admin.Controllers
{
    public class RoomPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/RoomPost
        public ActionResult Index(int? page)
        {
            IEnumerable<ROOM> items = db.ROOMs.OrderByDescending(x => x.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        [HttpPost]
        public ActionResult IsComfirm(int id)
        {
            var item = db.ROOMs.Find(id);
            if (item != null)
            {
                item.IsConfirm = !item.IsConfirm;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isConfirm = item.IsConfirm });
            }

            return Json(new { success = false });
        }
        public ActionResult Delete(int id)
        {
            var item = db.ROOMs.Find(id);
            if (item != null)
            {
                var checkImg = item.PICTUREs.Where(x => x.RoomId == item.Id);
                if (checkImg != null)
                {
                    foreach (var img in checkImg)
                    {
                        db.PICTUREs.Remove(img);
                        db.SaveChanges();
                    }
                }
                db.ROOMs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
        public ActionResult Detail(int id)
        {
            var item = db.ROOMs.Find(id);
            return View(item);
        }
    }
}