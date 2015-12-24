using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WoeMobile.Web.Admin.Accounts.News
{
    public partial class NewsList : System.Web.UI.Page
    {
        private BLL.AdminManager managerbll = new BLL.AdminManager();
        private BLL.ItemManager itembll = new BLL.ItemManager();
        private BLL.NewsManager newsbll = new BLL.NewsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                labTip.Text ="大小为： "+ newsbll.GetModelList("").Count;


            }
        }
        public String GetWriterById(object obj) 
        {
            if(obj==null)
            {
                return "";
            }
            int mid =(int) obj;
            Model.manager manager = managerbll.GetModel(mid);
            if(manager!=null)
            {
                return manager.username;
            }
            return "";
        }

        public String GetNewsVerifyStatus(object obj)
        {
            if (obj != null)
            {
                int stat =(int) obj ;
                if (stat == 1)
                {
                    return "已审核";
                }
                else 
                {
                    return "未审核";
                }
                
            }
            return "未审核";
        }
        public String GetNewsVerifyDate(object obj)
        {
            if (obj != null)
            {
                DateTime date = (DateTime)obj;
                int year = date.Year;
                if(year==1)
                {
                    return "无审核记录";
                }
                return date.ToString();
                
            }
            return "";
        }
        public String GetNewsVerifyAdmin(object obj) 
        {
            if(obj!=null)
            {
                int uid = (int)obj;
                Model.manager manager = managerbll.GetModel(uid);
                if(manager!=null)
                {
                    return manager.username;
                }
            }
            return "无";
        }
 

        public String GetNewsImage(object obj) 
        {
            if (obj != null)
            {
                return (String)obj;
            }
            return "";
        }
        public String GetItemById(object obj) 
        {
            if (obj == null)
            {
                return "";
            }
            int mid = (int)obj;
            Model.item item = itembll.GetModel(mid);
            if (item != null)
            {
                return item.name;
            }
            return "";
        }

        protected void itemDownListOnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dpl = (DropDownList) sender;
            if (dpl.ID.Equals("itemList")) //选择显示不同类别的新闻
            {

            }
            else 
            {//编辑一条新闻的类别
               
            }
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //指定当绑定的为数据列时
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
                LinkButton labStatu = (LinkButton)e.Row.Cells[7].FindControl("lbtnstate");
                Model.news drv = (Model.news)e.Row.DataItem;
                
                if (drv.Verify==1)
                {
                    labStatu.Text = "不通过";
                }
                else {
                    labStatu.Text = "通过";
                }
            }
            
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect("~/news/NewsDetail.aspx?Id=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "modify")
            {
                
                String id = e.CommandArgument.ToString();
                Model.manager manager = (Model.manager)Session["UserInfo"];
                Model.news news = newsbll.GetModel(int.Parse(id));
                if (news.Verify == 1)
                {
                    news.Verify = 0;
                }
                else {
                    news.Verify = 1;  
                }
                news.Verify_date = DateTime.Now;
                news.Verify_id = manager.idmanager;
                newsbll.Update(news);
                gvOrder.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditNews.aspx?List=List", false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelectByUserName_Click(object sender, EventArgs e)
        {
            int mid =int.Parse(dropUsername.SelectedValue);
            int tid = int.Parse(dropState2.SelectedValue);

            List<Model.news> model = newsbll.getNewsByMidStatus(mid,tid);

            gvOrder.DataSource = model;
            gvOrder.DataSourceID = null;
            gvOrder.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            gvOrder.DataSourceID = ObjectDataSource1.ID;
            gvOrder.DataSource = null;
            
            ObjectDataSource2.DataBind();

            //gvOrder.DataBind();
        }

        protected void BtnSearchKeyWord_Click(object sender, EventArgs e)
        {
            String keyWord = TextBox1.Text.ToString();
            List<Model.news> model = newsbll.getNewsByKeyWord(keyWord);

            gvOrder.DataSource = model;
            gvOrder.DataSourceID = null;
            gvOrder.DataBind();
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            int itemId, status;
            itemId = int.Parse(drdItem.SelectedValue);
            status = int.Parse(drpStatus.Value);
            List<Model.news> model = newsbll.getNewsByItemAndStatus(itemId,status);
            gvOrder.DataSource = model;
            gvOrder.DataSourceID = null;
            gvOrder.DataBind();
        }

    }
}