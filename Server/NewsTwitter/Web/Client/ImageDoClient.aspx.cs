using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoeMobile.Web.BizNeed;

namespace WoeMobile.Web.Client
{
    public partial class ImageDoClient : System.Web.UI.Page
    {

        /***
         * 图片相关处理 
         * 
         */
        protected void Page_Load(object sender, EventArgs e)
        {
                                            
            if(!IsPostBack)
            {
                String count = Request.Form.Get("pagecount");
                String idx = Request.Form.Get("pg_idx");
                String method = Request.Form.Get("methhod_id");
                String locid = Request.Form.Get("locationid");

             //   count = "20";
              // idx = "1";
               // method = "3";
                //locid = "8";
                if(method!=null){
                    // Response.Headers.Add("METHOD_ID", method);
                    int methodid = int.Parse(method);
                    String lt = null;
                    if (methodid == 3)
                    {
                        HttpResult hrt = new HttpResult();
                        hrt.Method_id = 3;
                        hrt.Result_status = 200;
                        hrt.Rt =
                        BLL.BLLManager.images.GetImagesByLocationAndPage(int.Parse(locid), int.Parse(idx), int.Parse(count));
                        foreach(Model.images img in hrt.Rt){
                            if (img.image_src != null && !img.image_src.Equals(""))
                            {

                                img.image_src = "http://" + Request.Url.Host.ToString() + ":" + Request.ServerVariables.Get("server_port") + Request.ApplicationPath + img.image_src.Substring(1).Trim();
                            }
                        }
                      
                            //var uri = new Uri(Request.Url,ns.image_url);
                                
                        
                        lt = fastJSON.JSON.Instance.ToJSON(hrt);
                    }

                    Response.Write(lt);
                    Response.Flush();
                    Response.End();
                }
               
            }
        }
    }
}