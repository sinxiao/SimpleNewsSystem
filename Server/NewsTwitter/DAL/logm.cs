using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:logm
	/// </summary>
	public partial class logm
	{
		public logm()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idLogM", "logm"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idLogM)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from logm");
			strSql.Append(" where idLogM=@idLogM");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idLogM", MySqlDbType.Int32)
			};
			parameters[0].Value = idLogM;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.logm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into logm(");
			strSql.Append("op_type,content,manger_id,gen_time)");
			strSql.Append(" values (");
			strSql.Append("@op_type,@content,@manger_id,@gen_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@op_type", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.VarChar,450),
					new MySqlParameter("@manger_id", MySqlDbType.Int32,11),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp)};
			parameters[0].Value = model.op_type;
			parameters[1].Value = model.content;
			parameters[2].Value = model.manger_id;
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
		public bool Update(WoeMobile.Model.logm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update logm set ");
			strSql.Append("op_type=@op_type,");
			strSql.Append("content=@content,");
			strSql.Append("manger_id=@manger_id");
			strSql.Append(" where idLogM=@idLogM");
			MySqlParameter[] parameters = {
					new MySqlParameter("@op_type", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.VarChar,450),
					new MySqlParameter("@manger_id", MySqlDbType.Int32,11),
					new MySqlParameter("@idLogM", MySqlDbType.Int32,11)};
			parameters[0].Value = model.op_type;
			parameters[1].Value = model.content;
			parameters[2].Value = model.manger_id;
			parameters[3].Value = model.idLogM;

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
		public bool Delete(int idLogM)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from logm ");
			strSql.Append(" where idLogM=@idLogM");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idLogM", MySqlDbType.Int32)
			};
			parameters[0].Value = idLogM;

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
		public bool DeleteList(string idLogMlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from logm ");
			strSql.Append(" where idLogM in ("+idLogMlist + ")  ");
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
		public WoeMobile.Model.logm GetModel(int idLogM)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idLogM,op_type,content,manger_id,gen_time from logm ");
			strSql.Append(" where idLogM=@idLogM");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idLogM", MySqlDbType.Int32)
			};
			parameters[0].Value = idLogM;

			WoeMobile.Model.logm model=new WoeMobile.Model.logm();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idLogM"]!=null && ds.Tables[0].Rows[0]["idLogM"].ToString()!="")
				{
					model.idLogM=int.Parse(ds.Tables[0].Rows[0]["idLogM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["op_type"]!=null && ds.Tables[0].Rows[0]["op_type"].ToString()!="")
				{
					model.op_type=int.Parse(ds.Tables[0].Rows[0]["op_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["manger_id"]!=null && ds.Tables[0].Rows[0]["manger_id"].ToString()!="")
				{
					model.manger_id=int.Parse(ds.Tables[0].Rows[0]["manger_id"].ToString());
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
			strSql.Append("select idLogM,op_type,content,manger_id,gen_time ");
			strSql.Append(" FROM logm ");
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
			strSql.Append("select count(1) FROM logm ");
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
				strSql.Append("order by T.idLogM desc");
			}
			strSql.Append(")AS Row, T.*  from logm T ");
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
			parameters[0].Value = "logm";
			parameters[1].Value = "idLogM";
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

