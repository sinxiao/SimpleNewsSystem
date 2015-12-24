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
namespace WoeMobile.Web.images
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
					int image_id=(Convert.ToInt32(strid));
					ShowInfo(image_id);
				}
			}
		}
		
	private void ShowInfo(int image_id)
	{
		WoeMobile.BLL.images bll=new WoeMobile.BLL.images();
		WoeMobile.Model.images model=bll.GetModel(image_id);
		this.lblimage_id.Text=model.image_id.ToString();
		this.lblimage_src.Text=model.image_src;
		this.lblimage_owner.Text=model.image_owner.ToString();
		this.lbldemo.Text=model.demo;
		this.lbluid.Text=model.uid.ToString();
		this.lbltrace_id.Text=model.trace_id.ToString();
		this.lbllocation_id.Text=model.location_id.ToString();
		this.lblbdata.Text=model.bdata.ToString();

	}


    }
}
