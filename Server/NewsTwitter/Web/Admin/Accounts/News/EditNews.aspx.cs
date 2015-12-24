using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Admin.Accounts.News
{
    public partial class EditNews : System.Web.UI.Page
    {
        private BLL.NewsManager newsbll = new BLL.NewsManager();
        private BLL.ItemManager itembll = new BLL.ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpItemParent.DataSource = itembll.getParentItem();
                drpItemParent.DataTextField = "name";
                drpItemParent.DataValueField = "iditem";
                drpItemParent.DataBind();
                drpItemParent.SelectedIndexChanged += drpItemParent_SelectedIndexChanged;
                if (drpItemParent.SelectedValue != null && !drpItemParent.SelectedValue.Equals(""))
                {
                     drpItem.DataSource = itembll.getItemByParent(int.Parse(drpItemParent.SelectedValue.ToString()));
                     drpItem.DataTextField = "name";
                     drpItem.DataValueField = "iditem";
                     drpItem.DataBind();
                }
                
            }
            drpItemParent.SelectedIndexChanged += drpItemParent_SelectedIndexChanged;
        }
        //<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
        	//<CKEditor:CKEditorControl ID="tbxContent" runat="server" height="300px" 
            //basepath="~/ckeditor" visible="false" style="margin-right: 0px" 
            //width="1140px"></ckeditor:ckeditorcontrol>

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            Model.news news = new Model.news();
            news.content = notContent.Text;
            news.title = tbxTitle.Text;
            news.keyword = tbkKeyWord.Text;
            news.intro = tbxIntro.Text;
            news.itemid = int.Parse(drpItemParent.SelectedItem.Value);
            Model.manager manager = (Model.manager)Session["UserInfo"];
            news.writer = manager.idmanager;
            news.gen_time = DateTime.Now;
            news.clicked = 0;
            news.comment_sum = 0;
            news.image_url = imgPre.ImageUrl;
            Boolean bl =  newsbll.Add(news);
            if(bl)
            {
                Response.Redirect(Request.Url.ToString(),true);
            }
        }

        protected void btnFirstSee_Click(object sender, EventArgs e)
        {

        }

        protected void btnPublishAtTime_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String file = fileUploadImg.FileName;
            if (file == null || file.Trim().Equals(""))
            {

            }
            else {
                String path = Server.MapPath("~/uploader/");
                String end = DateTime.Now.ToString("yyyyMMddhhmmss") + Session.SessionID + file;
                fileUploadImg.SaveAs(path +end);
                imgPre.ImageUrl = "~/uploader/"+ end;
                btnUpload.Text = "upload ok";
            }

        }

        protected void drpItemParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpItem.DataSource = itembll.getItemByParent(int.Parse(drpItemParent.SelectedValue));
            drpItem.DataTextField = "name";
            drpItem.DataValueField = "iditem";
            drpItem.DataBind();
            
        }
    }
}