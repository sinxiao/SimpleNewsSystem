using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WoeMobile.Web.Admin.Accounts.User
{
    public partial class UserList : System.Web.UI.Page
    {
        private WoeMobile.BLL.EuserManager euserbll = new BLL.EuserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblTip.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WoeMobile.Model.euser euser = new Model.euser();
            euser.in_email = txtin_email.Text;
            List<Model.euser> list = euserbll.GetModelList("in_email = '"+euser.in_email+"'");
            if (list != null && list.Count >= 1)
            {
                lblTip.Text = "email已存在，请重新选择email";
            
                lblTip.Visible = true;
            }
            else 
            {
                euser.in_pwd = txtin_pwd.Text;
                euser.nick_name = txtnick_name.Text;
                Boolean bl = euserbll.Add(euser);
                if (bl)
                {
                    lblTip.Text = "已添加成功";
                    lblTip.Visible = true;

                    this.grdUserAll.DataBind();
                }
                else 
                {
                    lblTip.Text = "添加失败";
                    lblTip.Visible = true;
                }
            }
            
        }
        private void ShowNormal() 
        {
           
        }
        protected void txtin_email_TextChanged(object sender, EventArgs e)
        {
            lblTip.Visible = false;
            lblTip.Text = "";
        }

        protected void grdUserAll_DataBinding(object sender, EventArgs e)
        {
            
        }
        public String GetGenderById(object obj) 
        {
            if(obj==null)
            {
                return "";
            }
            int id = (int)obj;
            
            if (id==1)
            {
                return "男";
            }
            else 
            {
                return "女";
            }
            
        }
        protected void grdUserAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             //指定当绑定的为数据列时
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {

        }

    }
}