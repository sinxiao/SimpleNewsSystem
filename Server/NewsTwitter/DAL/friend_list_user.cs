using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:friend_list_user
	/// </summary>
	public partial class friend_list_user
	{
		public friend_list_user()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idfriend_list_user", "friend_list_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idfriend_list_user)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from friend_list_user");
			strSql.Append(" where idfriend_list_user=@idfriend_list_user");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list_user", MySqlDbType.Int32)
			};
			parameters[0].Value = idfriend_list_user;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.friend_list_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into friend_list_user(");
			strSql.Append("group_id,uid,back_name,friend_list_id)");
			strSql.Append(" values (");
			strSql.Append("@group_id,@uid,@back_name,@friend_list_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@group_id", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@back_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@friend_list_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.back_name;
			parameters[3].Value = model.friend_list_id;

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
		public bool Update(WoeMobile.Model.friend_list_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update friend_list_user set ");
			strSql.Append("group_id=@group_id,");
			strSql.Append("uid=@uid,");
			strSql.Append("back_name=@back_name,");
			strSql.Append("friend_list_id=@friend_list_id");
			strSql.Append(" where idfriend_list_user=@idfriend_list_user");
			MySqlParameter[] parameters = {
					new MySqlParameter("@group_id", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@back_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@friend_list_id", MySqlDbType.Int32,11),
					new MySqlParameter("@idfriend_list_user", MySqlDbType.Int32,11)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.back_name;
			parameters[3].Value = model.friend_list_id;
			parameters[4].Value = model.idfriend_list_user;

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
		public bool Delete(int idfriend_list_user)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend_list_user ");
			strSql.Append(" where idfriend_list_user=@idfriend_list_user");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list_user", MySqlDbType.Int32)
			};
			parameters[0].Value = idfriend_list_user;

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
		public bool DeleteList(string idfriend_list_userlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from friend_list_user ");
			strSql.Append(" where idfriend_list_user in ("+idfriend_list_userlist + ")  ");
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
		public WoeMobile.Model.friend_list_user GetModel(int idfriend_list_user)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idfriend_list_user,group_id,uid,back_name,friend_list_id from friend_list_user ");
			strSql.Append(" where idfriend_list_user=@idfriend_list_user");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idfriend_list_user", MySqlDbType.Int32)
			};
			parameters[0].Value = idfriend_list_user;

			WoeMobile.Model.friend_list_user model=new WoeMobile.Model.friend_list_user();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idfriend_list_user"]!=null && ds.Tables[0].Rows[0]["idfriend_list_user"].ToString()!="")
				{
					model.idfriend_list_user=int.Parse(ds.Tables[0].Rows[0]["idfriend_list_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["group_id"]!=null && ds.Tables[0].Rows[0]["group_id"].ToString()!="")
				{
					model.group_id=int.Parse(ds.Tables[0].Rows[0]["group_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["back_name"]!=null && ds.Tables[0].Rows[0]["back_name"].ToString()!="")
				{
					model.back_name=ds.Tables[0].Rows[0]["back_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["friend_list_id"]!=null && ds.Tables[0].Rows[0]["friend_list_id"].ToString()!="")
				{
					model.friend_list_id=int.Parse(ds.Tables[0].Rows[0]["friend_list_id"].ToString());
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
			strSql.Append("select idfriend_list_user,group_id,uid,back_name,friend_list_id ");
			strSql.Append(" FROM friend_list_user ");
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
			strSql.Append("select count(1) FROM friend_list_user ");
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
				strSql.Append("order by T.idfriend_list_user desc");
			}
			strSql.Append(")AS Row, T.*  from friend_list_user T ");
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
			parameters[0].Value = "friend_list_user";
			parameters[1].Value = "idfriend_list_user";
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

