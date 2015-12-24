using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:long_twitter
	/// </summary>
	public partial class long_twitter
	{
		public long_twitter()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idtwitter_demo", "long_twitter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idtwitter_demo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from long_twitter");
			strSql.Append(" where idtwitter_demo=@idtwitter_demo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_demo", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_demo;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.long_twitter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into long_twitter(");
			strSql.Append("blog,images,twitter_id,uid,title)");
			strSql.Append(" values (");
			strSql.Append("@blog,@images,@twitter_id,@uid,@title)");
			MySqlParameter[] parameters = {
				//	new MySqlParameter("@idtwitter_demo", MySqlDbType.Int32,11),
					new MySqlParameter("@blog", MySqlDbType.Text),
					new MySqlParameter("@images", MySqlDbType.Text),
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@title", MySqlDbType.VarChar,450)};
			//parameters[0].Value = model.idtwitter_demo;
			parameters[0].Value = model.blog;
			parameters[1].Value = model.images;
			parameters[2].Value = model.twitter_id;
			parameters[3].Value = model.uid;
            parameters[4].Value = model.title == null ? "" : model.title;

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
		public bool Update(WoeMobile.Model.long_twitter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update long_twitter set ");
			strSql.Append("blog=@blog,");
			strSql.Append("images=@images,");
			strSql.Append("twitter_id=@twitter_id,");
			strSql.Append("uid=@uid,");
			strSql.Append("title=@title");
			strSql.Append(" where idtwitter_demo=@idtwitter_demo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@blog", MySqlDbType.Text),
					new MySqlParameter("@images", MySqlDbType.Text),
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@title", MySqlDbType.VarChar,450),
					new MySqlParameter("@idtwitter_demo", MySqlDbType.Int32,11)};
			parameters[0].Value = model.blog;
			parameters[1].Value = model.images;
			parameters[2].Value = model.twitter_id;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.title;
			parameters[5].Value = model.idtwitter_demo;

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
		public bool Delete(int idtwitter_demo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from long_twitter ");
			strSql.Append(" where idtwitter_demo=@idtwitter_demo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_demo", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_demo;

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
		public bool DeleteList(string idtwitter_demolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from long_twitter ");
			strSql.Append(" where idtwitter_demo in ("+idtwitter_demolist + ")  ");
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
		public WoeMobile.Model.long_twitter GetModel(int idtwitter_demo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idtwitter_demo,blog,images,twitter_id,uid,title from long_twitter ");
			strSql.Append(" where idtwitter_demo=@idtwitter_demo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtwitter_demo", MySqlDbType.Int32,11)			};
			parameters[0].Value = idtwitter_demo;

			WoeMobile.Model.long_twitter model=new WoeMobile.Model.long_twitter();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idtwitter_demo"]!=null && ds.Tables[0].Rows[0]["idtwitter_demo"].ToString()!="")
				{
					model.idtwitter_demo=int.Parse(ds.Tables[0].Rows[0]["idtwitter_demo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["blog"]!=null && ds.Tables[0].Rows[0]["blog"].ToString()!="")
				{
					model.blog=ds.Tables[0].Rows[0]["blog"].ToString();
				}
				if(ds.Tables[0].Rows[0]["images"]!=null && ds.Tables[0].Rows[0]["images"].ToString()!="")
				{
					model.images=ds.Tables[0].Rows[0]["images"].ToString();
				}
				if(ds.Tables[0].Rows[0]["twitter_id"]!=null && ds.Tables[0].Rows[0]["twitter_id"].ToString()!="")
				{
					model.twitter_id=int.Parse(ds.Tables[0].Rows[0]["twitter_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
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
			strSql.Append("select idtwitter_demo,blog,images,twitter_id,uid,title ");
			strSql.Append(" FROM long_twitter ");
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
			strSql.Append("select count(1) FROM long_twitter ");
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
				strSql.Append("order by T.idtwitter_demo desc");
			}
			strSql.Append(")AS Row, T.*  from long_twitter T ");
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
			parameters[0].Value = "long_twitter";
			parameters[1].Value = "idtwitter_demo";
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

