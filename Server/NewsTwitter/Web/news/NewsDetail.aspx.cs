using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.news
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        private BLL.NewsManager newsbll = new BLL.NewsManager();
        private BLL.AdminManager adminbll = new BLL.AdminManager();
        private Model.news news;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String nid = Request.QueryString["Id"];
                news = newsbll.GetModel(int.Parse(nid));

                title.Text = news.title;
                if (news.Manager==null)
                {
                    news.Manager = adminbll.GetModel((int)news.writer);
               
                }
                user.Text = news.Manager.username;
                time.Text = news.gen_time.ToString();

                click.Text =""+news.clicked;
                content.Text = news.content;

                news.clicked = news.clicked + 1;

                newsbll.Update(news);
            }
        }
    }
}