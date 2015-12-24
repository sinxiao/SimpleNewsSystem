using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Client
{
    public partial class PostFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String uname = Request.Params["uname"];//用户名字
                String uid = Request.Params["uid"];//用户 id
                HttpFileCollection fileList = HttpContext.Current.Request.Files;
                //首先获得用户标示，
                //获得要上传的名字，location，没有则需要创建
                //进行处理，保存数据
                for (int i = 0; i < fileList.Count; i++)
                {
                    HttpPostedFile hPostedFile = fileList[i];
                    String fileName;
                    fileName = hPostedFile.FileName;

                    hPostedFile.SaveAs(Server.MapPath("~/uploader/") + fileName);
                    //上传成功后，把路径地址放到数据库里

                }
            }
        }
    }
}