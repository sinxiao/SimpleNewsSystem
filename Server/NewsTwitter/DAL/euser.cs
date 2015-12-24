using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:euser
	/// </summary>
	public partial class euser
	{
		public euser()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("uid", "euser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from euser");
			strSql.Append(" where uid=@uid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.Int32)
			};
			parameters[0].Value = uid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.euser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into euser(");
			strSql.Append("in_email,in_pwd,nick_name)");
			strSql.Append(" values (");
			strSql.Append("@in_email,@in_pwd,@nick_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@in_email", MySqlDbType.VarChar,45),
					new MySqlParameter("@in_pwd", MySqlDbType.VarChar,45),
					new MySqlParameter("@nick_name", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.in_email;
			parameters[1].Value = model.in_pwd;
			parameters[2].Value = model.nick_name;

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
		public bool Update(WoeMobile.Model.euser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update euser set ");
			strSql.Append("in_email=@in_email,");
			strSql.Append("in_pwd=@in_pwd,");
			strSql.Append("nick_name=@nick_name");
			strSql.Append(" where uid=@uid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@in_email", MySqlDbType.VarChar,45),
					new MySqlParameter("@in_pwd", MySqlDbType.VarChar,45),
					new MySqlParameter("@nick_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@uid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.in_email;
			parameters[1].Value = model.in_pwd;
			parameters[2].Value = model.nick_name;
			parameters[3].Value = model.uid;

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
		public bool Delete(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from euser ");
			strSql.Append(" where uid=@uid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.Int32)
			};
			parameters[0].Value = uid;

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
		public bool DeleteList(string uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from euser ");
			strSql.Append(" where uid in ("+uidlist + ")  ");
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
		public WoeMobile.Model.euser GetModel(int uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uid,in_email,in_pwd,nick_name from euser ");
			strSql.Append(" where uid=@uid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.Int32)
			};
			parameters[0].Value = uid;

			WoeMobile.Model.euser model=new WoeMobile.Model.euser();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["in_email"]!=null && ds.Tables[0].Rows[0]["in_email"].ToString()!="")
				{
					model.in_email=ds.Tables[0].Rows[0]["in_email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["in_pwd"]!=null && ds.Tables[0].Rows[0]["in_pwd"].ToString()!="")
				{
					model.in_pwd=ds.Tables[0].Rows[0]["in_pwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nick_name"]!=null && ds.Tables[0].Rows[0]["nick_name"].ToString()!="")
				{
					model.nick_name=ds.Tables[0].Rows[0]["nick_name"].ToString();
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
			strSql.Append("select uid,in_email,in_pwd,nick_name ");
			strSql.Append(" FROM euser ");
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
			strSql.Append("select count(1) FROM euser ");
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
				strSql.Append("order by T.uid desc");
			}
			strSql.Append(")AS Row, T.*  from euser T ");
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
			parameters[0].Value = "euser";
			parameters[1].Value = "uid";
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

