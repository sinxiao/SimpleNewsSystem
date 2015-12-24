using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace WoeMobile.Web.Admin.Accounts.Picture
{
    public partial class ImageByLocationList : System.Web.UI.Page
    {
        private int def_locId;

        public String def_traceId = "3";
        public int default_uid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //获得def locationId
                String locId = Request.Params["lid"];
                def_locId =int.Parse(locId);
                Session["def_locId"] = def_locId;
                bindImageListByLocation(locId);
            }
            def_locId =(int) Session["def_locId"];
            def_traceId = (String)Session["def_traceId"];
            default_uid = (int)Session["default_uid"];
        }
        public String getImagePath(Object item, String type)
        {
            RowData rData = (RowData)item;
            int tp = int.Parse(type);
            if(tp==1){
                if (rData.One!=null)
                {
                    return rData.One.image_src;
                }
                
            }else if(tp==2){
                if (rData.Two != null)
                return rData.Two.image_src;
            }else if(tp==3){
                if (rData.Three != null)
                return rData.Three.image_src;
            }else if(tp==4){
                if (rData.Four != null)
                return rData.Four.image_src;
            }
            return "";
        }

        private void bindImageListByLocation(String locId) 
        {      
            List<Model.images> imgs =  BLL.BLLManager.images.GetModelList(" location_id = "+locId);
            List<RowData> rows = new List<RowData>();
            int size = imgs.Count / 4;
            size = size + (imgs.Count % 4 == 0 ? 0 : 1);
      
            for (int i = 0; i < size;i++ )
            {
                RowData rData = new RowData();
                rData.One = getImage(imgs,i*4);
                rData.Two = getImage(imgs, i*4+1);
                rData.Three = getImage(imgs, i*4+2);
                rData.Four = getImage(imgs, i*4+3);
                rows.Add(rData);
            }
            repeaterImage.DataSource = rows;
            repeaterImage.DataSourceID = null;
            repeaterImage.DataBind();
        }
        private Model.images getImage( List<Model.images> imgs,int idx) 
        {
            if (imgs.Count>idx)
            {
                return imgs[idx];
            }
            return null;
        }
        // 该方法是将页面中的上传文件的控件保存到session中
        private void SFUPC()
        {
            //声明一个ArrayList用于存放上传文件的控件
            ArrayList AL = new ArrayList();
            foreach (Control C in this.Tab_UpDownFile.Controls)
            {
                if (C.GetType().ToString() == "System.Web.UI.HtmlControls.HtmlTableRow")
                {
                    HtmlTableCell HTC = (HtmlTableCell)C.Controls[0];
                    foreach (Control FUC in HTC.Controls)
                    {
                        if (FUC.GetType().ToString() == "System.Web.UI.WebControls.FileUpload")
                        {
                            FileUpload FU = (FileUpload)FUC;
                            FU.BorderColor = System.Drawing.Color.DimGray;
                            FU.BorderWidth = 1;
                            AL.Add(FU);
                        }
                    }
                }
            }
            Session.Add("FilesControls", AL);
        }
        public class RowData
        {
            Model.images one;

            public Model.images One
            {
                get { return one; }
                set { one = value; }
            }
            Model.images two;

            public Model.images Two
            {
                get { return two; }
                set { two = value; }
            }
            Model.images three;

            public Model.images Three
            {
                get { return three; }
                set { three = value; }
            }
            Model.images four;

            public Model.images Four
            {
                get { return four; }
                set { four = value; }
            }
        }
    #region 该方法用于添加一个上传文件的控件
    private void InsertC()
    { 
       //实例化一个ArrayList
        ArrayList AL = new ArrayList();
        //清除表里的所有行
        this.Tab_UpDownFile.Rows.Clear();
         //获得Session里存放的上传文件的控件
        GetInfo();
        //实例化表格的行
        HtmlTableRow HTR = new HtmlTableRow();
        //实例化表格的列
        HtmlTableCell HTC = new HtmlTableCell();
        //向列里添加上传控件
        HTC.Controls.Add(new FileUpload());
        HTR.Controls.Add(HTC);
        this.Tab_UpDownFile.Rows.Add(HTR);
        SFUPC();
    }
    #endregion
    #region 该方法将session中的上传控件集添加的表格中
    private void GetInfo()
    {
        ArrayList AL = new ArrayList();
        if (Session["FilesControls"] != null)
        {
            AL = (ArrayList)Session["FilesControls"];
            foreach (FileUpload FU in AL)
            {
                HtmlTableRow HTR = new HtmlTableRow();
                HtmlTableCell HTC = new HtmlTableCell();
                HTC.Controls.Add(FU);
                HTR.Controls.Add(HTC);
                this.Tab_UpDownFile.Rows.Add(HTR);
            }
        }
    }
    #endregion
    #region 该方法用于执行文件上传操作
    private void UpFile()
    {
        //获取文件夹路径
        String timestap =  DateTime.Now.ToString("yyyyMMddhhmmss") ;
        string filepath = Server.MapPath("~/uploader/") +timestap;
        //获取客服端上载文件的集合
        HttpFileCollection HFC = Request.Files;
        for (int i = 0; i < HFC.Count; i++)
        {
            HttpPostedFile UserHPF = (HttpPostedFile)HFC[i];
            try
            {
                //String path = Server.MapPath("~/uploader/");
                //String end = DateTime.Now.ToString("yyyyMMddhhmmss") + Session.SessionID + file;
                //fileUploadImg.SaveAs(path + end);
                //imgPre.ImageUrl = "~/uploader/" + end;

                if (UserHPF.ContentLength > 0)
                {
                    String path = filepath + UserHPF.FileName;
                    UserHPF.SaveAs(path);
                    Model.images img = new Model.images();
                    img.image_src = ("~/uploader/") + timestap + UserHPF.FileName;
                    img.location_id = def_locId;
                    img.trace_id = int.Parse(def_traceId);
                    img.uid = default_uid;
                    BLL.BLLManager.images.Add(img);
                    
                }
                bindImageListByLocation(def_locId+"");
            }
            catch
            {
                this.LblMessage.Text = "上传失败！";
            }

        }
        if (Session["FilesControls"] != null)
        {
            Session.Remove("FILEsCOntrols");
        }
        this.LblMessage.Text = "上传成功！";
    }
    #endregion

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        InsertC();
        this.LblMessage.Text = "";
    }

    protected void BtnUpFile_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.PostedFile.FileName != null)
        {
            UpFile();
            SFUPC();
        }
        else
        {
            this.LblMessage.Text = "对不起！上传文件不能为空";
        }
    }

    protected void btnUploadImg_Click(object sender, EventArgs e)
    {
        panalUpload.Visible = !panalUpload.Visible;
    }

    }
}