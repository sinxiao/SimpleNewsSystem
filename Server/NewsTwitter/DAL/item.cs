using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:item
	/// </summary>
	public partial class item
	{
		public item()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("iditem", "item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int iditem)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from item");
			strSql.Append(" where iditem=@iditem");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iditem", MySqlDbType.Int32)
			};
			parameters[0].Value = iditem;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into item(");
			strSql.Append("name,ename,showathome,item_parent)");
			strSql.Append(" values (");
			strSql.Append("@name,@ename,@showathome,@item_parent)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,450),
					new MySqlParameter("@ename", MySqlDbType.VarChar,45),
					new MySqlParameter("@showathome", MySqlDbType.Int32,11),
					new MySqlParameter("@item_parent", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.showathome;
			parameters[3].Value = model.item_parent;

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
		public bool Update(WoeMobile.Model.item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update item set ");
			strSql.Append("name=@name,");
			strSql.Append("ename=@ename,");
			strSql.Append("showathome=@showathome,");
			strSql.Append("item_parent=@item_parent");
			strSql.Append(" where iditem=@iditem");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,450),
					new MySqlParameter("@ename", MySqlDbType.VarChar,45),
					new MySqlParameter("@showathome", MySqlDbType.Int32,11),
					new MySqlParameter("@item_parent", MySqlDbType.Int32,11),
					new MySqlParameter("@iditem", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.ename;
			parameters[2].Value = model.showathome;
			parameters[3].Value = model.item_parent;
			parameters[4].Value = model.iditem;

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
		public bool Delete(int iditem)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from item ");
			strSql.Append(" where iditem=@iditem");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iditem", MySqlDbType.Int32)
			};
			parameters[0].Value = iditem;

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
		public bool DeleteList(string iditemlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from item ");
			strSql.Append(" where iditem in ("+iditemlist + ")  ");
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
		public WoeMobile.Model.item GetModel(int iditem)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select iditem,name,ename,showathome,item_parent from item ");
			strSql.Append(" where iditem=@iditem");
			MySqlParameter[] parameters = {
					new MySqlParameter("@iditem", MySqlDbType.Int32)
			};
			parameters[0].Value = iditem;

			WoeMobile.Model.item model=new WoeMobile.Model.item();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["iditem"]!=null && ds.Tables[0].Rows[0]["iditem"].ToString()!="")
				{
					model.iditem=int.Parse(ds.Tables[0].Rows[0]["iditem"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ename"]!=null && ds.Tables[0].Rows[0]["ename"].ToString()!="")
				{
					model.ename=ds.Tables[0].Rows[0]["ename"].ToString();
				}
				if(ds.Tables[0].Rows[0]["showathome"]!=null && ds.Tables[0].Rows[0]["showathome"].ToString()!="")
				{
					model.showathome=int.Parse(ds.Tables[0].Rows[0]["showathome"].ToString());
				}
				if(ds.Tables[0].Rows[0]["item_parent"]!=null && ds.Tables[0].Rows[0]["item_parent"].ToString()!="")
				{
					model.item_parent=int.Parse(ds.Tables[0].Rows[0]["item_parent"].ToString());
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
			strSql.Append("select iditem,name,ename,showathome,item_parent ");
			strSql.Append(" FROM item ");
            if (strWhere!=null&&strWhere.Trim() != "")
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
			strSql.Append("select count(1) FROM item ");
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
				strSql.Append("order by T.iditem desc");
			}
			strSql.Append(")AS Row, T.*  from item T ");
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
			parameters[0].Value = "item";
			parameters[1].Value = "iditem";
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

