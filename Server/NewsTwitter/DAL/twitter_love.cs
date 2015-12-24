using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:twitter_love
	/// </summary>
	public partial class twitter_love
	{
		public twitter_love()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idtwitter_love", "twitter_love"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idtwitter_love)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from twitter_love");
			strSql.Append(" where idtwitter_love=@idtwitter_love ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_love", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_love;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter_love model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into twitter_love(");
			strSql.Append("idtwitter_love,twitter_id,euser_id,content,gen_time)");
			strSql.Append(" values (");
			strSql.Append("@idtwitter_love,@twitter_id,@euser_id,@content,@gen_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_love", MySqlDbType.Int32,11),
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@euser_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.VarChar,450),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp)};
			parameters[0].Value = model.idtwitter_love;
			parameters[1].Value = model.twitter_id;
			parameters[2].Value = model.euser_id;
			parameters[3].Value = model.content;
			parameters[4].Value = model.gen_time;

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
		public bool Update(WoeMobile.Model.twitter_love model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update twitter_love set ");
			strSql.Append("twitter_id=@twitter_id,");
			strSql.Append("euser_id=@euser_id,");
			strSql.Append("content=@content");
			strSql.Append(" where idtwitter_love=@idtwitter_love ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@euser_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.VarChar,450),
					new MySqlParameter("@idtwitter_love", MySqlDbType.Int32,11)};
			parameters[0].Value = model.twitter_id;
			parameters[1].Value = model.euser_id;
			parameters[2].Value = model.content;
			parameters[3].Value = model.idtwitter_love;

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
		public bool Delete(int idtwitter_love)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter_love ");
			strSql.Append(" where idtwitter_love=@idtwitter_love ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_love", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_love;

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
		public bool DeleteList(string idtwitter_lovelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter_love ");
			strSql.Append(" where idtwitter_love in ("+idtwitter_lovelist + ")  ");
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
		public WoeMobile.Model.twitter_love GetModel(int idtwitter_love)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idtwitter_love,twitter_id,euser_id,content,gen_time from twitter_love ");
			strSql.Append(" where idtwitter_love=@idtwitter_love ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_love", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_love;

			WoeMobile.Model.twitter_love model=new WoeMobile.Model.twitter_love();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idtwitter_love"]!=null && ds.Tables[0].Rows[0]["idtwitter_love"].ToString()!="")
				{
					model.idtwitter_love=int.Parse(ds.Tables[0].Rows[0]["idtwitter_love"].ToString());
				}
				if(ds.Tables[0].Rows[0]["twitter_id"]!=null && ds.Tables[0].Rows[0]["twitter_id"].ToString()!="")
				{
					model.twitter_id=int.Parse(ds.Tables[0].Rows[0]["twitter_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["euser_id"]!=null && ds.Tables[0].Rows[0]["euser_id"].ToString()!="")
				{
					model.euser_id=int.Parse(ds.Tables[0].Rows[0]["euser_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
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
			strSql.Append("select idtwitter_love,twitter_id,euser_id,content,gen_time ");
			strSql.Append(" FROM twitter_love ");
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
			strSql.Append("select count(1) FROM twitter_love ");
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
				strSql.Append("order by T.idtwitter_love desc");
			}
			strSql.Append(")AS Row, T.*  from twitter_love T ");
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
			parameters[0].Value = "twitter_love";
			parameters[1].Value = "idtwitter_love";
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

