using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace WoeMobile.Web.news
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int idnews=(Convert.ToInt32(strid));
					ShowInfo(idnews);
				}
			}
		}
		
	private void ShowInfo(int idnews)
	{
		WoeMobile.BLL.NewsManager bll=new WoeMobile.BLL.NewsManager();
		WoeMobile.Model.news model=bll.GetModel(idnews);
		this.lblidnews.Text=model.idnews.ToString();
		this.lblintro.Text=model.intro;
		this.lblgen_time.Text=model.gen_time.ToString();
		this.lblwriter.Text=model.writer.ToString();
		this.lbltitle.Text=model.title;
		this.lblcontent.Text=model.content;
		this.lblitemid.Text=model.itemid.ToString();
		this.lblpasscheked.Text=model.passcheked.ToString();
		this.lblkeyword.Text=model.keyword.ToString();
		this.lbldefault_news.Text=model.default_news.ToString();
		this.lblclicked.Text=model.clicked.ToString();
		this.lblnews_url.Text=model.news_url;
		this.lblimage_url.Text=model.image_url;
		this.lblcomment_sum.Text=model.comment_sum.ToString();

	}


    }
}
