using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:rights
	/// </summary>
	public partial class rights
	{
		public rights()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idRights", "rights"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idRights)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from rights");
			strSql.Append(" where idRights=@idRights");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRights", MySqlDbType.Int32)
			};
			parameters[0].Value = idRights;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.rights model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into rights(");
			strSql.Append("parent_r_id,name,url)");
			strSql.Append(" values (");
			strSql.Append("@parent_r_id,@name,@url)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_r_id", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@url", MySqlDbType.VarChar,450)};
			parameters[0].Value = model.parent_r_id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.url;

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
		public bool Update(WoeMobile.Model.rights model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update rights set ");
			strSql.Append("parent_r_id=@parent_r_id,");
			strSql.Append("name=@name,");
			strSql.Append("url=@url");
			strSql.Append(" where idRights=@idRights");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_r_id", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@url", MySqlDbType.VarChar,450),
					new MySqlParameter("@idRights", MySqlDbType.Int32,11)};
			parameters[0].Value = model.parent_r_id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.url;
			parameters[3].Value = model.idRights;

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
		public bool Delete(int idRights)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from rights ");
			strSql.Append(" where idRights=@idRights");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRights", MySqlDbType.Int32)
			};
			parameters[0].Value = idRights;

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
		public bool DeleteList(string idRightslist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from rights ");
			strSql.Append(" where idRights in ("+idRightslist + ")  ");
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
		public WoeMobile.Model.rights GetModel(int idRights)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idRights,parent_r_id,name,url from rights ");
			strSql.Append(" where idRights=@idRights");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idRights", MySqlDbType.Int32)
			};
			parameters[0].Value = idRights;

			WoeMobile.Model.rights model=new WoeMobile.Model.rights();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idRights"]!=null && ds.Tables[0].Rows[0]["idRights"].ToString()!="")
				{
					model.idRights=int.Parse(ds.Tables[0].Rows[0]["idRights"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parent_r_id"]!=null && ds.Tables[0].Rows[0]["parent_r_id"].ToString()!="")
				{
					model.parent_r_id=int.Parse(ds.Tables[0].Rows[0]["parent_r_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["url"]!=null && ds.Tables[0].Rows[0]["url"].ToString()!="")
				{
					model.url=ds.Tables[0].Rows[0]["url"].ToString();
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
			strSql.Append("select idRights,parent_r_id,name,url ");
			strSql.Append(" FROM rights ");
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
			strSql.Append("select count(1) FROM rights ");
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
				strSql.Append("order by T.idRights desc");
			}
			strSql.Append(")AS Row, T.*  from rights T ");
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
			parameters[0].Value = "rights";
			parameters[1].Value = "idRights";
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

