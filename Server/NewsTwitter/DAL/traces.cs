using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:traces
	/// </summary>
	public partial class traces
	{
		public traces()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idtraces", "traces"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idtraces)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from traces");
			strSql.Append(" where idtraces=@idtraces");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtraces", MySqlDbType.Int32)
			};
			parameters[0].Value = idtraces;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.traces model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into traces(");
			strSql.Append("uid,trace_name,build_time,end_time)");
			strSql.Append(" values (");
			strSql.Append("@uid,@trace_name,@build_time,@end_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@build_time", MySqlDbType.VarChar,45),
					new MySqlParameter("@end_time", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.trace_name;
			parameters[2].Value = model.build_time;
			parameters[3].Value = model.end_time;
            String sql = strSql.ToString() ;
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
		public bool Update(WoeMobile.Model.traces model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update traces set ");
			strSql.Append("uid=@uid,");
			strSql.Append("trace_name=@trace_name,");
			strSql.Append("build_time=@build_time,");
			strSql.Append("end_time=@end_time");
			strSql.Append(" where idtraces=@idtraces");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@build_time", MySqlDbType.VarChar,45),
					new MySqlParameter("@end_time", MySqlDbType.VarChar,45),
					new MySqlParameter("@idtraces", MySqlDbType.Int32,11)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.trace_name;
			parameters[2].Value = model.build_time;
			parameters[3].Value = model.end_time;
			parameters[4].Value = model.idtraces;

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
		public bool Delete(int idtraces)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from traces ");
			strSql.Append(" where idtraces=@idtraces");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtraces", MySqlDbType.Int32)
			};
			parameters[0].Value = idtraces;

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
		public bool DeleteList(string idtraceslist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from traces ");
			strSql.Append(" where idtraces in ("+idtraceslist + ")  ");
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
		public WoeMobile.Model.traces GetModel(int idtraces)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idtraces,uid,trace_name,build_time,end_time from traces ");
			strSql.Append(" where idtraces=@idtraces");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtraces", MySqlDbType.Int32)
			};
			parameters[0].Value = idtraces;

			WoeMobile.Model.traces model=new WoeMobile.Model.traces();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idtraces"]!=null && ds.Tables[0].Rows[0]["idtraces"].ToString()!="")
				{
					model.idtraces=int.Parse(ds.Tables[0].Rows[0]["idtraces"].ToString());
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["trace_name"]!=null && ds.Tables[0].Rows[0]["trace_name"].ToString()!="")
				{
					model.trace_name=ds.Tables[0].Rows[0]["trace_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["build_time"]!=null && ds.Tables[0].Rows[0]["build_time"].ToString()!="")
				{
					model.build_time=ds.Tables[0].Rows[0]["build_time"].ToString();
				}
				if(ds.Tables[0].Rows[0]["end_time"]!=null && ds.Tables[0].Rows[0]["end_time"].ToString()!="")
				{
					model.end_time=ds.Tables[0].Rows[0]["end_time"].ToString();
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
			strSql.Append("select idtraces,uid,trace_name,build_time,end_time ");
			strSql.Append(" FROM traces ");
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
			strSql.Append("select count(1) FROM traces ");
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
				strSql.Append("order by T.idtraces desc");
			}
			strSql.Append(")AS Row, T.*  from traces T ");
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
			parameters[0].Value = "traces";
			parameters[1].Value = "idtraces";
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

