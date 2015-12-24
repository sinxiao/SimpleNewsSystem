using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:twitter
	/// </summary>
	public partial class twitter
	{
		public twitter()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("twitter_id", "twitter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int twitter_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from twitter");
			strSql.Append(" where twitter_id=@twitter_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32)
			};
			parameters[0].Value = twitter_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into twitter(");
			strSql.Append("datatime,detial,ower_id_twitter,uid,tw_type,target_id,target_type,pinglun_sum,zhuangfa_sum,topic,linked,love_sum)");
			strSql.Append(" values (");
			strSql.Append("@datatime,@detial,@ower_id_twitter,@uid,@tw_type,@target_id,@target_type,@pinglun_sum,@zhuangfa_sum,@topic,@linked,@love_sum)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@datatime", MySqlDbType.VarChar,45),
					new MySqlParameter("@detial", MySqlDbType.VarChar,45),
					new MySqlParameter("@ower_id_twitter", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@tw_type", MySqlDbType.Int32,11),
					new MySqlParameter("@target_id", MySqlDbType.Int32,11),
					new MySqlParameter("@target_type", MySqlDbType.Int32,11),
					new MySqlParameter("@pinglun_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@zhuangfa_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@topic", MySqlDbType.VarChar,45),
					new MySqlParameter("@linked", MySqlDbType.VarChar,600),
					new MySqlParameter("@love_sum", MySqlDbType.Int32,11)};
			parameters[0].Value = model.datatime;
			parameters[1].Value = model.detial;
			parameters[2].Value = model.ower_id_twitter;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.tw_type;
			parameters[5].Value = model.target_id;
			parameters[6].Value = model.target_type;
			parameters[7].Value = model.pinglun_sum;
			parameters[8].Value = model.zhuangfa_sum;
			parameters[9].Value = model.topic;
			parameters[10].Value = model.linked;
			parameters[11].Value = model.love_sum;

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
		public bool Update(WoeMobile.Model.twitter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update twitter set ");
			strSql.Append("datatime=@datatime,");
			strSql.Append("detial=@detial,");
			strSql.Append("ower_id_twitter=@ower_id_twitter,");
			strSql.Append("uid=@uid,");
			strSql.Append("tw_type=@tw_type,");
			strSql.Append("target_id=@target_id,");
			strSql.Append("target_type=@target_type,");
			strSql.Append("pinglun_sum=@pinglun_sum,");
			strSql.Append("zhuangfa_sum=@zhuangfa_sum,");
			strSql.Append("topic=@topic,");
			strSql.Append("linked=@linked,");
			strSql.Append("love_sum=@love_sum");
			strSql.Append(" where twitter_id=@twitter_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@datatime", MySqlDbType.VarChar,45),
					new MySqlParameter("@detial", MySqlDbType.VarChar,45),
					new MySqlParameter("@ower_id_twitter", MySqlDbType.Int32,11),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@tw_type", MySqlDbType.Int32,11),
					new MySqlParameter("@target_id", MySqlDbType.Int32,11),
					new MySqlParameter("@target_type", MySqlDbType.Int32,11),
					new MySqlParameter("@pinglun_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@zhuangfa_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@topic", MySqlDbType.VarChar,45),
					new MySqlParameter("@linked", MySqlDbType.VarChar,600),
					new MySqlParameter("@love_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@twitter_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.datatime;
			parameters[1].Value = model.detial;
			parameters[2].Value = model.ower_id_twitter;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.tw_type;
			parameters[5].Value = model.target_id;
			parameters[6].Value = model.target_type;
			parameters[7].Value = model.pinglun_sum;
			parameters[8].Value = model.zhuangfa_sum;
			parameters[9].Value = model.topic;
			parameters[10].Value = model.linked;
			parameters[11].Value = model.love_sum;
			parameters[12].Value = model.twitter_id;

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
		public bool Delete(int twitter_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter ");
			strSql.Append(" where twitter_id=@twitter_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32)
			};
			parameters[0].Value = twitter_id;

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
		public bool DeleteList(string twitter_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from twitter ");
			strSql.Append(" where twitter_id in ("+twitter_idlist + ")  ");
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
		public WoeMobile.Model.twitter GetModel(int twitter_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select datatime,detial,ower_id_twitter,uid,tw_type,target_id,target_type,twitter_id,pinglun_sum,zhuangfa_sum,topic,linked,love_sum from twitter ");
			strSql.Append(" where twitter_id=@twitter_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@twitter_id", MySqlDbType.Int32)
			};
			parameters[0].Value = twitter_id;

			WoeMobile.Model.twitter model=new WoeMobile.Model.twitter();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["datatime"]!=null && ds.Tables[0].Rows[0]["datatime"].ToString()!="")
				{
					model.datatime=ds.Tables[0].Rows[0]["datatime"].ToString();
				}
				if(ds.Tables[0].Rows[0]["detial"]!=null && ds.Tables[0].Rows[0]["detial"].ToString()!="")
				{
					model.detial=ds.Tables[0].Rows[0]["detial"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ower_id_twitter"]!=null && ds.Tables[0].Rows[0]["ower_id_twitter"].ToString()!="")
				{
					model.ower_id_twitter=int.Parse(ds.Tables[0].Rows[0]["ower_id_twitter"].ToString());
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["tw_type"]!=null && ds.Tables[0].Rows[0]["tw_type"].ToString()!="")
				{
					model.tw_type=int.Parse(ds.Tables[0].Rows[0]["tw_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["target_id"]!=null && ds.Tables[0].Rows[0]["target_id"].ToString()!="")
				{
					model.target_id=int.Parse(ds.Tables[0].Rows[0]["target_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["target_type"]!=null && ds.Tables[0].Rows[0]["target_type"].ToString()!="")
				{
					model.target_type=int.Parse(ds.Tables[0].Rows[0]["target_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["twitter_id"]!=null && ds.Tables[0].Rows[0]["twitter_id"].ToString()!="")
				{
					model.twitter_id=int.Parse(ds.Tables[0].Rows[0]["twitter_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pinglun_sum"]!=null && ds.Tables[0].Rows[0]["pinglun_sum"].ToString()!="")
				{
					model.pinglun_sum=int.Parse(ds.Tables[0].Rows[0]["pinglun_sum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["zhuangfa_sum"]!=null && ds.Tables[0].Rows[0]["zhuangfa_sum"].ToString()!="")
				{
					model.zhuangfa_sum=int.Parse(ds.Tables[0].Rows[0]["zhuangfa_sum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["topic"]!=null && ds.Tables[0].Rows[0]["topic"].ToString()!="")
				{
					model.topic=ds.Tables[0].Rows[0]["topic"].ToString();
				}
				if(ds.Tables[0].Rows[0]["linked"]!=null && ds.Tables[0].Rows[0]["linked"].ToString()!="")
				{
					model.linked=ds.Tables[0].Rows[0]["linked"].ToString();
				}
				if(ds.Tables[0].Rows[0]["love_sum"]!=null && ds.Tables[0].Rows[0]["love_sum"].ToString()!="")
				{
					model.love_sum=int.Parse(ds.Tables[0].Rows[0]["love_sum"].ToString());
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
			strSql.Append("select datatime,detial,ower_id_twitter,uid,tw_type,target_id,target_type,twitter_id,pinglun_sum,zhuangfa_sum,topic,linked,love_sum ");
			strSql.Append(" FROM twitter ");
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
			strSql.Append("select count(1) FROM twitter ");
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
				strSql.Append("order by T.twitter_id desc");
			}
			strSql.Append(")AS Row, T.*  from twitter T ");
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
			parameters[0].Value = "twitter";
			parameters[1].Value = "twitter_id";
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

