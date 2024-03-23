using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models;

namespace webTimPhong.Areas.Admin.Controllers
{
    public class FAQController : Controller
    {

        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/FAQ
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = dbContext.fAQs.OrderByDescending(x => x.Id).ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = dbContext.fAQs.Find(id);
            if (item != null)
            {
                dbContext.fAQs.Remove(item);
                dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult Detail(int id)
        {
            var item = dbContext.fAQs.Find(id);
            return View(item);
        }
    }
}