using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Web
{
    public partial class Item : System.Web.UI.Page
    {
        protected int id = 0;
        protected string title = string.Empty;
        protected string content = string.Empty;
        protected string addtime = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);
            var item = new DAL.dbEntities().Article.Single(a => a.id == id);
            title = item.title;
            hidcontent.Text = item.content;
            addtime = Common.St.GetDateTimeString(item.addtime);            
        }
    }
}