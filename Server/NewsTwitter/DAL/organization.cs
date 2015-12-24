using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:organization
	/// </summary>
	public partial class organization
	{
		public organization()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idOrganization", "organization"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idOrganization)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from organization");
			strSql.Append(" where idOrganization=@idOrganization");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idOrganization", MySqlDbType.Int32)
			};
			parameters[0].Value = idOrganization;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into organization(");
			strSql.Append("parent_to_id,org_name,org_gen,destription)");
			strSql.Append(" values (");
			strSql.Append("@parent_to_id,@org_name,@org_gen,@destription)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@org_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@org_gen", MySqlDbType.Timestamp),
					new MySqlParameter("@destription", MySqlDbType.Text)};
			parameters[0].Value = model.parent_to_id;
			parameters[1].Value = model.org_name;
			parameters[2].Value = model.org_gen;
			parameters[3].Value = model.destription;

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
		public bool Update(WoeMobile.Model.organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update organization set ");
			strSql.Append("parent_to_id=@parent_to_id,");
			strSql.Append("org_name=@org_name,");
			strSql.Append("destription=@destription");
			strSql.Append(" where idOrganization=@idOrganization");
			MySqlParameter[] parameters = {
					new MySqlParameter("@parent_to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@org_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@destription", MySqlDbType.Text),
					new MySqlParameter("@idOrganization", MySqlDbType.Int32,11)};
			parameters[0].Value = model.parent_to_id;
			parameters[1].Value = model.org_name;
			parameters[2].Value = model.destription;
			parameters[3].Value = model.idOrganization;

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
		public bool Delete(int idOrganization)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from organization ");
			strSql.Append(" where idOrganization=@idOrganization");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idOrganization", MySqlDbType.Int32)
			};
			parameters[0].Value = idOrganization;

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
		public bool DeleteList(string idOrganizationlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from organization ");
			strSql.Append(" where idOrganization in ("+idOrganizationlist + ")  ");
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
		public WoeMobile.Model.organization GetModel(int idOrganization)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idOrganization,parent_to_id,org_name,org_gen,destription from organization ");
			strSql.Append(" where idOrganization=@idOrganization");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idOrganization", MySqlDbType.Int32)
			};
			parameters[0].Value = idOrganization;

			WoeMobile.Model.organization model=new WoeMobile.Model.organization();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idOrganization"]!=null && ds.Tables[0].Rows[0]["idOrganization"].ToString()!="")
				{
					model.idOrganization=int.Parse(ds.Tables[0].Rows[0]["idOrganization"].ToString());
				}
				if(ds.Tables[0].Rows[0]["parent_to_id"]!=null && ds.Tables[0].Rows[0]["parent_to_id"].ToString()!="")
				{
					model.parent_to_id=int.Parse(ds.Tables[0].Rows[0]["parent_to_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["org_name"]!=null && ds.Tables[0].Rows[0]["org_name"].ToString()!="")
				{
					model.org_name=ds.Tables[0].Rows[0]["org_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["org_gen"]!=null && ds.Tables[0].Rows[0]["org_gen"].ToString()!="")
				{
					model.org_gen=DateTime.Parse(ds.Tables[0].Rows[0]["org_gen"].ToString());
				}
				if(ds.Tables[0].Rows[0]["destription"]!=null && ds.Tables[0].Rows[0]["destription"].ToString()!="")
				{
					model.destription=ds.Tables[0].Rows[0]["destription"].ToString();
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
			strSql.Append("select idOrganization,parent_to_id,org_name,org_gen,destription ");
			strSql.Append(" FROM organization ");
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
			strSql.Append("select count(1) FROM organization ");
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
				strSql.Append("order by T.idOrganization desc");
			}
			strSql.Append(")AS Row, T.*  from organization T ");
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
			parameters[0].Value = "organization";
			parameters[1].Value = "idOrganization";
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

