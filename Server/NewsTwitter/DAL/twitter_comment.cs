using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:twitter_comment
	/// </summary>
	public partial class twitter_comment
	{
		public twitter_comment()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idtwitter_comment", "twitter_comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idtwitter_comment)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from twitter_comment");
			strSql.Append(" where idtwitter_comment=@idtwitter_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idtwitter_comment;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into twitter_comment(");
			strSql.Append("twitter_id,comment,uuser_id,gen_time)");
			strSql.Append(" values (");
			strSql.Append("@twitter_id,@comment,@uuser_id,@gen_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@comment", MySqlDbType.VarChar,450),
					new MySqlParameter("@uuser_id", MySqlDbType.Int32,11),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp)};
			parameters[0].Value = model.twitter_id;
			parameters[1].Value = model.comment;
			parameters[2].Value = model.uuser_id;
			parameters[3].Value = model.gen_time;

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
		public bool Update(WoeMobile.Model.twitter_comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update twitter_comment set ");
			strSql.Append("twitter_id=@twitter_id,");
			strSql.Append("comment=@comment,");
			strSql.Append("uuser_id=@uuser_id");
			strSql.Append(" where idtwitter_comment=@idtwitter_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@comment", MySqlDbType.VarChar,450),
					new MySqlParameter("@uuser_id", MySqlDbType.Int32,11),
					new MySqlParameter("@idtwitter_comment", MySqlDbType.Int32,11)};
			parameters[0].Value = model.twitter_id;
			parameters[1].Value = model.comment;
			parameters[2].Value = model.uuser_id;
			parameters[3].Value = model.idtwitter_comment;

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
		public bool Delete(int idtwitter_comment)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter_comment ");
			strSql.Append(" where idtwitter_comment=@idtwitter_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idtwitter_comment;

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
		public bool DeleteList(string idtwitter_commentlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter_comment ");
			strSql.Append(" where idtwitter_comment in ("+idtwitter_commentlist + ")  ");
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
		public WoeMobile.Model.twitter_comment GetModel(int idtwitter_comment)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idtwitter_comment,twitter_id,comment,uuser_id,gen_time from twitter_comment ");
			strSql.Append(" where idtwitter_comment=@idtwitter_comment");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_comment", MySqlDbType.Int32)
			};
			parameters[0].Value = idtwitter_comment;

			WoeMobile.Model.twitter_comment model=new WoeMobile.Model.twitter_comment();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idtwitter_comment"]!=null && ds.Tables[0].Rows[0]["idtwitter_comment"].ToString()!="")
				{
					model.idtwitter_comment=int.Parse(ds.Tables[0].Rows[0]["idtwitter_comment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["twitter_id"]!=null && ds.Tables[0].Rows[0]["twitter_id"].ToString()!="")
				{
					model.twitter_id=int.Parse(ds.Tables[0].Rows[0]["twitter_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["comment"]!=null && ds.Tables[0].Rows[0]["comment"].ToString()!="")
				{
					model.comment=ds.Tables[0].Rows[0]["comment"].ToString();
				}
				if(ds.Tables[0].Rows[0]["uuser_id"]!=null && ds.Tables[0].Rows[0]["uuser_id"].ToString()!="")
				{
					model.uuser_id=int.Parse(ds.Tables[0].Rows[0]["uuser_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gen_time"]!=null && ds.Tables[0].Rows[0]["gen_time"].ToString()!="")
				{
					model.gen_time=DateTime.Parse(ds.Tables[0].Rows[0]["gen_time"].ToString());
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
			strSql.Append("select idtwitter_comment,twitter_id,comment,uuser_id,gen_time ");
			strSql.Append(" FROM twitter_comment ");
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
			strSql.Append("select count(1) FROM twitter_comment ");
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
				strSql.Append("order by T.idtwitter_comment desc");
			}
			strSql.Append(")AS Row, T.*  from twitter_comment T ");
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
			parameters[0].Value = "twitter_comment";
			parameters[1].Value = "idtwitter_comment";
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

