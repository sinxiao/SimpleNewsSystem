using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:euser_detail
	/// </summary>
	public partial class euser_detail
	{
		public euser_detail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id_User_detail", "euser_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id_User_detail)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from euser_detail");
			strSql.Append(" where id_User_detail=@id_User_detail");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_User_detail", MySqlDbType.Int32)
			};
			parameters[0].Value = id_User_detail;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.euser_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into euser_detail(");
			strSql.Append("user_id,qq_no,imei,cell_phone_no,contact,location,gender)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@qq_no,@imei,@cell_phone_no,@contact,@location,@gender)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@qq_no", MySqlDbType.VarChar,12),
					new MySqlParameter("@imei", MySqlDbType.VarChar,45),
					new MySqlParameter("@cell_phone_no", MySqlDbType.VarChar,45),
					new MySqlParameter("@contact", MySqlDbType.Int32,11),
					new MySqlParameter("@location", MySqlDbType.Int32,11),
					new MySqlParameter("@gender", MySqlDbType.Int32,11)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.qq_no;
			parameters[2].Value = model.imei;
			parameters[3].Value = model.cell_phone_no;
			parameters[4].Value = model.contact;
			parameters[5].Value = model.location;
			parameters[6].Value = model.gender;

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
		public bool Update(WoeMobile.Model.euser_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update euser_detail set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("qq_no=@qq_no,");
			strSql.Append("imei=@imei,");
			strSql.Append("cell_phone_no=@cell_phone_no,");
			strSql.Append("contact=@contact,");
			strSql.Append("location=@location,");
			strSql.Append("gender=@gender");
			strSql.Append(" where id_User_detail=@id_User_detail");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@qq_no", MySqlDbType.VarChar,12),
					new MySqlParameter("@imei", MySqlDbType.VarChar,45),
					new MySqlParameter("@cell_phone_no", MySqlDbType.VarChar,45),
					new MySqlParameter("@contact", MySqlDbType.Int32,11),
					new MySqlParameter("@location", MySqlDbType.Int32,11),
					new MySqlParameter("@gender", MySqlDbType.Int32,11),
					new MySqlParameter("@id_User_detail", MySqlDbType.Int32,11)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.qq_no;
			parameters[2].Value = model.imei;
			parameters[3].Value = model.cell_phone_no;
			parameters[4].Value = model.contact;
			parameters[5].Value = model.location;
			parameters[6].Value = model.gender;
			parameters[7].Value = model.id_User_detail;

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
		public bool Delete(int id_User_detail)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from euser_detail ");
			strSql.Append(" where id_User_detail=@id_User_detail");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_User_detail", MySqlDbType.Int32)
			};
			parameters[0].Value = id_User_detail;

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
		public bool DeleteList(string id_User_detaillist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from euser_detail ");
			strSql.Append(" where id_User_detail in ("+id_User_detaillist + ")  ");
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
		public WoeMobile.Model.euser_detail GetModel(int id_User_detail)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id_User_detail,user_id,qq_no,imei,cell_phone_no,contact,location,gender from euser_detail ");
			strSql.Append(" where id_User_detail=@id_User_detail");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_User_detail", MySqlDbType.Int32)
			};
			parameters[0].Value = id_User_detail;

			WoeMobile.Model.euser_detail model=new WoeMobile.Model.euser_detail();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id_User_detail"]!=null && ds.Tables[0].Rows[0]["id_User_detail"].ToString()!="")
				{
					model.id_User_detail=int.Parse(ds.Tables[0].Rows[0]["id_User_detail"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"]!=null && ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qq_no"]!=null && ds.Tables[0].Rows[0]["qq_no"].ToString()!="")
				{
					model.qq_no=ds.Tables[0].Rows[0]["qq_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["imei"]!=null && ds.Tables[0].Rows[0]["imei"].ToString()!="")
				{
					model.imei=ds.Tables[0].Rows[0]["imei"].ToString();
				}
				if(ds.Tables[0].Rows[0]["cell_phone_no"]!=null && ds.Tables[0].Rows[0]["cell_phone_no"].ToString()!="")
				{
					model.cell_phone_no=ds.Tables[0].Rows[0]["cell_phone_no"].ToString();
				}
				if(ds.Tables[0].Rows[0]["contact"]!=null && ds.Tables[0].Rows[0]["contact"].ToString()!="")
				{
					model.contact=int.Parse(ds.Tables[0].Rows[0]["contact"].ToString());
				}
				if(ds.Tables[0].Rows[0]["location"]!=null && ds.Tables[0].Rows[0]["location"].ToString()!="")
				{
					model.location=int.Parse(ds.Tables[0].Rows[0]["location"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gender"]!=null && ds.Tables[0].Rows[0]["gender"].ToString()!="")
				{
					model.gender=int.Parse(ds.Tables[0].Rows[0]["gender"].ToString());
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
			strSql.Append("select id_User_detail,user_id,qq_no,imei,cell_phone_no,contact,location,gender ");
			strSql.Append(" FROM euser_detail ");
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
			strSql.Append("select count(1) FROM euser_detail ");
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
				strSql.Append("order by T.id_User_detail desc");
			}
			strSql.Append(")AS Row, T.*  from euser_detail T ");
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
			parameters[0].Value = "euser_detail";
			parameters[1].Value = "id_User_detail";
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

