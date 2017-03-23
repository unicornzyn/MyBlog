using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tag = Request.QueryString["tag"];
            var db = new ProjectModels();
            List<Article> list;
            if (string.IsNullOrEmpty(tag))
            {
                list = db.Article.OrderByDescending(a => a.addtime).ToList();
            }
            else
            {
                int tid = 0;
                if (int.TryParse(tag, out tid))
                {
                    var rlist = db.R_ArticleTags.Where(a => a.tagid == tid).Select(a => a.articleid).ToArray();
                    list = db.Article.Where(a => rlist.Contains(a.id)).OrderByDescending(a => a.addtime).ToList();
                }
                else {
                    list = db.Article.OrderByDescending(a => a.addtime).ToList();
                }
            }
            return View(list);
        }
        public JsonResult Tags()
        {
            var db = new ProjectModels();
            var list = db.R_ArticleTags.GroupBy(a => a.tagid, (a, v) => new { tagid = a, cc = v.Count() }).Join(db.Tags, a => a.tagid, b => b.id, (a, b) => new { id = a.tagid, tname = b.tname, cc = a.cc, sort = b.sort }).OrderBy(a => a.sort).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Item(int id)
        {
            var db = new ProjectModels();
            var o = db.Article.First(a => a.id == id);
            ViewBag.Title = o.title;
            return View(o);
        }

        public ActionResult About()
        {           
            return View();
        }        
        //public JsonResult GetReply() { }
        //[HttpPost]
        //public JsonResult SaveReply() { }
    }
}