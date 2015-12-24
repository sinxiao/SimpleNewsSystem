using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using WoeMobile.Common;

namespace WoeMobile.Web.Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private String server_factor = "server_factor58861222qfdwdmorumncue8498nl&%U&E";

        private String client_factor = "clientfactor5875481125578-94ieynmckjgysiepfjkglamzjwuiryrtnggdg981469.+*5440*/5"; 
        /// <summary>
        /// 用户名
        /// </summary>
        private String uname = "uname";//加密后的
        /// <summary>
        /// 密码
        /// </summary>
        private String fpwd = "pwd";
        private BLL.NewsManager newsManager = new BLL.NewsManager();
        private String disfacter = "disfacter";
        private String sqls ="sqls";

        private String getKey(String factor)
        {
            return GetMD5code(client_factor + "younotbad" + factor);
        }
        private String GetMD5code(String source) 
        {
            String md5Code = FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5");

            return md5Code;
        }
        private String getServerKey(String factor)
        {
            return GetMD5code(server_factor + factor);
        }
         String GetClientKey(String factor) 
        {
            return GetMD5code(client_factor + factor);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

           

            String datas = Request.Form.Get("data");
            String factor = Request.Form.Get("factor");
           // datas = AES
            datas = WoeMobile.Common.AES.Decrypt(datas, GetClientKey(factor));
            //datas 的数据形式为:
            char[] plit = "##".ToCharArray();
            string[] values = datas.Split(plit);
            StringBuilder data = new StringBuilder();
            if(values.Length==4)
            {
                //验证身份
                String token = values[1];
                token = AES.Decrypt(token, getKey(factor));

                //手机标示
                String uuid = values[2];
                uuid = AES.Decrypt(uuid, getKey(factor));

                //传送数据加密方式
                String uutype = values[3];


                String sqls = values[0];
                sqls = AES.Decrypt(sqls,getKey(factor));
                String[] sql = sqls.Split(';');
                int len = sql.Length;

               
                ////执行多个数据库操作
                for (int i = 0; i < len;i++ )
                {
                    String v = sql[i];
                    String[] vv = v.Split(',');
                    if(vv.Length==2){
                        //query 1 为查询 非1 为执行操作
                        if (vv[1].Equals("1"))
                        {
                            String r = newsManager.QuerySql(vv[0]);
                            data.Append("").Append(r);
                        }
                        else {
                            int r = newsManager.ExecuteSql(vv[0]);
                            data.Append("").Append(r);
                        }
                    }
                }
               

            }
            
           
            //验证数据完整性  获得信息的解密数据


            //执行数据操作
           // String sqls = Request.Form.Get("data");
            //String query = Request.Form.Get("query");
           
         
            //if (query.Equals("1"))
            //{
            //    if (!sqls.Contains("="))
            //    {
            //        String r = newsManager.QuerySql(sqls);
                   
            //    }
            //    else
            //    {
            //        String[] sql = sqls.Split();

            //        foreach (string s in sql)
            //        {
                        
            //            String r = newsManager.QuerySql(s);
            //            data.Append("=").Append(r);
            //        }
            //    }
            //}
            //else {
            //    if (!sqls.Contains("="))
            //    {
            //        int r = newsManager.ExecuteSql(sqls);
            //        data.Append("").Append(r);
            //    }
            //    else
            //    {
            //        String[] sql = sqls.Split();

            //        foreach (string s in sql)
            //        {
            //            int r = newsManager.ExecuteSql(s);
            //            data.Append("=").Append(r);
            //        }
            //    }
            //}

            
            
          

            //封装处理结果

            //对结果加密校验 
            //发送结果
            Response.Write(data.ToString());
            Response.Flush();
            Response.End();
        }
    }
}