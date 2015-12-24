using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:friend_list
	/// </summary>
	public partial class friend_list
	{
		public friend_list()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idfriend_list", "friend_list"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idfriend_list)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from friend_list");
			strSql.Append(" where idfriend_list=@idfriend_list ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list", MySqlDbType.Int32,11)			};
			parameters[0].Value = idfriend_list;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.friend_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into friend_list(");
			strSql.Append("idfriend_list,u_id,gen_time,friend_list_name)");
			strSql.Append(" values (");
			strSql.Append("@idfriend_list,@u_id,@gen_time,@friend_list_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list", MySqlDbType.Int32,11),
					new MySqlParameter("@u_id", MySqlDbType.Int32,11),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp),
					new MySqlParameter("@friend_list_name", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.idfriend_list;
			parameters[1].Value = model.u_id;
			parameters[2].Value = model.gen_time;
			parameters[3].Value = model.friend_list_name;

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
		public bool Update(WoeMobile.Model.friend_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update friend_list set ");
			strSql.Append("u_id=@u_id,");
			strSql.Append("friend_list_name=@friend_list_name");
			strSql.Append(" where idfriend_list=@idfriend_list ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@u_id", MySqlDbType.Int32,11),
					new MySqlParameter("@friend_list_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@idfriend_list", MySqlDbType.Int32,11)};
			parameters[0].Value = model.u_id;
			parameters[1].Value = model.friend_list_name;
			parameters[2].Value = model.idfriend_list;

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
		public bool Delete(int idfriend_list)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend_list ");
			strSql.Append(" where idfriend_list=@idfriend_list ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list", MySqlDbType.Int32,11)			};
			parameters[0].Value = idfriend_list;

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
		public bool DeleteList(string idfriend_listlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend_list ");
			strSql.Append(" where idfriend_list in ("+idfriend_listlist + ")  ");
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
		public WoeMobile.Model.friend_list GetModel(int idfriend_list)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idfriend_list,u_id,gen_time,friend_list_name from friend_list ");
			strSql.Append(" where idfriend_list=@idfriend_list ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list", MySqlDbType.Int32,11)			};
			parameters[0].Value = idfriend_list;

			WoeMobile.Model.friend_list model=new WoeMobile.Model.friend_list();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idfriend_list"]!=null && ds.Tables[0].Rows[0]["idfriend_list"].ToString()!="")
				{
					model.idfriend_list=int.Parse(ds.Tables[0].Rows[0]["idfriend_list"].ToString());
				}
				if(ds.Tables[0].Rows[0]["u_id"]!=null && ds.Tables[0].Rows[0]["u_id"].ToString()!="")
				{
					model.u_id=int.Parse(ds.Tables[0].Rows[0]["u_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gen_time"]!=null && ds.Tables[0].Rows[0]["gen_time"].ToString()!="")
				{
					model.gen_time=DateTime.Parse(ds.Tables[0].Rows[0]["gen_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["friend_list_name"]!=null && ds.Tables[0].Rows[0]["friend_list_name"].ToString()!="")
				{
					model.friend_list_name=ds.Tables[0].Rows[0]["friend_list_name"].ToString();
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
			strSql.Append("select idfriend_list,u_id,gen_time,friend_list_name ");
			strSql.Append(" FROM friend_list ");
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
			strSql.Append("select count(1) FROM friend_list ");
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
				strSql.Append("order by T.idfriend_list desc");
			}
			strSql.Append(")AS Row, T.*  from friend_list T ");
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
			parameters[0].Value = "friend_list";
			parameters[1].Value = "idfriend_list";
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

