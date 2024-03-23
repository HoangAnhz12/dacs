using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PagedList;
using webTimPhong.Models;
using webTimPhong.Models.EF;

namespace webTimPhong.Areas.Admin.Controllers
{
    public class RoomController : Controller
    {

         private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Room
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = db.ROOMs.OrderByDescending(x => x.Id).ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.CITY= new SelectList(db.CITies.ToList(), "Id", "CityName");
            ViewBag.DISTRIC = new SelectList(db.dISTRICTs.Where(m=>m.CITY.Id == m.CityId).ToList(), "Id", "DistrictName");
            ViewBag.WARD = new SelectList(db.WARDs.Where(m => m.DISTRICT.Id==m.DistrictId).ToList(), "Id", "WardName");
            ViewBag.RoomCategory = new SelectList(db.ROOMCategories.ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ROOM model, List<string> Images, List<int> rDefault)
        {            

                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.PICTUREs.Add(new PICTURE
                            {
                                RoomId = model.Id,
                                Image = Images[i],
                                IsActive = true
                            });
                        }
                        else
                        {
                            model.PICTUREs.Add(new PICTURE
                            {
                                RoomId = model.Id,
                                Image = Images[i],
                                IsActive = false
                            });
                        }
                    }
                }
               
                DateTime aDateTime = DateTime.Now;
                model.UserID = User.Identity.GetUserId();
                model.CreatedBy = User.Identity.Name;
                model.Createddate = DateTime.Now;
                model.Modifierdate = DateTime.Now;
                TimeSpan aInterval = new System.TimeSpan(30, 0, 0, 0);
                model.ExprireTime= aDateTime.Add(aInterval);
                model.Modifiedby = User.Identity.Name;
                model.IsConfirm = false;
                model.ViewCount = 0;

                db.ROOMs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            ViewBag.CITY = new SelectList(db.CITies.ToList(), "Id", "CityName");
            ViewBag.DISTRIC = new SelectList(db.dISTRICTs.Where(m=>m.CITY.Id == m.CityId).ToList(), "Id", "DistrictName");
            ViewBag.WARD = new SelectList(db.WARDs.Where(m => m.DISTRICT.Id==m.DistrictId).ToList(), "Id", "WardName");
            ViewBag.RoomCategory = new SelectList(db.ROOMCategories.ToList(), "Id", "Title");
            return View(model) ;
        }

        [HttpPost]
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
        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.ROOMs.Where(x => x.IsConfirm).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Detail(int id)
        {
            var item = db.ROOMs.Find(id);
            if (item != null)
            {
                db.ROOMs.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }
            ViewData["GOOGLE_MAP_API"] = Helpers.Constantmap.GOOGLE_MAP_MARKER_API;
            return View(item);
        }
        public ActionResult RoomCategory(string alias, int id)
        {
            var items = db.ROOMs.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.RoomCategoryId == id).ToList();
            }
            var cate = db.ROOMCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }

            ViewBag.CateId = id;
            return View(items);
        }
    }
}