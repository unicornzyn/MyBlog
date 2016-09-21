using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Common;

namespace Web.Account
{
    /// <summary>
    /// AccountAjax 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class AccountAjax : System.Web.Services.WebService
    {

        [WebMethod]
        public void Register()
        {
            string username = this.Context.Request.Form["username"];
            string passwd = this.Context.Request.Form["passwd"];

            if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(passwd))
            {
                this.Context.Response.Write("{\"success\":0}");
                return;
            }
            var db = new DAL.dbEntities();
            if (db.Users.Where(a=>a.UserName==username.Trim()).Count()>0)
            {
                this.Context.Response.Write("{\"success\":2}");
                return;
            }
            var user = db.Users.CreateObject();
            user.UserName = username.Trim();
            user.Passwd = St.GetMD5(passwd);
            user.UserRole = 2;
            user.AddTime = DateTime.Now;
            db.AddToUsers(user);
            db.SaveChanges(System.Data.Objects.SaveOptions.None);
            St.SetCookie("username", user.UserName,DateTime.Now.AddYears(1));
            St.SetCookie("passwd", user.Passwd, DateTime.Now.AddYears(1));
            this.Context.Response.Write("{\"success\":1,\"url\":\"/Admin/BlogManager.aspx\"}");
        }

        [WebMethod]
        public void Login() 
        {
            string username = this.Context.Request.Form["username"];
            string passwd = this.Context.Request.Form["passwd"];
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwd))
            {
                this.Context.Response.Write("{\"success\":0}");
                return;
            }
            string pmd5=St.GetMD5(passwd);
            var list = new DAL.dbEntities().Users.Where(a => a.UserName == username && a.Passwd == pmd5);
            if (list.Count() > 0)
            {
                var user = list.Single();
                St.SetCookie("username", user.UserName, DateTime.Now.AddYears(1));
                St.SetCookie("passwd", user.Passwd, DateTime.Now.AddYears(1));
                if (user.UserRole == 2)
                {
                    this.Context.Response.Write("{\"success\":1,\"url\":\"/Default.aspx\"}");
                }
                else 
                {
                    this.Context.Response.Write("{\"success\":1,\"url\":\"/Admin/BlogManager.aspx\"}");
                }               
            }
            else 
            {
                this.Context.Response.Write("{\"success\":2}");
            }

            

        }
    }
}
