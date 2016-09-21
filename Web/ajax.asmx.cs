using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace Web
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ajax : System.Web.Services.WebService
    {
        [WebMethod]
        public void SaveReply(int id,string nick,string content)
        {
            if (id==0||nick.Trim()==""||content.Trim()=="")
            {
                return;
            }
            var db = new DAL.dbEntities();
            var m = db.Reply.CreateObject();
            m.Rid = 0;
            m.ArticleId = id;
            m.Nick = nick.Replace("<","");
            m.Content = content.Replace("<", "");
            m.AddTime = DateTime.Now;
            db.AddToReply(m);
            db.SaveChanges();
            this.Context.Response.Write("{\"success\":1}");
        }

        [WebMethod]
        public void GetReply(int id) 
        {
            var db = new DAL.dbEntities();
            var list = db.Reply.Where(a => a.ArticleId == id);
            StringBuilder sb = new StringBuilder("[");
            foreach (var i in list)
            {
                sb.Append("{\"Nick\":\"").Append(i.Nick).Append("\",\"Content\":\"").Append(i.Content).Append("\",\"AddTime\":\"").Append(i.AddTime.ToString("yyyy-MM-dd HH:mm:ss")).Append("\"},");
            }
            
            this.Context.Response.Write(sb.ToString().TrimEnd(',')+"]");
        }
    }
}
