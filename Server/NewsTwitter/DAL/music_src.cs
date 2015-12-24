using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:music_src
	/// </summary>
	public partial class music_src
	{
		public music_src()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("music_src_id", "music_src"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int music_src_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from music_src");
			strSql.Append(" where music_src_id=@music_src_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_src_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_src_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.music_src model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into music_src(");
			strSql.Append("music_id,src)");
			strSql.Append(" values (");
			strSql.Append("@music_id,@src)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_id", MySqlDbType.Int32,11),
					new MySqlParameter("@src", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.music_id;
			parameters[1].Value = model.src;

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
		public bool Update(WoeMobile.Model.music_src model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update music_src set ");
			strSql.Append("music_id=@music_id,");
			strSql.Append("src=@src");
			strSql.Append(" where music_src_id=@music_src_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_id", MySqlDbType.Int32,11),
					new MySqlParameter("@src", MySqlDbType.VarChar,200),
					new MySqlParameter("@music_src_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.music_id;
			parameters[1].Value = model.src;
			parameters[2].Value = model.music_src_id;

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
		public bool Delete(int music_src_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from music_src ");
			strSql.Append(" where music_src_id=@music_src_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_src_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_src_id;

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
		public bool DeleteList(string music_src_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from music_src ");
			strSql.Append(" where music_src_id in ("+music_src_idlist + ")  ");
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
		public WoeMobile.Model.music_src GetModel(int music_src_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select music_src_id,music_id,src from music_src ");
			strSql.Append(" where music_src_id=@music_src_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_src_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_src_id;

			WoeMobile.Model.music_src model=new WoeMobile.Model.music_src();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["music_src_id"]!=null && ds.Tables[0].Rows[0]["music_src_id"].ToString()!="")
				{
					model.music_src_id=int.Parse(ds.Tables[0].Rows[0]["music_src_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["music_id"]!=null && ds.Tables[0].Rows[0]["music_id"].ToString()!="")
				{
					model.music_id=int.Parse(ds.Tables[0].Rows[0]["music_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["src"]!=null && ds.Tables[0].Rows[0]["src"].ToString()!="")
				{
					model.src=ds.Tables[0].Rows[0]["src"].ToString();
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
			strSql.Append("select music_src_id,music_id,src ");
			strSql.Append(" FROM music_src ");
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
			strSql.Append("select count(1) FROM music_src ");
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
				strSql.Append("order by T.music_src_id desc");
			}
			strSql.Append(")AS Row, T.*  from music_src T ");
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
			parameters[0].Value = "music_src";
			parameters[1].Value = "music_src_id";
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

