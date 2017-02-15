using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class BlogViewModel
    {
        public Article article { get; set; }
        public List<Tags> tags { get; set; }
        public int tagid { get; set; }
    }
}