using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Data;

namespace WoeMobile.Web.Client
{
    /***
     *  /Client/NewsDoClient.aspx?method=101&arg=1
     * 对新闻列表的操作，
     * 1、获得全部新闻列表   101
     * 2、获得一个类别的新闻列表 102
     * 3、根据新闻Id获得新闻的详细信息 103
     * 5、根据新闻获得相应的评论 104
     * 6、根据版块名字获得Id 105
     * 
     * 
     * 
     * http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=101&arg=1
     * 
     * http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=102&arg=1
     * 
     * http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=103&arg=2
     * 
     * http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=103&arg=2
     */
    public partial class NewsDoClient : System.Web.UI.Page  
    {


        private static String GET_ALL_ITEM = "101";
        private  static String GET_NEWS_BY_ITEM = "102";
        private  static String GET_NEWS_BY_ID = "103";
        private static String GET_COMMENT_BY_NEWS = "104";
        private static String GET_ITEM_BY_NAME = "105";
        private BLL.ItemManager itemManager = new BLL.ItemManager();
        private BLL.NewsManager newsManager = new BLL.NewsManager();
        private BLL.News_commentManager news_commentManager = new BLL.News_commentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获得 get里的信息
            String method = Request.QueryString["method"];
            String arg = Request.QueryString["arg"];
            StringBuilder data = new StringBuilder();

            
            if(method!=null&&arg!=null)
            {
                //根据相应的get获得处理方法
                if (method.Equals(GET_ALL_ITEM))
                {
                    //  List<Model.item> allitem = itemManager.getParentItem();
                    //String lt = fastJSON.JSON.Instance.ToJSON(allitem);
                    List<Model.item> allitem = itemManager.getParentItem();
                    String lt = fastJSON.JSON.Instance.ToJSON(allitem);
                    data.Append(lt);
                }
                else if (method.Equals(GET_NEWS_BY_ID))
                {
                    int nid = int.Parse(arg);
                    Model.news news = newsManager.GetModelByCache(nid);
                    String lt = fastJSON.JSON.Instance.ToJSON(news);
                    data.Append(lt);
                }
                else if (method.Equals(GET_NEWS_BY_ITEM))
                {
                    int nid = int.Parse(arg);
                    String page = Request.Form.Get("page");
                    String count = Request.Form.Get("count");
                    List<Model.news> news =null ;
                    if (page != null && count != null)
                    {
                        news = newsManager.GetNewsByItemAndPage(nid, int.Parse(page), int.Parse(count));
                    }
                    else
                    {
                        news = newsManager.GetNewsByItem(nid);
                    }

                    if(news!=null&&news.Capacity>0)
                    {
                        int size = news.Count;
                        for (int i = 0; i < size;i++ )
                        {
                            Model.news ns = news[i];
                            String url = ns.image_url;
                            if(url!=null&&!url.Trim().Equals(""))
                            {
                                //var uri = new Uri(Request.Url,ns.image_url);
                                news[i].image_url = "http://" + Request.Url.Host.ToString() + ":"+Request.ServerVariables.Get("server_port") +Request.ApplicationPath + url.Substring(1);
                            }
                        }
                    }
                    String lt = fastJSON.JSON.Instance.ToJSON(news);
                    data.Append(lt);
                }
                else if (method.Equals(GET_COMMENT_BY_NEWS))
                {
                    int nid = int.Parse(arg);
                    List<Model.news_comment> news = news_commentManager.GetCommentByNewsId(nid);
                    String lt = fastJSON.JSON.Instance.ToJSON(news);
                    data.Append(lt);
                }
                else if (method.Equals(GET_ITEM_BY_NAME))
                {
                    String name = Request["item_name"];
                    Model.item item = itemManager.GetItemByName(name);
                    
                    if (item != null)
                    {
                        String lt = fastJSON.JSON.Instance.ToJSON(item);
                        data.Append(lt);
                    }
                    else
                    {
                        data.Append("null");
                    }
                }
                Response.Write(data.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}