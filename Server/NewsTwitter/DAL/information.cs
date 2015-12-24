using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:information
	/// </summary>
	public partial class information
	{
		public information()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idinformation", "information"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idinformation)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from information");
			strSql.Append(" where idinformation=@idinformation");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idinformation", MySqlDbType.Int32)
			};
			parameters[0].Value = idinformation;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.information model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into information(");
			strSql.Append("from_id,to_id,content,readed,gen_time,infor_type,manager_id)");
			strSql.Append(" values (");
			strSql.Append("@from_id,@to_id,@content,@readed,@gen_time,@infor_type,@manager_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@from_id", MySqlDbType.Int32,11),
					new MySqlParameter("@to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@readed", MySqlDbType.Int32,11),
					new MySqlParameter("@gen_time", MySqlDbType.Timestamp),
					new MySqlParameter("@infor_type", MySqlDbType.Int32,11),
					new MySqlParameter("@manager_id", MySqlDbType.Int32,11)};
            
            parameters[0].Value = model.from_id == 0 ? null : model.from_id;
            if (model.to_id != 0)
            {
                parameters[1].Value = model.to_id;
            }
            else {
                parameters[1].Value = null;
            }
            
			parameters[2].Value = model.content;
			parameters[3].Value = model.readed;
			parameters[4].Value = model.gen_time.ToString();
			parameters[5].Value = model.infor_type;
			parameters[6].Value = model.manager_id;

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
		public bool Update(WoeMobile.Model.information model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update information set ");
			strSql.Append("from_id=@from_id,");
			strSql.Append("to_id=@to_id,");
			strSql.Append("content=@content,");
			strSql.Append("readed=@readed,");
			strSql.Append("infor_type=@infor_type,");
			strSql.Append("manager_id=@manager_id");
			strSql.Append(" where idinformation=@idinformation");
			MySqlParameter[] parameters = {
					new MySqlParameter("@from_id", MySqlDbType.Int32,11),
					new MySqlParameter("@to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@readed", MySqlDbType.Int32,11),
					new MySqlParameter("@infor_type", MySqlDbType.Int32,11),
					new MySqlParameter("@manager_id", MySqlDbType.Int32,11),
					new MySqlParameter("@idinformation", MySqlDbType.Int32,11)};
			parameters[0].Value = model.from_id;
			parameters[1].Value = model.to_id;
			parameters[2].Value = model.content;
			parameters[3].Value = model.readed;
			parameters[4].Value = model.infor_type;
			parameters[5].Value = model.manager_id;
			parameters[6].Value = model.idinformation;

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
		public bool Delete(int idinformation)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from information ");
			strSql.Append(" where idinformation=@idinformation");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idinformation", MySqlDbType.Int32)
			};
			parameters[0].Value = idinformation;

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
		public bool DeleteList(string idinformationlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from information ");
			strSql.Append(" where idinformation in ("+idinformationlist + ")  ");
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
		public WoeMobile.Model.information GetModel(int idinformation)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idinformation,from_id,to_id,content,readed,gen_time,infor_type,manager_id from information ");
			strSql.Append(" where idinformation=@idinformation");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idinformation", MySqlDbType.Int32)
			};
			parameters[0].Value = idinformation;

			WoeMobile.Model.information model=new WoeMobile.Model.information();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idinformation"]!=null && ds.Tables[0].Rows[0]["idinformation"].ToString()!="")
				{
					model.idinformation=int.Parse(ds.Tables[0].Rows[0]["idinformation"].ToString());
				}
				if(ds.Tables[0].Rows[0]["from_id"]!=null && ds.Tables[0].Rows[0]["from_id"].ToString()!="")
				{
					model.from_id=int.Parse(ds.Tables[0].Rows[0]["from_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["to_id"]!=null && ds.Tables[0].Rows[0]["to_id"].ToString()!="")
				{
					model.to_id=int.Parse(ds.Tables[0].Rows[0]["to_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["readed"]!=null && ds.Tables[0].Rows[0]["readed"].ToString()!="")
				{
					model.readed=int.Parse(ds.Tables[0].Rows[0]["readed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gen_time"]!=null && ds.Tables[0].Rows[0]["gen_time"].ToString()!="")
				{
					model.gen_time=DateTime.Parse(ds.Tables[0].Rows[0]["gen_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["infor_type"]!=null && ds.Tables[0].Rows[0]["infor_type"].ToString()!="")
				{
					model.infor_type=int.Parse(ds.Tables[0].Rows[0]["infor_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["manager_id"]!=null && ds.Tables[0].Rows[0]["manager_id"].ToString()!="")
				{
					model.manager_id=int.Parse(ds.Tables[0].Rows[0]["manager_id"].ToString());
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
			strSql.Append("select idinformation,from_id,to_id,content,readed,gen_time,infor_type,manager_id ");
			strSql.Append(" FROM information ");
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
			strSql.Append("select count(1) FROM information ");
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
				strSql.Append("order by T.idinformation desc");
			}
			strSql.Append(")AS Row, T.*  from information T ");
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
			parameters[0].Value = "information";
			parameters[1].Value = "idinformation";
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

