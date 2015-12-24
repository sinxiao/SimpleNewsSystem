using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:news
	/// </summary>
	public partial class news
	{
		public news()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idnews", "news"); 
		}
        public int ExecuteSql(String sql) 
        {
            return DbHelperMySQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idnews)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from news");
			strSql.Append(" where idnews=@idnews");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into news(");
			strSql.Append("intro,gen_time,writer,title,content,itemid,passcheked,keyword,default_news,clicked,news_url,image_url,comment_sum,verify,verify_id,verify_date)");
			strSql.Append(" values (");
			strSql.Append("@intro,@gen_time,@writer,@title,@content,@itemid,@passcheked,@keyword,@default_news,@clicked,@news_url,@image_url,@comment_sum,@verify,@verify_id,@verify_date)");
            
			MySqlParameter[] parameters = {
					new MySqlParameter("@intro", MySqlDbType.VarChar,700),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp),
					new MySqlParameter("@writer", MySqlDbType.Int32,11),
					new MySqlParameter("@title", MySqlDbType.VarChar,450),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@itemid", MySqlDbType.Int32,11),
					new MySqlParameter("@passcheked", MySqlDbType.Int32,11),
					new MySqlParameter("@keyword", MySqlDbType.VarChar,700),
					new MySqlParameter("@default_news", MySqlDbType.Int32,11),
					new MySqlParameter("@clicked", MySqlDbType.Int32,11),
					new MySqlParameter("@news_url", MySqlDbType.VarChar,450),
					new MySqlParameter("@image_url", MySqlDbType.VarChar,450),
					new MySqlParameter("@comment_sum", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify_date", MySqlDbType.Timestamp)
                                          };
			parameters[0].Value = model.intro;
            //model.gen_time.
            if (model.gen_time==null)
            {
                model.gen_time = DateTime.Now;
            }
            parameters[1].Value = string.Format("{0:G}", model.gen_time);
			parameters[2].Value = model.writer;
			parameters[3].Value = model.title;
			parameters[4].Value = model.content;
			parameters[5].Value = model.itemid;
			parameters[6].Value = model.passcheked;
			parameters[7].Value = model.keyword;
			parameters[8].Value = model.default_news;
			parameters[9].Value = model.clicked;
			parameters[10].Value = model.news_url;
			parameters[11].Value = model.image_url;
			parameters[12].Value = model.comment_sum;
                        
            parameters[13].Value = model.Verify;
            parameters[14].Value = model.Verify_id;


            if (model.Verify_date.Equals(DateTime.MinValue))
            {
                parameters[15].Value = DBNull.Value;
            }
            else {
                parameters[15].Value = string.Format("{0:G}", model.Verify_date);
            }

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update news set ");
			strSql.Append("intro=@intro,");
			strSql.Append("writer=@writer,");
			strSql.Append("title=@title,");
			strSql.Append("content=@content,");
			strSql.Append("itemid=@itemid,");
			strSql.Append("passcheked=@passcheked,");
			strSql.Append("keyword=@keyword,");
			strSql.Append("default_news=@default_news,");
			strSql.Append("clicked=@clicked,");
			strSql.Append("news_url=@news_url,");
			strSql.Append("image_url=@image_url,");
            strSql.Append("verify=@verify ,");
            strSql.Append("verify_id=@verify_id ,");
            strSql.Append("verify_date=@verify_date");
			strSql.Append(" where idnews=@idnews");
            
			MySqlParameter[] parameters = {
					new MySqlParameter("@intro", MySqlDbType.VarChar,700),
					new MySqlParameter("@writer", MySqlDbType.Int32,11),
					new MySqlParameter("@title", MySqlDbType.VarChar,450),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@itemid", MySqlDbType.Int32,11),
					new MySqlParameter("@passcheked", MySqlDbType.Int32,11),
					new MySqlParameter("@keyword", MySqlDbType.VarChar,450),
					new MySqlParameter("@default_news", MySqlDbType.Int32,11),
					new MySqlParameter("@clicked", MySqlDbType.Int32,11),
					new MySqlParameter("@news_url", MySqlDbType.VarChar,450),
					new MySqlParameter("@image_url", MySqlDbType.VarChar,450),
					new MySqlParameter("@comment_sum", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@verify_date", MySqlDbType.Timestamp),
					new MySqlParameter("@idnews", MySqlDbType.Int32,11)
                                          };
			parameters[0].Value = model.intro;
			parameters[1].Value = model.writer;
			parameters[2].Value = model.title;
			parameters[3].Value = model.content;
			parameters[4].Value = model.itemid;
			parameters[5].Value = model.passcheked;
			parameters[6].Value = model.keyword;
			parameters[7].Value = model.default_news;
			parameters[8].Value = model.clicked;
			parameters[9].Value = model.news_url;
			parameters[10].Value = model.image_url;
			parameters[11].Value = model.comment_sum;

            parameters[12].Value = model.Verify;
            parameters[13].Value = model.Verify_id;
            
            if (model.Verify_date.Equals(DateTime.MinValue))
            {
                parameters[14].Value = DBNull.Value;
            }
            else
            {
                parameters[14].Value = string.Format("{0:G}", model.Verify_date);
            }
            

			parameters[15].Value = model.idnews;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idnews)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from news ");
			strSql.Append(" where idnews=@idnews");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idnewslist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from news ");
			strSql.Append(" where idnews in ("+idnewslist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.news GetModel(int idnews)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idnews,intro,gen_time,writer,title,content,itemid,passcheked,keyword,default_news,clicked,news_url,image_url,comment_sum,verify,verify_id,verify_date from news ");
			strSql.Append(" where idnews=@idnews");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews;

			WoeMobile.Model.news model=new WoeMobile.Model.news();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idnews"]!=null && ds.Tables[0].Rows[0]["idnews"].ToString()!="")
				{
					model.idnews=int.Parse(ds.Tables[0].Rows[0]["idnews"].ToString());
				}
				if(ds.Tables[0].Rows[0]["intro"]!=null && ds.Tables[0].Rows[0]["intro"].ToString()!="")
				{
					model.intro=ds.Tables[0].Rows[0]["intro"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gen_time"]!=null && ds.Tables[0].Rows[0]["gen_time"].ToString()!="")
				{
					model.gen_time=DateTime.Parse(ds.Tables[0].Rows[0]["gen_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["writer"]!=null && ds.Tables[0].Rows[0]["writer"].ToString()!="")
				{
					model.writer=int.Parse(ds.Tables[0].Rows[0]["writer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["itemid"]!=null && ds.Tables[0].Rows[0]["itemid"].ToString()!="")
				{
					model.itemid=int.Parse(ds.Tables[0].Rows[0]["itemid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["passcheked"]!=null && ds.Tables[0].Rows[0]["passcheked"].ToString()!="")
				{
					model.passcheked=int.Parse(ds.Tables[0].Rows[0]["passcheked"].ToString());
				}
				if(ds.Tables[0].Rows[0]["keyword"]!=null && ds.Tables[0].Rows[0]["keyword"].ToString()!="")
				{
					model.keyword=(ds.Tables[0].Rows[0]["keyword"].ToString());
				}
				if(ds.Tables[0].Rows[0]["default_news"]!=null && ds.Tables[0].Rows[0]["default_news"].ToString()!="")
				{
					model.default_news=int.Parse(ds.Tables[0].Rows[0]["default_news"].ToString());
				}
				if(ds.Tables[0].Rows[0]["clicked"]!=null && ds.Tables[0].Rows[0]["clicked"].ToString()!="")
				{
					model.clicked=int.Parse(ds.Tables[0].Rows[0]["clicked"].ToString());
				}
				if(ds.Tables[0].Rows[0]["news_url"]!=null && ds.Tables[0].Rows[0]["news_url"].ToString()!="")
				{
					model.news_url=ds.Tables[0].Rows[0]["news_url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["image_url"]!=null && ds.Tables[0].Rows[0]["image_url"].ToString()!="")
				{
					model.image_url=ds.Tables[0].Rows[0]["image_url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["comment_sum"]!=null && ds.Tables[0].Rows[0]["comment_sum"].ToString()!="")
				{
					model.comment_sum=int.Parse(ds.Tables[0].Rows[0]["comment_sum"].ToString());
				}
                if (ds.Tables[0].Rows[0]["verify"] != null && ds.Tables[0].Rows[0]["verify"].ToString() != "")
                {
                    model.Verify = int.Parse(ds.Tables[0].Rows[0]["verify"].ToString());
                }
                if (ds.Tables[0].Rows[0]["verify_id"] != null && ds.Tables[0].Rows[0]["verify_id"].ToString() != "")
                {
                    model.Verify_id = int.Parse(ds.Tables[0].Rows[0]["verify_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["verify_date"] != null && ds.Tables[0].Rows[0]["verify_date"].ToString() != "")
                {
                    model.Verify_date = DateTime.Parse(ds.Tables[0].Rows[0]["verify_date"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idnews,intro,gen_time,writer,title,content,itemid,passcheked,keyword,default_news,clicked,news_url,image_url,comment_sum ,verify,verify_id,verify_date");
			strSql.Append(" FROM news ");
            if (strWhere!=null&&strWhere.Trim() != "")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM news ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
 
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.idnews desc");
			}
			strSql.Append(")AS Row, T.*  from news T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "news";
			parameters[1].Value = "idnews";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

