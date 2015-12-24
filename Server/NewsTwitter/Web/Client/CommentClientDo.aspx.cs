using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

/****
 * 执行添加和获取评论的操作 
 * 1、根据newsId添加评论         101
 * 2、根据newsId获得分页评论     102
 * 3、增加一个news的 浏览量 或 评论量   103
 * 
 * 
 * http://localhost:3449/NewsTwitter/Client/CommentClientDo.aspx?method=101&arg=1  arg 为newsId
 * http://localhost:3449/NewsTwitter/Client/CommentClientDo.aspx?method=102&arg=1  arg 为newsId
 * http://localhost:3449/NewsTwitter/Client/CommentClientDo.aspx?method=103&arg=1  arg 为newsId 
 * 
 */
namespace WoeMobile.Web.Client
{
    public partial class CommentClientDo : System.Web.UI.Page
    {
        private static String POST_COMMENT_BY_NEWS = "101";
        private static String GET_COMMENT_BY_NEWS = "102";
        private static String INCREA_BY_NEWS_RD_COMMENT = "103";


        private BLL.News_commentManager news_commentManager = new BLL.News_commentManager();
        private BLL.NewsManager newsManager = new BLL.NewsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获得 get里的信息
            String method = Request.QueryString["method"];
            String arg = Request.QueryString["arg"];
            StringBuilder data = new StringBuilder();

            if (method != null && arg != null)
            {
                if (method.Equals(GET_COMMENT_BY_NEWS)) //查询评论
                {
                    int nid = int.Parse(arg);
                    String page = Request.Form.Get("page");
                    String count = Request.Form.Get("count");

                    List<Model.news_comment> news = null;
                    if (page != null && count != null)
                    {
                        news = news_commentManager.GetCommentByItemAndPage(nid, int.Parse(page), int.Parse(count)," c_type = 1 ");
                    }
                    else
                        news = news_commentManager.GetCommentByNewsId(nid);

                    if(news!=null&&news.Count>0)
                    {
                        int size = news.Count;
                        for (int i = 0; i < size;i++ )
                        {
                            Model.news_comment comm = news[i];
                            List<Model.news_comment> smel = news_commentManager.GetCommentByItemAndPage(comm.idnews_comment, 1, int.Parse(count), " c_type = 3 ");
                            
                        }
                       
                    }
                    String lt = fastJSON.JSON.Instance.ToJSON(news);

                    data.Append(lt);
                    news = null;
                } else if (method.Equals(POST_COMMENT_BY_NEWS)) //发表评论
                {
                    int nid = int.Parse(arg);

                    String comment = Request.Form.Get("comment");
                    String uid = Request.Form.Get("uid");
                    String c_type = Request.Form.Get("c_type");
                    Model.news_comment ncomment = new Model.news_comment();
                    if (uid != null)
                    {
                        ncomment.user_id = int.Parse(uid);
                    }
                    else {
                        String email = Request.Form.Get("email");
                        if(email!=null)
                        {
                            ncomment.email = email;
                        }
                    }
                    
                    ncomment.content = comment;
                    ncomment.gen_time = DateTime.Now; 
                    ncomment.news_id = nid;
                    if (c_type!=null)
                    {
                        ncomment.C_type = int.Parse(c_type);
                    }else
                        ncomment.C_type = 1;

                    Boolean bl = news_commentManager.Add(ncomment);
                    Model.news nws = newsManager.GetModel(int.Parse(arg));
                    newsManager.ExecuteSql("update news set comment_sum =  " + (nws.comment_sum + 1) + " where  idnews = " + nws.idnews);

                    if (bl)
                    {//{rst:"ok"}
                        data.Append("{rst:\"ok\"}");
                    }
                    else {
                        data.Append("{rst:\"fail\"}");
                    }
                    ncomment = null;
                }
                else if (method.Equals(INCREA_BY_NEWS_RD_COMMENT))
                {
                    String uid = Request.Form.Get("uid");
                    String type = Request.Form.Get("type");
                    Model.news nws = newsManager.GetModel(int.Parse(arg));
                    int i = -1;
                    if(type.Contains("clicked"))
                    {
                        i = newsManager.ExecuteSql("update news set clicked =  " + (nws.clicked + 1) + " where  idnews = " + nws.idnews);
                    }
                    else if (type.Contains("comment"))
                    {
                        i = newsManager.ExecuteSql("update news set comment_sum =  " + (nws.comment_sum + 1) + " where  idnews = " + nws.idnews);
                    }
                    
                    if (i > 0)
                    {
                        data.Append("{rst:\"ok\"}");
                    }
                    else {
                        data.Append("{rst:\"fail\"}");
                    }
                    nws = null;
                }
            }

            Response.Write(data.ToString());
            Response.Flush();
            Response.End();
        }
    }
}