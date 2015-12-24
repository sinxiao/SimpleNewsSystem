using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:rolerightreltion
	/// </summary>
	public partial class rolerightreltion
	{
		public rolerightreltion()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idRoleRightReltion", "rolerightreltion"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idRoleRightReltion)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from rolerightreltion");
			strSql.Append(" where idRoleRightReltion=@idRoleRightReltion ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRoleRightReltion", MySqlDbType.Int32,11)			};
			parameters[0].Value = idRoleRightReltion;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.rolerightreltion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into rolerightreltion(");
			strSql.Append("idRoleRightReltion,role_id,right_id,right_type)");
			strSql.Append(" values (");
			strSql.Append("@idRoleRightReltion,@role_id,@right_id,@right_type)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRoleRightReltion", MySqlDbType.Int32,11),
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@right_id", MySqlDbType.Int32,11),
					new MySqlParameter("@right_type", MySqlDbType.Int32,11)};
			parameters[0].Value = model.idRoleRightReltion;
			parameters[1].Value = model.role_id;
			parameters[2].Value = model.right_id;
			parameters[3].Value = model.right_type;

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
		public bool Update(WoeMobile.Model.rolerightreltion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update rolerightreltion set ");
			strSql.Append("role_id=@role_id,");
			strSql.Append("right_id=@right_id,");
			strSql.Append("right_type=@right_type");
			strSql.Append(" where idRoleRightReltion=@idRoleRightReltion ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@right_id", MySqlDbType.Int32,11),
					new MySqlParameter("@right_type", MySqlDbType.Int32,11),
					new MySqlParameter("@idRoleRightReltion", MySqlDbType.Int32,11)};
			parameters[0].Value = model.role_id;
			parameters[1].Value = model.right_id;
			parameters[2].Value = model.right_type;
			parameters[3].Value = model.idRoleRightReltion;

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
		public bool Delete(int idRoleRightReltion)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from rolerightreltion ");
			strSql.Append(" where idRoleRightReltion=@idRoleRightReltion ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRoleRightReltion", MySqlDbType.Int32,11)			};
			parameters[0].Value = idRoleRightReltion;

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
		public bool DeleteList(string idRoleRightReltionlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from rolerightreltion ");
			strSql.Append(" where idRoleRightReltion in ("+idRoleRightReltionlist + ")  ");
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
		public WoeMobile.Model.rolerightreltion GetModel(int idRoleRightReltion)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idRoleRightReltion,role_id,right_id,right_type from rolerightreltion ");
			strSql.Append(" where idRoleRightReltion=@idRoleRightReltion ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRoleRightReltion", MySqlDbType.Int32,11)			};
			parameters[0].Value = idRoleRightReltion;

			WoeMobile.Model.rolerightreltion model=new WoeMobile.Model.rolerightreltion();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idRoleRightReltion"]!=null && ds.Tables[0].Rows[0]["idRoleRightReltion"].ToString()!="")
				{
					model.idRoleRightReltion=int.Parse(ds.Tables[0].Rows[0]["idRoleRightReltion"].ToString());
				}
				if(ds.Tables[0].Rows[0]["role_id"]!=null && ds.Tables[0].Rows[0]["role_id"].ToString()!="")
				{
					model.role_id=int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["right_id"]!=null && ds.Tables[0].Rows[0]["right_id"].ToString()!="")
				{
					model.right_id=int.Parse(ds.Tables[0].Rows[0]["right_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["right_type"]!=null && ds.Tables[0].Rows[0]["right_type"].ToString()!="")
				{
					model.right_type=int.Parse(ds.Tables[0].Rows[0]["right_type"].ToString());
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
			strSql.Append("select idRoleRightReltion,role_id,right_id,right_type ");
			strSql.Append(" FROM rolerightreltion ");
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
			strSql.Append("select count(1) FROM rolerightreltion ");
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
				strSql.Append("order by T.idRoleRightReltion desc");
			}
			strSql.Append(")AS Row, T.*  from rolerightreltion T ");
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
			parameters[0].Value = "rolerightreltion";
			parameters[1].Value = "idRoleRightReltion";
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

