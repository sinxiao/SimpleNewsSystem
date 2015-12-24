using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:role
	/// </summary>
	public partial class role
	{
		public role()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idRole", "role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idRole)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from role");
			strSql.Append(" where idRole=@idRole");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRole", MySqlDbType.Int32)
			};
			parameters[0].Value = idRole;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into role(");
			strSql.Append("rname,desription,parent_r_id,gen_time)");
			strSql.Append(" values (");
			strSql.Append("@rname,@desription,@parent_r_id,@gen_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@rname", MySqlDbType.VarChar,45),
					new MySqlParameter("@desription", MySqlDbType.Text),
					new MySqlParameter("@parent_r_id", MySqlDbType.VarChar,45),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.desription;
			parameters[2].Value = model.parent_r_id;
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
		public bool Update(WoeMobile.Model.role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update role set ");
			strSql.Append("rname=@rname,");
			strSql.Append("desription=@desription,");
			strSql.Append("parent_r_id=@parent_r_id");
			strSql.Append(" where idRole=@idRole");
			MySqlParameter[] parameters = {
					new MySqlParameter("@rname", MySqlDbType.VarChar,45),
					new MySqlParameter("@desription", MySqlDbType.Text),
					new MySqlParameter("@parent_r_id", MySqlDbType.VarChar,45),
					new MySqlParameter("@idRole", MySqlDbType.Int32,11)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.desription;
			parameters[2].Value = model.parent_r_id;
			parameters[3].Value = model.idRole;

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
		public bool Delete(int idRole)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from role ");
			strSql.Append(" where idRole=@idRole");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRole", MySqlDbType.Int32)
			};
			parameters[0].Value = idRole;

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
		public bool DeleteList(string idRolelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from role ");
			strSql.Append(" where idRole in ("+idRolelist + ")  ");
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
		public WoeMobile.Model.role GetModel(int idRole)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idRole,rname,desription,parent_r_id,gen_time from role ");
			strSql.Append(" where idRole=@idRole");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRole", MySqlDbType.Int32)
			};
			parameters[0].Value = idRole;

			WoeMobile.Model.role model=new WoeMobile.Model.role();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idRole"]!=null && ds.Tables[0].Rows[0]["idRole"].ToString()!="")
				{
					model.idRole=int.Parse(ds.Tables[0].Rows[0]["idRole"].ToString());
				}
				if(ds.Tables[0].Rows[0]["rname"]!=null && ds.Tables[0].Rows[0]["rname"].ToString()!="")
				{
					model.rname=ds.Tables[0].Rows[0]["rname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["desription"]!=null && ds.Tables[0].Rows[0]["desription"].ToString()!="")
				{
					model.desription=ds.Tables[0].Rows[0]["desription"].ToString();
				}
				if(ds.Tables[0].Rows[0]["parent_r_id"]!=null && ds.Tables[0].Rows[0]["parent_r_id"].ToString()!="")
				{
					model.parent_r_id=ds.Tables[0].Rows[0]["parent_r_id"].ToString();
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
			strSql.Append("select idRole,rname,desription,parent_r_id,gen_time ");
			strSql.Append(" FROM role ");
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
			strSql.Append("select count(1) FROM role ");
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
				strSql.Append("order by T.idRole desc");
			}
			strSql.Append(")AS Row, T.*  from role T ");
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
			parameters[0].Value = "role";
			parameters[1].Value = "idRole";
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

