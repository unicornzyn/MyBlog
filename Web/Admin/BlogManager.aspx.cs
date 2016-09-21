using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Admin
{
    public partial class BlogManager : System.Web.UI.Page
    {
        protected string content = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new DAL.dbEntities();
            if (!IsPostBack)
            {
                //验证登录                
                string username = Common.St.GetCookie("username", this.Request);
                string passwd = Common.St.GetCookie("passwd", this.Request);
                if (!(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwd)))
                {
                    
                    var list = db.Users.Where(a => a.UserName == username && a.Passwd == passwd);
                    if (list.Count() > 0)
                    {
                        if (list.Single().UserRole!=1)
                        {
                            Response.Redirect("/Account/Login.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("/Account/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Account/Login.aspx");
                }
              
               
                ddTags.DataTextField = "tname";
                ddTags.DataValueField = "id";
                ddTags.DataSource = db.Tags.OrderBy(a => a.sort).Select(a => a);
                ddTags.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        var list = db.Article.Where(a => a.id == id);
                        if (list.Count() > 0)
                        {
                            var article = list.Single();
                            txtTitle.Text = article.title;
                            txtContent.Text = article.content;
                            content = article.content;
                            var rlist = db.R_ArticleTags.Where(a => a.articleid == id);
                            if (rlist.Count() > 0)
                            {
                                ddTags.SelectedValue = rlist.Single().tagid.ToString();
                            }
                        }
                    }
                }
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var db = new DAL.dbEntities();
            int id=0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = int.Parse(Request.QueryString["id"]);

            }
            SaveR(SaveArticle(id, txtTitle.Text, txtContent.Text), int.Parse(ddTags.SelectedValue));
        }

        private int SaveArticle(int id, string title, string content)
        {
            var db = new DAL.dbEntities();
            var list = db.Article.Where(a => a.id == id);
            DAL.Article article;
            if (list.Count() > 0)
            {
                article = list.Single();
                article.title = title;
                article.content = content;                
            }
            else
            {
                article = db.Article.CreateObject();
                article.title = title;
                article.content = content;
                article.addtime = DateTime.Now;
                db.AddToArticle(article);
            }
            db.SaveChanges();
            return article.id;
        }

        private void SaveR(int aid, int tid) 
        {
            var db = new DAL.dbEntities();
            var rlist = db.R_ArticleTags.Where(a => a.articleid == aid);
            DAL.R_ArticleTags r;
            if (rlist.Count() > 0)
            {
                r = rlist.Single();
                r.tagid = tid;
            }
            else
            {
                r = db.R_ArticleTags.CreateObject();
                r.articleid = aid;
                r.tagid = tid;
                r.addtime = DateTime.Now;
                db.AddToR_ArticleTags(r);
            }
            db.SaveChanges();
        }
    }

}