using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Admin.Accounts.Picture
{
    public partial class AddTrace : System.Web.UI.Page
    {
        private BLL.TracesManager tracesmanager = new BLL.TracesManager();
        private BLL.LocationsManager locationmanager = new BLL.LocationsManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private Model.traces all_traces;
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String name = txtName.Text.ToString();
            String demo = txtDemo.Text.ToString();
            Model.traces traces = new Model.traces();
            traces.trace_name = name;
            traces.Demo = demo;
            traces.build_time = DateTime.Now.ToString();
            Model.manager manager = (Model.manager)Session["UserInfo"];
            traces.uid = manager.user_id;
            bool bl = tracesmanager.Add(traces);
            List<Model.traces> tracess = tracesmanager.GetModelList(" trace_name = '" + name + "' ");
            if (tracess != null && tracess.Count>0)
            {
                all_traces = tracess[0];
            }
            if(bl)
            {
                btnAdd.Text = "添加成功";
                btnAdd.Enabled = false;
            }else
                btnAdd.Text = "添加失败";
        }

        protected void btnAddLoaction_Click(object sender, EventArgs e)
        {
            String name = txtName.Text.ToString();
            String demo = txtLDemo.Text.ToString();
            Model.locations location = new Model.locations();
            location.trace_id = all_traces.idtraces;
            Model.manager manager = (Model.manager)Session["UserInfo"];
            location.uid = manager.user_id;
            location.Demo = demo;
            location.datetime = DateTime.Now.ToString();
            location.Lname = name;
            bool bl = locationmanager.Add(location);
            if (bl)
            {
                btnAdd.Text = "添加成功";

            }
            else
                btnAdd.Text = "添加失败";
        }
    }
}