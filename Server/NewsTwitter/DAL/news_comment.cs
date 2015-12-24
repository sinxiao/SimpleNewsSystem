using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:news_comment
	/// </summary>
	public partial class news_comment
	{
		public news_comment()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idnews_comment", "news_comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idnews_comment)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from news_comment");
			strSql.Append(" where idnews_comment=@idnews_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews_comment;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.news_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into news_comment(");
			strSql.Append("comment_name,email,user_id,c_type,content,gen_time,news_id)");
			strSql.Append(" values (");
            strSql.Append("@comment_name,@email,@user_id,@c_type,@content,@gen_time,@news_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@comment_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
                    new MySqlParameter("@c_type", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp),
					new MySqlParameter("@news_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.comment_name;
			parameters[1].Value = model.email;
			parameters[2].Value = model.user_id;
            parameters[3].Value = model.C_type;
			parameters[4].Value = model.content;
			parameters[5].Value = model.gen_time;
			parameters[6].Value = model.news_id;

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
		public bool Update(WoeMobile.Model.news_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update news_comment set ");
			strSql.Append("comment_name=@comment_name,");
			strSql.Append("email=@email,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("content=@content,");
			strSql.Append("news_id=@news_id");
			strSql.Append(" where idnews_comment=@idnews_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@comment_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@news_id", MySqlDbType.Int32,11),
					new MySqlParameter("@idnews_comment", MySqlDbType.Int32,11)};
			parameters[0].Value = model.comment_name;
			parameters[1].Value = model.email;
			parameters[2].Value = model.user_id;
			parameters[3].Value = model.content;
			parameters[4].Value = model.news_id;
			parameters[5].Value = model.idnews_comment;

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
		public bool Delete(int idnews_comment)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from news_comment ");
			strSql.Append(" where idnews_comment=@idnews_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews_comment;

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
		public bool DeleteList(string idnews_commentlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from news_comment ");
			strSql.Append(" where idnews_comment in ("+idnews_commentlist + ")  ");
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
		public WoeMobile.Model.news_comment GetModel(int idnews_comment)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idnews_comment,comment_name,email,user_id,content,gen_time,news_id from news_comment ");
			strSql.Append(" where idnews_comment=@idnews_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idnews_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idnews_comment;

			WoeMobile.Model.news_comment model=new WoeMobile.Model.news_comment();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idnews_comment"]!=null && ds.Tables[0].Rows[0]["idnews_comment"].ToString()!="")
				{
					model.idnews_comment=int.Parse(ds.Tables[0].Rows[0]["idnews_comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["comment_name"]!=null && ds.Tables[0].Rows[0]["comment_name"].ToString()!="")
				{
					model.comment_name=ds.Tables[0].Rows[0]["comment_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["user_id"]!=null && ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["gen_time"]!=null && ds.Tables[0].Rows[0]["gen_time"].ToString()!="")
				{
					model.gen_time=DateTime.Parse(ds.Tables[0].Rows[0]["gen_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["news_id"]!=null && ds.Tables[0].Rows[0]["news_id"].ToString()!="")
				{
					model.news_id=int.Parse(ds.Tables[0].Rows[0]["news_id"].ToString());
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
			strSql.Append("select idnews_comment,comment_name,email,user_id,content,gen_time,news_id ");
			strSql.Append(" FROM news_comment ");
			if(strWhere.Trim()!="")
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
			strSql.Append("select count(1) FROM news_comment ");
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
				strSql.Append("order by T.idnews_comment desc");
			}
			strSql.Append(")AS Row, T.*  from news_comment T ");
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
			parameters[0].Value = "news_comment";
			parameters[1].Value = "idnews_comment";
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

