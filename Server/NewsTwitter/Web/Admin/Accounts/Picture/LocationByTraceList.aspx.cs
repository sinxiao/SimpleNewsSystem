using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Admin.Accounts.Picture
{
    public partial class LocationByTraceList : System.Web.UI.Page
    {
        private BLL.LocationsManager locationmanager = new BLL.LocationsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            String tid = "";
            if(!IsPostBack)
            {
                tid = Request.Params["tid"];
                gdvLocation.DataSource = locationmanager.GetList(" trace_id = " + tid);
                gdvLocation.DataSourceID = null;
                gdvLocation.DataBind();
            }
        }
    }
}