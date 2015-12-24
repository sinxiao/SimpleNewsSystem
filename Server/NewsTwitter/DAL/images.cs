using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:images
	/// </summary>
	public partial class images
	{
		public images()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("image_id", "images"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int image_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from images");
			strSql.Append(" where image_id=@image_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@image_id", MySqlDbType.Int32)
			};
			parameters[0].Value = image_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.images model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into images(");
			strSql.Append("image_src,image_owner,demo,uid,trace_id,location_id,bdata)");
			strSql.Append(" values (");
			strSql.Append("@image_src,@image_owner,@demo,@uid,@trace_id,@location_id,@bdata)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@image_src", MySqlDbType.VarChar,200),
					new MySqlParameter("@image_owner", MySqlDbType.Int32,11),
					new MySqlParameter("@demo", MySqlDbType.Text),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_id", MySqlDbType.Int32,11),
					new MySqlParameter("@location_id", MySqlDbType.Int32,11),
					new MySqlParameter("@bdata", MySqlDbType.Blob)};
			parameters[0].Value = model.image_src;
			parameters[1].Value = model.image_owner;
			parameters[2].Value = model.demo;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.trace_id;
			parameters[5].Value = model.location_id;
			parameters[6].Value = model.bdata;

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
		public bool Update(WoeMobile.Model.images model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update images set ");
			strSql.Append("image_src=@image_src,");
			strSql.Append("image_owner=@image_owner,");
			strSql.Append("demo=@demo,");
			strSql.Append("uid=@uid,");
			strSql.Append("trace_id=@trace_id,");
			strSql.Append("location_id=@location_id,");
			strSql.Append("bdata=@bdata");
			strSql.Append(" where image_id=@image_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@image_src", MySqlDbType.VarChar,200),
					new MySqlParameter("@image_owner", MySqlDbType.Int32,11),
					new MySqlParameter("@demo", MySqlDbType.Text),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_id", MySqlDbType.Int32,11),
					new MySqlParameter("@location_id", MySqlDbType.Int32,11),
					new MySqlParameter("@bdata", MySqlDbType.Blob),
					new MySqlParameter("@image_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.image_src;
			parameters[1].Value = model.image_owner;
			parameters[2].Value = model.demo;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.trace_id;
			parameters[5].Value = model.location_id;
			parameters[6].Value = model.bdata;
			parameters[7].Value = model.image_id;

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
		public bool Delete(int image_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from images ");
			strSql.Append(" where image_id=@image_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@image_id", MySqlDbType.Int32)
			};
			parameters[0].Value = image_id;

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
		public bool DeleteList(string image_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from images ");
			strSql.Append(" where image_id in ("+image_idlist + ")  ");
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
		public WoeMobile.Model.images GetModel(int image_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select image_id,image_src,image_owner,demo,uid,trace_id,location_id,bdata from images ");
			strSql.Append(" where image_id=@image_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@image_id", MySqlDbType.Int32)
			};
			parameters[0].Value = image_id;

			WoeMobile.Model.images model=new WoeMobile.Model.images();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["image_id"]!=null && ds.Tables[0].Rows[0]["image_id"].ToString()!="")
				{
					model.image_id=int.Parse(ds.Tables[0].Rows[0]["image_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["image_src"]!=null && ds.Tables[0].Rows[0]["image_src"].ToString()!="")
				{
					model.image_src=ds.Tables[0].Rows[0]["image_src"].ToString();
				}
				if(ds.Tables[0].Rows[0]["image_owner"]!=null && ds.Tables[0].Rows[0]["image_owner"].ToString()!="")
				{
					model.image_owner=int.Parse(ds.Tables[0].Rows[0]["image_owner"].ToString());
				}
				if(ds.Tables[0].Rows[0]["demo"]!=null && ds.Tables[0].Rows[0]["demo"].ToString()!="")
				{
					model.demo=ds.Tables[0].Rows[0]["demo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["trace_id"]!=null && ds.Tables[0].Rows[0]["trace_id"].ToString()!="")
				{
					model.trace_id=int.Parse(ds.Tables[0].Rows[0]["trace_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["location_id"]!=null && ds.Tables[0].Rows[0]["location_id"].ToString()!="")
				{
					model.location_id=int.Parse(ds.Tables[0].Rows[0]["location_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["bdata"]!=null && ds.Tables[0].Rows[0]["bdata"].ToString()!="")
				{
					model.bdata=(byte[])ds.Tables[0].Rows[0]["bdata"];
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
			strSql.Append("select image_id,image_src,image_owner,demo,uid,trace_id,location_id,bdata ");
			strSql.Append(" FROM images ");
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
			strSql.Append("select count(1) FROM images ");
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
				strSql.Append("order by T.image_id desc");
			}
			strSql.Append(")AS Row, T.*  from images T ");
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
			parameters[0].Value = "images";
			parameters[1].Value = "image_id";
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

