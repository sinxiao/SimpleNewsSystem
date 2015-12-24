using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoeMobile.Web.Client
{
    /// <summary>
    /// 自动注册和记录用户的行为，保存到euser里，保存获得imei等数据到 longtwitter里
    /// 
    /// data 可以以后分析数据使用
    /// 发送广告推送 发送鸣谢的广告  
    /// 用户分享微博，分享给其他人，其他人有什么看法
    /// post_type 1、保存用户信息并，获得广告
    ///            2、获得广告
    ///            3、发送分享了微博
    /// </summary>
    public partial class UserClientDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String imei = Request.Form["imei"];
                String data = Request.Form["data"];
                String post_type = Request.Form["post_type"];
                List<Model.euser> users = BLL.BLLManager.euser.GetModelList("in_email like '%"+imei+"@%' ");

                if (users != null && users.Count > 1)
                {//判断用户是否存在，如果不存在则注册
                    Model.long_twitter ltwit = new Model.long_twitter();
                    ltwit.uid = users[0].uid;
                    ltwit.blog = data;
                    ltwit.twitter_id = -100;
                    bool bl2 = BLL.BLLManager.long_twitter.Add(ltwit);
                    if (bl2)
                    {//保存数据成功

                    }
                }
                else  {
                    Model.euser euser = new Model.euser();
                    euser.in_email = imei+"@woemobile.com";
                    euser.in_pwd = BizNeed.WebUtils.getMd5Hash(euser.in_email);
                    euser.nick_name = "trablem";
                    
                    //DBOperation dbo = new DBOperation();
                    bool bl = BLL.BLLManager.euser.Add(euser);
                    if(bl)
                    {
                        List<Model.euser> nowss = BLL.BLLManager.euser.GetModelList("in_email = '" + euser.in_email + "' ");
                        if(nowss!=null&&nowss.Count>=1)
                        {
                            Model.long_twitter ltwit = new Model.long_twitter();
                            ltwit.uid = nowss[0].uid;
                            ltwit.blog = data;
                            ltwit.twitter_id = -100;
                            bool bl2 = BLL.BLLManager.long_twitter.Add(ltwit);
                            if(bl2)
                            {//保存数据成功

                            }
                        }
                    }
                }

                //发送广告
                List<Model.information> linfors = BLL.BLLManager.information.GetModelList("infor_type = " + 101 + " order by idinformation desc limit 0,8 ");

                String lt = fastJSON.JSON.Instance.ToJSON(linfors);
                Response.Write(lt);
                Response.Flush();
                Response.End();
            }
        }
    }
}