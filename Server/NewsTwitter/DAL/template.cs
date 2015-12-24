using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:template
	/// </summary>
	public partial class template
	{
		public template()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idtemplate", "template"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idtemplate)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from template");
			strSql.Append(" where idtemplate=@idtemplate");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtemplate", MySqlDbType.Int32)
			};
			parameters[0].Value = idtemplate;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.template model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into template(");
			strSql.Append("name,content)");
			strSql.Append(" values (");
			strSql.Append("@name,@content)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@content", MySqlDbType.Text)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.content;

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
		public bool Update(WoeMobile.Model.template model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update template set ");
			strSql.Append("name=@name,");
			strSql.Append("content=@content");
			strSql.Append(" where idtemplate=@idtemplate");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@idtemplate", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.content;
			parameters[2].Value = model.idtemplate;

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
		public bool Delete(int idtemplate)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from template ");
			strSql.Append(" where idtemplate=@idtemplate");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtemplate", MySqlDbType.Int32)
			};
			parameters[0].Value = idtemplate;

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
		public bool DeleteList(string idtemplatelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from template ");
			strSql.Append(" where idtemplate in ("+idtemplatelist + ")  ");
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
		public WoeMobile.Model.template GetModel(int idtemplate)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idtemplate,name,content from template ");
			strSql.Append(" where idtemplate=@idtemplate");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idtemplate", MySqlDbType.Int32)
			};
			parameters[0].Value = idtemplate;

			WoeMobile.Model.template model=new WoeMobile.Model.template();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idtemplate"]!=null && ds.Tables[0].Rows[0]["idtemplate"].ToString()!="")
				{
					model.idtemplate=int.Parse(ds.Tables[0].Rows[0]["idtemplate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
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
			strSql.Append("select idtemplate,name,content ");
			strSql.Append(" FROM template ");
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
			strSql.Append("select count(1) FROM template ");
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
				strSql.Append("order by T.idtemplate desc");
			}
			strSql.Append(")AS Row, T.*  from template T ");
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
			parameters[0].Value = "template";
			parameters[1].Value = "idtemplate";
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

