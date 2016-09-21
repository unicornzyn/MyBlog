using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected string LoginHtml = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db=new DAL.dbEntities();
                rptTagList.DataSource = db.R_ArticleTags.GroupBy(a => a.tagid, (a, v) => new { tagid = a, cc = v.Count(), tname = "123" }).Join(db.Tags, a => a.tagid, b => b.id, (a, b) => new { id=a.tagid,tname=b.tname,cc=a.cc,sort=b.sort}).OrderBy(a=>a.sort);
                rptTagList.DataBind();

                //验证登录
                string username = Common.St.GetCookie("username",this.Request);
                string passwd = Common.St.GetCookie("passwd", this.Request);
                LoginHtml = "[ <a href=\"/Account/Login.aspx\">登录</a> ]";
                if (!(string.IsNullOrEmpty(username)||string.IsNullOrEmpty(passwd)))
                {
                    var list = db.Users.Where(a => a.UserName == username && a.Passwd == passwd);
                    if (list.Count() > 0)
                    {
                        LoginHtml = "hello, <span class=\"bold\">"+username+"</span> ! [ <a href=\"/Account/Login.aspx\">注销</a> ]";
                    }
                    
                }
            }
        }
    }
}
