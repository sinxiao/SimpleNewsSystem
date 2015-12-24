using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WoeMobile.Web.Client
{
    /**
     * /Client/UserDoClient.aspx?method=101&arg=1
     * 用户操作的相关操作
     * 1、用户注册/登录    201  arg: 1为登陆 2为注册
     * 2、用户提交手机信息 202
     * 3、用户提交统计信息 203 
     * 4、向好友发请求  204
     * 5、向好友发消息  205
     * 
     * http://localhost:3449/NewsTwitter/Client/UserDoClient.aspx?method=201&arg=1  登陆
     * 
     */
    public partial class UserDoClient : System.Web.UI.Page
    {
        private String LOGIN_REQUEST = "201";
        private String POST_INFOR = "202";
        private String POST_PHONE_INFOR = "202";
        protected void Page_Load(object sender, EventArgs e)
        {
            //获得 get里的信息
            String method = Request.QueryString["method"];
            String arg = Request.QueryString["arg"];
            StringBuilder data = new StringBuilder();


            if (method != null && arg != null)
            {
                //用户注册/登录 

                //用户提交手机信息

                //用户提交统计信息
            }

        }
    }
}