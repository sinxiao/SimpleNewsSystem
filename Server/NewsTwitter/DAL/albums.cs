using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:albums
	/// </summary>
	public partial class albums
	{
		public albums()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("album_id", "albums"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int album_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from albums");
			strSql.Append(" where album_id=@album_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@album_id", MySqlDbType.Int32)
			};
			parameters[0].Value = album_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.albums model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into albums(");
			strSql.Append("name_eg,name_ch,artist_id,pub_date)");
			strSql.Append(" values (");
			strSql.Append("@name_eg,@name_ch,@artist_id,@pub_date)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name_eg", MySqlDbType.VarChar,45),
					new MySqlParameter("@name_ch", MySqlDbType.VarChar,45),
					new MySqlParameter("@artist_id", MySqlDbType.Int32,11),
					new MySqlParameter("@pub_date", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.name_eg;
			parameters[1].Value = model.name_ch;
			parameters[2].Value = model.artist_id;
			parameters[3].Value = model.pub_date;

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
		public bool Update(WoeMobile.Model.albums model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update albums set ");
			strSql.Append("name_eg=@name_eg,");
			strSql.Append("name_ch=@name_ch,");
			strSql.Append("artist_id=@artist_id,");
			strSql.Append("pub_date=@pub_date");
			strSql.Append(" where album_id=@album_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name_eg", MySqlDbType.VarChar,45),
					new MySqlParameter("@name_ch", MySqlDbType.VarChar,45),
					new MySqlParameter("@artist_id", MySqlDbType.Int32,11),
					new MySqlParameter("@pub_date", MySqlDbType.VarChar,45),
					new MySqlParameter("@album_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name_eg;
			parameters[1].Value = model.name_ch;
			parameters[2].Value = model.artist_id;
			parameters[3].Value = model.pub_date;
			parameters[4].Value = model.album_id;

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
		public bool Delete(int album_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from albums ");
			strSql.Append(" where album_id=@album_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@album_id", MySqlDbType.Int32)
			};
			parameters[0].Value = album_id;

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
		public bool DeleteList(string album_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from albums ");
			strSql.Append(" where album_id in ("+album_idlist + ")  ");
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
		public WoeMobile.Model.albums GetModel(int album_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select album_id,name_eg,name_ch,artist_id,pub_date from albums ");
			strSql.Append(" where album_id=@album_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@album_id", MySqlDbType.Int32)
			};
			parameters[0].Value = album_id;

			WoeMobile.Model.albums model=new WoeMobile.Model.albums();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["album_id"]!=null && ds.Tables[0].Rows[0]["album_id"].ToString()!="")
				{
					model.album_id=int.Parse(ds.Tables[0].Rows[0]["album_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name_eg"]!=null && ds.Tables[0].Rows[0]["name_eg"].ToString()!="")
				{
					model.name_eg=ds.Tables[0].Rows[0]["name_eg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["name_ch"]!=null && ds.Tables[0].Rows[0]["name_ch"].ToString()!="")
				{
					model.name_ch=ds.Tables[0].Rows[0]["name_ch"].ToString();
				}
				if(ds.Tables[0].Rows[0]["artist_id"]!=null && ds.Tables[0].Rows[0]["artist_id"].ToString()!="")
				{
					model.artist_id=int.Parse(ds.Tables[0].Rows[0]["artist_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pub_date"]!=null && ds.Tables[0].Rows[0]["pub_date"].ToString()!="")
				{
					model.pub_date=ds.Tables[0].Rows[0]["pub_date"].ToString();
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
			strSql.Append("select album_id,name_eg,name_ch,artist_id,pub_date ");
			strSql.Append(" FROM albums ");
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
			strSql.Append("select count(1) FROM albums ");
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
				strSql.Append("order by T.album_id desc");
			}
			strSql.Append(")AS Row, T.*  from albums T ");
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
			parameters[0].Value = "albums";
			parameters[1].Value = "album_id";
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

