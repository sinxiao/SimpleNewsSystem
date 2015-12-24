using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Admin.Accounts.Infor
{
    public partial class InforList : System.Web.UI.Page
    {
        public int default_mid = -1;
        public int tw_type = -1;
        public int mid = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Model.manager manager = (Model.manager)Session["UserInfo"];
                default_mid = manager.idmanager;
                Session["default_mid"] = default_mid;
                bindSysInfor();
            }
            filePath = (String) Session["filePath"];
            default_mid = (int)Session["default_mid"];
        }
        private void bindSysInfor() 
        {
            List<Model.information> infors = BLL.BLLManager.information.GetModelList("infor_type != "+1);
            ltvInfor.DataSource = infors;
            ltvInfor.DataSourceID = null;
            ltvInfor.DataBind();
        }
        public String GetFromById(object o) 
        {
            if (o!=null)
            {
                int frm = (int)o;
                Model.euser u = BLL.BLLManager.euser.GetModel(frm);
               if(u!=null){
                   return u.nick_name;
               }
                    
                

            }
            return "无";
        }

        public String GetToById(object o)
        {
            if (o != null)
            {
                int frm = (int)o;
                Model.euser u = BLL.BLLManager.euser.GetModel(frm);
                if (u != null)
                {
                    return u.nick_name;
                }

                

            }
            return "无";
        }

        public String GetReadById(object o)
        {
            if (o != null)
            {
                int frm = (int)o;
                if (frm == 1)
                {
                    return "已读";
                }
                else if (frm == 0)
                {
                    return "未读";
                }
                else {
                    return "" + frm;
                }

            }
            return "未知";
        }

        public String GetInforTypeById(object o)
        {

            if (o != null)
            {
                int frm = (int)o;
                if (frm == 101)
                {
                    return "广告";
                }
                else if (frm == 102)
                {
                    return "通知";
                }
                else if(frm==103)
                {
                    return "私人消息" ;
                }

            }
            return "未知";
        }

        public String GetManagerById(Object o) 
        {
            if (o != null)
            {
                int frm = (int)o;
                Model.manager m = BLL.BLLManager.manager.GetModel(frm);
                if(m!=null){
                    return m.username;
                }
                return "";

            }
            return "";
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBoxTitle.Text.Equals(""))
            {
                return;
            }
            Model.information infor = new Model.information();
            if (filePath != null && !filePath.Equals(""))
            {
                filePath = "###" + filePath;
            }
            else {
                filePath = "";
            }
            infor.content = txtBoxTitle.Text+filePath;
            infor.manager_id = default_mid;
            infor.infor_type =int.Parse(dpnInfType.SelectedValue);
            infor.gen_time = DateTime.Now;
            infor.from_id = 0;
            infor.to_id = 0;
            infor.readed = 0;
            bool bl = BLL.BLLManager.information.Add(infor);
            if(bl){
                Session["filePath"] = "";
                imgPre.ImageUrl = "";
                filePath = "";
                bindSysInfor();
                txtBoxTitle.Text = "";

            }
            //imgPre
            

        }
        private String filePath = "";

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //获取文件夹路径
            String timestap = DateTime.Now.ToString("yyyyMMddhhmmss");
            string filepath = Server.MapPath("~/uploader/") + timestap;
            String path = filepath + imgUploader.FileName;
            filePath = ("~/uploader/") + timestap + imgUploader.FileName;
            Session["filePath"] = filePath;
            imgUploader.SaveAs(path);
            imgPre.ImageUrl = filePath;
            
        }

        protected void btnShowAdd_Click(object sender, EventArgs e)
        {
            panSaveInfor.Visible = !panSaveInfor.Visible;
        }
    }
}