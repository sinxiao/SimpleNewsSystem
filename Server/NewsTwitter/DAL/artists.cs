using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:artists
	/// </summary>
	public partial class artists
	{
		public artists()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("artist_id", "artists"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int artist_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from artists");
			strSql.Append(" where artist_id=@artist_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@artist_id", MySqlDbType.Int32)
			};
			parameters[0].Value = artist_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.artists model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into artists(");
			strSql.Append("height,name,name_eg,weight,langrange,start,live_pet,blood_type,love_to_say,job,Company,best_hobby,worst_bobby,birth_date,best_wish,hobby,like_color,likedrink)");
			strSql.Append(" values (");
			strSql.Append("@height,@name,@name_eg,@weight,@langrange,@start,@live_pet,@blood_type,@love_to_say,@job,@Company,@best_hobby,@worst_bobby,@birth_date,@best_wish,@hobby,@like_color,@likedrink)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@height", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@name_eg", MySqlDbType.VarChar,45),
					new MySqlParameter("@weight", MySqlDbType.VarChar,45),
					new MySqlParameter("@langrange", MySqlDbType.VarChar,45),
					new MySqlParameter("@start", MySqlDbType.VarChar,45),
					new MySqlParameter("@live_pet", MySqlDbType.VarChar,45),
					new MySqlParameter("@blood_type", MySqlDbType.VarChar,45),
					new MySqlParameter("@love_to_say", MySqlDbType.VarChar,45),
					new MySqlParameter("@job", MySqlDbType.VarChar,45),
					new MySqlParameter("@Company", MySqlDbType.VarChar,45),
					new MySqlParameter("@best_hobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@worst_bobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@birth_date", MySqlDbType.VarChar,45),
					new MySqlParameter("@best_wish", MySqlDbType.VarChar,45),
					new MySqlParameter("@hobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@like_color", MySqlDbType.VarChar,45),
					new MySqlParameter("@likedrink", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.height;
			parameters[1].Value = model.name;
			parameters[2].Value = model.name_eg;
			parameters[3].Value = model.weight;
			parameters[4].Value = model.langrange;
			parameters[5].Value = model.start;
			parameters[6].Value = model.live_pet;
			parameters[7].Value = model.blood_type;
			parameters[8].Value = model.love_to_say;
			parameters[9].Value = model.job;
			parameters[10].Value = model.Company;
			parameters[11].Value = model.best_hobby;
			parameters[12].Value = model.worst_bobby;
			parameters[13].Value = model.birth_date;
			parameters[14].Value = model.best_wish;
			parameters[15].Value = model.hobby;
			parameters[16].Value = model.like_color;
			parameters[17].Value = model.likedrink;

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
		public bool Update(WoeMobile.Model.artists model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update artists set ");
			strSql.Append("height=@height,");
			strSql.Append("name=@name,");
			strSql.Append("name_eg=@name_eg,");
			strSql.Append("weight=@weight,");
			strSql.Append("langrange=@langrange,");
			strSql.Append("start=@start,");
			strSql.Append("live_pet=@live_pet,");
			strSql.Append("blood_type=@blood_type,");
			strSql.Append("love_to_say=@love_to_say,");
			strSql.Append("job=@job,");
			strSql.Append("Company=@Company,");
			strSql.Append("best_hobby=@best_hobby,");
			strSql.Append("worst_bobby=@worst_bobby,");
			strSql.Append("birth_date=@birth_date,");
			strSql.Append("best_wish=@best_wish,");
			strSql.Append("hobby=@hobby,");
			strSql.Append("like_color=@like_color,");
			strSql.Append("likedrink=@likedrink");
			strSql.Append(" where artist_id=@artist_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@height", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@name_eg", MySqlDbType.VarChar,45),
					new MySqlParameter("@weight", MySqlDbType.VarChar,45),
					new MySqlParameter("@langrange", MySqlDbType.VarChar,45),
					new MySqlParameter("@start", MySqlDbType.VarChar,45),
					new MySqlParameter("@live_pet", MySqlDbType.VarChar,45),
					new MySqlParameter("@blood_type", MySqlDbType.VarChar,45),
					new MySqlParameter("@love_to_say", MySqlDbType.VarChar,45),
					new MySqlParameter("@job", MySqlDbType.VarChar,45),
					new MySqlParameter("@Company", MySqlDbType.VarChar,45),
					new MySqlParameter("@best_hobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@worst_bobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@birth_date", MySqlDbType.VarChar,45),
					new MySqlParameter("@best_wish", MySqlDbType.VarChar,45),
					new MySqlParameter("@hobby", MySqlDbType.VarChar,45),
					new MySqlParameter("@like_color", MySqlDbType.VarChar,45),
					new MySqlParameter("@likedrink", MySqlDbType.VarChar,45),
					new MySqlParameter("@artist_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.height;
			parameters[1].Value = model.name;
			parameters[2].Value = model.name_eg;
			parameters[3].Value = model.weight;
			parameters[4].Value = model.langrange;
			parameters[5].Value = model.start;
			parameters[6].Value = model.live_pet;
			parameters[7].Value = model.blood_type;
			parameters[8].Value = model.love_to_say;
			parameters[9].Value = model.job;
			parameters[10].Value = model.Company;
			parameters[11].Value = model.best_hobby;
			parameters[12].Value = model.worst_bobby;
			parameters[13].Value = model.birth_date;
			parameters[14].Value = model.best_wish;
			parameters[15].Value = model.hobby;
			parameters[16].Value = model.like_color;
			parameters[17].Value = model.likedrink;
			parameters[18].Value = model.artist_id;

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
		public bool Delete(int artist_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from artists ");
			strSql.Append(" where artist_id=@artist_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@artist_id", MySqlDbType.Int32)
			};
			parameters[0].Value = artist_id;

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
		public bool DeleteList(string artist_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from artists ");
			strSql.Append(" where artist_id in ("+artist_idlist + ")  ");
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
		public WoeMobile.Model.artists GetModel(int artist_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select artist_id,height,name,name_eg,weight,langrange,start,live_pet,blood_type,love_to_say,job,Company,best_hobby,worst_bobby,birth_date,best_wish,hobby,like_color,likedrink from artists ");
			strSql.Append(" where artist_id=@artist_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@artist_id", MySqlDbType.Int32)
			};
			parameters[0].Value = artist_id;

			WoeMobile.Model.artists model=new WoeMobile.Model.artists();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["artist_id"]!=null && ds.Tables[0].Rows[0]["artist_id"].ToString()!="")
				{
					model.artist_id=int.Parse(ds.Tables[0].Rows[0]["artist_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["height"]!=null && ds.Tables[0].Rows[0]["height"].ToString()!="")
				{
					model.height=int.Parse(ds.Tables[0].Rows[0]["height"].ToString());
				}
				if(ds.Tables[0].Rows[0]["name"]!=null && ds.Tables[0].Rows[0]["name"].ToString()!="")
				{
					model.name=ds.Tables[0].Rows[0]["name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["name_eg"]!=null && ds.Tables[0].Rows[0]["name_eg"].ToString()!="")
				{
					model.name_eg=ds.Tables[0].Rows[0]["name_eg"].ToString();
				}
				if(ds.Tables[0].Rows[0]["weight"]!=null && ds.Tables[0].Rows[0]["weight"].ToString()!="")
				{
					model.weight=ds.Tables[0].Rows[0]["weight"].ToString();
				}
				if(ds.Tables[0].Rows[0]["langrange"]!=null && ds.Tables[0].Rows[0]["langrange"].ToString()!="")
				{
					model.langrange=ds.Tables[0].Rows[0]["langrange"].ToString();
				}
				if(ds.Tables[0].Rows[0]["start"]!=null && ds.Tables[0].Rows[0]["start"].ToString()!="")
				{
					model.start=ds.Tables[0].Rows[0]["start"].ToString();
				}
				if(ds.Tables[0].Rows[0]["live_pet"]!=null && ds.Tables[0].Rows[0]["live_pet"].ToString()!="")
				{
					model.live_pet=ds.Tables[0].Rows[0]["live_pet"].ToString();
				}
				if(ds.Tables[0].Rows[0]["blood_type"]!=null && ds.Tables[0].Rows[0]["blood_type"].ToString()!="")
				{
					model.blood_type=ds.Tables[0].Rows[0]["blood_type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["love_to_say"]!=null && ds.Tables[0].Rows[0]["love_to_say"].ToString()!="")
				{
					model.love_to_say=ds.Tables[0].Rows[0]["love_to_say"].ToString();
				}
				if(ds.Tables[0].Rows[0]["job"]!=null && ds.Tables[0].Rows[0]["job"].ToString()!="")
				{
					model.job=ds.Tables[0].Rows[0]["job"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Company"]!=null && ds.Tables[0].Rows[0]["Company"].ToString()!="")
				{
					model.Company=ds.Tables[0].Rows[0]["Company"].ToString();
				}
				if(ds.Tables[0].Rows[0]["best_hobby"]!=null && ds.Tables[0].Rows[0]["best_hobby"].ToString()!="")
				{
					model.best_hobby=ds.Tables[0].Rows[0]["best_hobby"].ToString();
				}
				if(ds.Tables[0].Rows[0]["worst_bobby"]!=null && ds.Tables[0].Rows[0]["worst_bobby"].ToString()!="")
				{
					model.worst_bobby=ds.Tables[0].Rows[0]["worst_bobby"].ToString();
				}
				if(ds.Tables[0].Rows[0]["birth_date"]!=null && ds.Tables[0].Rows[0]["birth_date"].ToString()!="")
				{
					model.birth_date=ds.Tables[0].Rows[0]["birth_date"].ToString();
				}
				if(ds.Tables[0].Rows[0]["best_wish"]!=null && ds.Tables[0].Rows[0]["best_wish"].ToString()!="")
				{
					model.best_wish=ds.Tables[0].Rows[0]["best_wish"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hobby"]!=null && ds.Tables[0].Rows[0]["hobby"].ToString()!="")
				{
					model.hobby=ds.Tables[0].Rows[0]["hobby"].ToString();
				}
				if(ds.Tables[0].Rows[0]["like_color"]!=null && ds.Tables[0].Rows[0]["like_color"].ToString()!="")
				{
					model.like_color=ds.Tables[0].Rows[0]["like_color"].ToString();
				}
				if(ds.Tables[0].Rows[0]["likedrink"]!=null && ds.Tables[0].Rows[0]["likedrink"].ToString()!="")
				{
					model.likedrink=ds.Tables[0].Rows[0]["likedrink"].ToString();
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
			strSql.Append("select artist_id,height,name,name_eg,weight,langrange,start,live_pet,blood_type,love_to_say,job,Company,best_hobby,worst_bobby,birth_date,best_wish,hobby,like_color,likedrink ");
			strSql.Append(" FROM artists ");
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
			strSql.Append("select count(1) FROM artists ");
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
				strSql.Append("order by T.artist_id desc");
			}
			strSql.Append(")AS Row, T.*  from artists T ");
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
			parameters[0].Value = "artists";
			parameters[1].Value = "artist_id";
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

