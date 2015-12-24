using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:musics
	/// </summary>
	public partial class musics
	{
		public musics()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("music_id", "musics"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int music_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from musics");
			strSql.Append(" where music_id=@music_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.musics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into musics(");
			strSql.Append("music_name,abum_id,duration,src,lrc_src)");
			strSql.Append(" values (");
			strSql.Append("@music_name,@abum_id,@duration,@src,@lrc_src)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@abum_id", MySqlDbType.Int32,11),
					new MySqlParameter("@duration", MySqlDbType.VarChar,45),
					new MySqlParameter("@src", MySqlDbType.VarChar,200),
					new MySqlParameter("@lrc_src", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.music_name;
			parameters[1].Value = model.abum_id;
			parameters[2].Value = model.duration;
			parameters[3].Value = model.src;
			parameters[4].Value = model.lrc_src;

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
		public bool Update(WoeMobile.Model.musics model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update musics set ");
			strSql.Append("music_name=@music_name,");
			strSql.Append("abum_id=@abum_id,");
			strSql.Append("duration=@duration,");
			strSql.Append("src=@src,");
			strSql.Append("lrc_src=@lrc_src");
			strSql.Append(" where music_id=@music_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@abum_id", MySqlDbType.Int32,11),
					new MySqlParameter("@duration", MySqlDbType.VarChar,45),
					new MySqlParameter("@src", MySqlDbType.VarChar,200),
					new MySqlParameter("@lrc_src", MySqlDbType.VarChar,200),
					new MySqlParameter("@music_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.music_name;
			parameters[1].Value = model.abum_id;
			parameters[2].Value = model.duration;
			parameters[3].Value = model.src;
			parameters[4].Value = model.lrc_src;
			parameters[5].Value = model.music_id;

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
		public bool Delete(int music_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from musics ");
			strSql.Append(" where music_id=@music_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_id;

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
		public bool DeleteList(string music_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from musics ");
			strSql.Append(" where music_id in ("+music_idlist + ")  ");
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
		public WoeMobile.Model.musics GetModel(int music_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select music_id,music_name,abum_id,duration,src,lrc_src from musics ");
			strSql.Append(" where music_id=@music_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@music_id", MySqlDbType.Int32)
			};
			parameters[0].Value = music_id;

			WoeMobile.Model.musics model=new WoeMobile.Model.musics();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["music_id"]!=null && ds.Tables[0].Rows[0]["music_id"].ToString()!="")
				{
					model.music_id=int.Parse(ds.Tables[0].Rows[0]["music_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["music_name"]!=null && ds.Tables[0].Rows[0]["music_name"].ToString()!="")
				{
					model.music_name=ds.Tables[0].Rows[0]["music_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["abum_id"]!=null && ds.Tables[0].Rows[0]["abum_id"].ToString()!="")
				{
					model.abum_id=int.Parse(ds.Tables[0].Rows[0]["abum_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["duration"]!=null && ds.Tables[0].Rows[0]["duration"].ToString()!="")
				{
					model.duration=ds.Tables[0].Rows[0]["duration"].ToString();
				}
				if(ds.Tables[0].Rows[0]["src"]!=null && ds.Tables[0].Rows[0]["src"].ToString()!="")
				{
					model.src=ds.Tables[0].Rows[0]["src"].ToString();
				}
				if(ds.Tables[0].Rows[0]["lrc_src"]!=null && ds.Tables[0].Rows[0]["lrc_src"].ToString()!="")
				{
					model.lrc_src=ds.Tables[0].Rows[0]["lrc_src"].ToString();
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
			strSql.Append("select music_id,music_name,abum_id,duration,src,lrc_src ");
			strSql.Append(" FROM musics ");
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
			strSql.Append("select count(1) FROM musics ");
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
				strSql.Append("order by T.music_id desc");
			}
			strSql.Append(")AS Row, T.*  from musics T ");
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
			parameters[0].Value = "musics";
			parameters[1].Value = "music_id";
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

