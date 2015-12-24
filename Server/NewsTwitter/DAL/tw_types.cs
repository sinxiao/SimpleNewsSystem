using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:tw_types
	/// </summary>
	public partial class tw_types
	{
		public tw_types()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id_tw_types", "tw_types"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id_tw_types)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tw_types");
			strSql.Append(" where id_tw_types=@id_tw_types");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_tw_types", MySqlDbType.Int32)
			};
			parameters[0].Value = id_tw_types;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.tw_types model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tw_types(");
			strSql.Append("name)");
			strSql.Append(" values (");
			strSql.Append("@name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.name;

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
		public bool Update(WoeMobile.Model.tw_types model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tw_types set ");
			strSql.Append("name=@name");
			strSql.Append(" where id_tw_types=@id_tw_types");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@id_tw_types", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.id_tw_types;

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
		public bool Delete(int id_tw_types)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tw_types ");
			strSql.Append(" where id_tw_types=@id_tw_types");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_tw_types", MySqlDbType.Int32)
			};
			parameters[0].Value = id_tw_types;

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
		public bool DeleteList(string id_tw_typeslist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tw_types ");
			strSql.Append(" where id_tw_types in ("+id_tw_typeslist + ")  ");
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
		public WoeMobile.Model.tw_types GetModel(int id_tw_types)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id_tw_types,name from tw_types ");
			strSql.Append(" where id_tw_types=@id_tw_types");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_tw_types", MySqlDbType.Int32)
			};
			parameters[0].Value = id_tw_types;

			WoeMobile.Model.tw_types model=new WoeMobile.Model.tw_types();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id_tw_types"]!=null && ds.Tables[0].Rows[0]["id_tw_types"].ToString()!="")
				{
					model.id_tw_types=int.Parse(ds.Tables[0].Rows[0]["id_tw_types"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
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
			strSql.Append("select id_tw_types,name ");
			strSql.Append(" FROM tw_types ");
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
			strSql.Append("select count(1) FROM tw_types ");
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
				strSql.Append("order by T.id_tw_types desc");
			}
			strSql.Append(")AS Row, T.*  from tw_types T ");
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
			parameters[0].Value = "tw_types";
			parameters[1].Value = "id_tw_types";
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

