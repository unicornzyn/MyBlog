using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            var db = new ProjectModels();
            var list = db.R_ArticleTags.GroupBy(a => a.tagid, (a, v) => new { tagid = a, cc = v.Count() }).Join(db.Tags, a => a.tagid, b => b.id, (a, b) => new TagsUse { id = a.tagid, tname = b.tname, cc = a.cc, sort = b.sort }).OrderBy(a => a.sort).ToList();
            ViewData["taglist"] = list;
        }
    }
}