using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webTimPhong.Models.EF;

namespace webTimPhong.Controllers
{
    public class CommentController : Controller
    {

        // GET: Comment
        public ActionResult Index()
        {
            List<Comment> _cmt = new List<Comment>();
            ViewBag.Comment=new Comment();
            return View();
        }
    }
}