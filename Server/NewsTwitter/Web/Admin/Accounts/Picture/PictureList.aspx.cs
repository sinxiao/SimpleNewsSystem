using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Admin.Accounts.Picture
{
    public partial class PictureList : System.Web.UI.Page
    {
        private BLL.TracesManager tracesmanager = new BLL.TracesManager();
        private BLL.AdminManager managerbll = new BLL.AdminManager();
        private BLL.LocationsManager locbll = new BLL.LocationsManager();
        public Model.manager manager;
        public List<Model.traces> traces;

        public int default_uid = 1;
        public String def_traceId = "3";
        public int def_locId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){

                manager = (Model.manager)Session["UserInfo"];
                if (manager!=null&&manager.Euser != null)
                {
                    if (manager.Euser.uid == 0)
                    {
                        default_uid = 1;// manager.Euser.uid;
                    }
                    else {
                        default_uid = manager.Euser.uid;
                    }
                    
                }
                else {

                    default_uid = 1;
                }
                Session["default_uid"] = default_uid;
                panelAddTrace.Visible = false;

                bindTracesData();
            }
            default_uid = (int)Session["default_uid"];
            def_traceId = (String)Session["def_traceId"];
            if (Session["def_locId"]!=null)
            {
                def_locId = (int)Session["def_locId"];
            }
            


        }
        private void bindTracesData() {
            traces = tracesmanager.GetModelList(" uid = "+default_uid);

            gdvTraceList.DataSource = traces;
            gdvTraceList.DataSourceID = null;
            gdvTraceList.DataBind();
        }
        public String GetUnameById(object obj) 
        {
            if(obj==null)
            {
                return "";
            }
            int mid = (int)obj;
            Model.manager manager = managerbll.GetModel(mid);
            return manager.username;
        }
        public String GetTraceNameById(object obj) 
        {
            if (obj == null)
            {
                return "";
            }
            int mid = (int)obj;
            Model.traces trace = BLL.BLLManager.traces.GetModel(mid);

            return trace.trace_name;
        }
        public String GetLocSumById(object obj) 
        {
            if (obj == null)
            {
                return "0";
            }
            int mid = (int)obj;
            //根据traceID 获得Lactation的总数
            List<Model.locations> lst = locbll.GetModelList(" trace_id = "+mid);
            if(lst!=null)
            {
                string s = lst.Count + "";
                lst.Clear();
                lst = null;
                return s;
            }
            return "0";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("AddTrace.aspx", false);
            panelAddTrace.Visible = !panelAddTrace.Visible;
        }

        protected void gdvPicList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
             //   Response.Redirect("LocationByTraceList.aspx?tid=" + e.CommandArgument.ToString());
                int tid = int.Parse(e.CommandArgument.ToString());
                List<Model.locations> loc = locbll.GetModelList("trace_id = "+tid);
                def_traceId = ""+tid;
                Session["def_traceId"] = def_traceId;
                gdvPicList0.DataSource = loc;
                gdvPicList0.DataSourceID = null;
                gdvPicList0.DataBind();
            }
        }

        protected void btnSaveTracceHide_Click(object sender, EventArgs e)
        {
            panelAddTrace.Visible = false;
        }
        
        protected void btnSaveTraces_Click(object sender, EventArgs e)
        {
            Model.traces trace = new Model.traces();

            trace.trace_name = txtBoxName.Text;
            trace.Demo = txtBoxDemo.Text;
            trace.Data1 = txtBoxTraceKeyWord.Text;
           

            trace.uid = default_uid;
            trace.build_time = DateTime.Now.ToString();
            //bool bl = tracesmanager.Add(trace);
            int i = 0;
            try {
                i = BLL.BLLManager.news.ExecuteSql("INSERT INTO traces (`uid`, `trace_name`, `build_time`, `demo`, `data1`) VALUES ('" + trace.uid + "', '" + trace.trace_name + "', '" + trace.build_time + "', '" + trace.Demo + "', '" + trace.Data1 + "');");
            }
            catch{
                    
            }
            
            if (i>0)
            {
                labStatus.Text = "添加成功";
                txtBoxName.Text = "";
                txtBoxDemo.Text = "";
                txtBoxTraceKeyWord.Text = "";
                bindTracesData();
            }
            else {
                labStatus.Text = "添加失败";
            }
            
            
        }

        protected void gdvTraceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        
        public List<Model.locations> locatons;

        private void bindPicList(String traceId)
        {
            def_traceId = traceId;
            Session["def_traceId"] = def_traceId;
            locatons = locbll.GetModelList(" trace_id = " + traceId);
            gdvPicList0.DataSource = locatons;
            gdvPicList0.DataSourceID = null;
            gdvPicList0.DataBind();
        }
        protected void gdvTraceList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获得id
            string traceId = ((Label)gdvTraceList.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
            //获得名字
            string name = ((TextBox)gdvTraceList.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
            int tid = BLL.BLLManager.news.ExecuteSql("update traces set trace_name= '" + name + "' where idtraces = " + traceId);
            gdvTraceList.EditIndex = -1;
            
        }

        protected void gdvPicList0_DataBinding(object sender, EventArgs e)
        {

        }

        protected void gdvPicList0_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //   Response.Redirect("LocationByTraceList.aspx?tid=" + e.CommandArgument.ToString());
                int lid = int.Parse(e.CommandArgument.ToString());
                //参看一套图片的详细内容
                //跳转到一套图的显示界面
                Response.Redirect("ImageByLocationList.aspx?lid=" + lid);

            }
        }

        protected void gdvPicList0_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gdvPicList0_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //获得id
            string traceId = gdvPicList0.DataKeys[e.RowIndex][0].ToString();
            //获得名字
            string name = ((TextBox)gdvPicList0.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString();
            string demo = ((TextBox)gdvPicList0.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();

            int tid = BLL.BLLManager.news.ExecuteSql("update locations set lname='"+name+"' and  demo ='"+demo+"' where idlocations = "+traceId);
            gdvTraceList.EditIndex = -1;
            
        }

        protected void btnSaveLocation_Click(object sender, EventArgs e)
        {
        }

        protected void btnSaveLoc_Click(object sender, EventArgs e)
        {
            String locname = txtBoxLocName.Text;
            String locdemo = txtBoxLocDemo.Text;
            Model.locations locat = new Model.locations();
            
            locat.Lname = locname;
            locat.Demo = locdemo;
            locat.trace_id = int.Parse(def_traceId);
            locat.uid = default_uid;
            locat.longitude = "0";
            locat.latitude= "0";
            locat.datetime = DateTime.Now.ToString();
            Boolean bl = BLL.BLLManager.locations.Add(locat);
            if (bl)
            {
                lalLocStatu.Text = "添加成功";
                btnAddImage.Visible = true;
                txtBoxLocName.Text = "";
                txtBoxLocDemo.Text = "";
                List<Model.locations> locats = BLL.BLLManager.locations.GetModelList(" trace_id = " + def_traceId + " and lname= '" + locname + "' and demo ='" + locdemo + "'");
                if (locats != null && locats.Count>0)
                {
                  def_locId = locats[0].idlocations;
                  Session["def_locId"] = def_locId;
                 }
                bindPicList(def_traceId);
            }
            else {
                lalLocStatu.Text = "添加失败";
                btnAddImage.Visible = false;
            }
        }
        
        protected void btnLocHide_Click(object sender, EventArgs e)
        {
            panelAddLocation.Visible = false;
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {
            if (def_locId!=-1)
            {
                Response.Redirect("ImageByLocationList.aspx?lid="+def_locId);
            }
            
        }

        protected void btnSaveLocation_Click1(object sender, EventArgs e)
        {
            //if (gdvTraceList.SelectedIndex != -1)
            {
                panelAddLocation.Visible = !panelAddLocation.Visible;
                if (panelAddLocation.Visible)
                {
                    btnSaveLocation.Text = "隐藏添加主题";
                }
                else
                {
                    btnSaveLocation.Text = "显示添加主题";
                }
            }
        }

        protected void gdvTraceList_RowEditing(object sender, GridViewEditEventArgs e)
        {
         //   bindTracesData();
        }

        protected void gdvTraceList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gdvTraceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
               def_traceId = e.CommandArgument.ToString();
               
               bindPicList(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Del")
            {
                String traceId = e.CommandArgument.ToString();
                BLL.BLLManager.traces.Delete(int.Parse(traceId));
                bindTracesData();
            }
        }

    }
}