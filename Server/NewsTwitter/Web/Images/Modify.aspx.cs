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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace WoeMobile.Web.images
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int image_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(image_id);
				}
			}
		}
			
	private void ShowInfo(int image_id)
	{
		WoeMobile.BLL.images bll=new WoeMobile.BLL.images();
		WoeMobile.Model.images model=bll.GetModel(image_id);
		this.lblimage_id.Text=model.image_id.ToString();
		this.txtimage_src.Text=model.image_src;
		this.txtimage_owner.Text=model.image_owner.ToString();
		this.txtdemo.Text=model.demo;
		this.txtuid.Text=model.uid.ToString();
		this.txttrace_id.Text=model.trace_id.ToString();
		this.txtlocation_id.Text=model.location_id.ToString();
		this.txtbdata.Text=model.bdata.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtimage_src.Text.Trim().Length==0)
			{
				strErr+="image_src不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtimage_owner.Text))
			{
				strErr+="image_owner格式错误！\\n";	
			}
			if(this.txtdemo.Text.Trim().Length==0)
			{
				strErr+="demo不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtuid.Text))
			{
				strErr+="uid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txttrace_id.Text))
			{
				strErr+="trace_id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtlocation_id.Text))
			{
				strErr+="location_id格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int image_id=int.Parse(this.lblimage_id.Text);
			string image_src=this.txtimage_src.Text;
			int image_owner=int.Parse(this.txtimage_owner.Text);
			string demo=this.txtdemo.Text;
			int uid=int.Parse(this.txtuid.Text);
			int trace_id=int.Parse(this.txttrace_id.Text);
			int location_id=int.Parse(this.txtlocation_id.Text);
			byte[] bdata= new UnicodeEncoding().GetBytes(this.txtbdata.Text);


			WoeMobile.Model.images model=new WoeMobile.Model.images();
			model.image_id=image_id;
			model.image_src=image_src;
			model.image_owner=image_owner;
			model.demo=demo;
			model.uid=uid;
			model.trace_id=trace_id;
			model.location_id=location_id;
			model.bdata=bdata;

			WoeMobile.BLL.images bll=new WoeMobile.BLL.images();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
