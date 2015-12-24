using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:locations
	/// </summary>
	public partial class locations
	{
		public locations()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idlocations", "locations"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idlocations)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from locations");
			strSql.Append(" where idlocations=@idlocations");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idlocations", MySqlDbType.Int32)
			};
			parameters[0].Value = idlocations;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.locations model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into locations(");
			strSql.Append("longitude,latitude,datetime,uid,trace_id,demo,data1,data2,lname)");
			strSql.Append(" values (");
			strSql.Append("@longitude,@latitude,@datetime,@uid,@trace_id,@demo,@data1,@data2,@lname)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@longitude", MySqlDbType.VarChar,45),
					new MySqlParameter("@latitude", MySqlDbType.VarChar,45),
					new MySqlParameter("@datetime", MySqlDbType.VarChar,45),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_id", MySqlDbType.Int32,11),

                    new MySqlParameter("@demo", MySqlDbType.VarChar,45),
                    new MySqlParameter("@data1", MySqlDbType.VarChar,45),
                    new MySqlParameter("@data2", MySqlDbType.VarChar,45),
                    new MySqlParameter("@lname", MySqlDbType.VarChar,45)
                                          };
			parameters[0].Value = model.longitude;
			parameters[1].Value = model.latitude;
			parameters[2].Value = model.datetime;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.trace_id;

            parameters[5].Value = model.Demo;
            parameters[6].Value = model.Data1;
            parameters[7].Value = model.Data2;
            parameters[8].Value = model.Lname;
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
		public bool Update(WoeMobile.Model.locations model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update locations set ");
			strSql.Append("longitude=@longitude,");
			strSql.Append("latitude=@latitude,");
			strSql.Append("datetime=@datetime,");
			strSql.Append("uid=@uid,");
			strSql.Append("trace_id=@trace_id,");

            strSql.Append("demo=@demo,");
            strSql.Append("data1=@data1,");
            strSql.Append("data2=@data2,");
            strSql.Append("lname=@lname");

			strSql.Append(" where idlocations=@idlocations");
			MySqlParameter[] parameters = {
					new MySqlParameter("@longitude", MySqlDbType.VarChar,45),
					new MySqlParameter("@latitude", MySqlDbType.VarChar,45),
					new MySqlParameter("@datetime", MySqlDbType.VarChar,45),
					new MySqlParameter("@uid", MySqlDbType.Int32,11),
					new MySqlParameter("@trace_id", MySqlDbType.Int32,11),

                    new MySqlParameter("@demo", MySqlDbType.VarChar,45),
                    new MySqlParameter("@data1", MySqlDbType.VarChar,45),
                    new MySqlParameter("@data2", MySqlDbType.VarChar,45),
                    new MySqlParameter("@lname", MySqlDbType.VarChar,45) ,

					new MySqlParameter("@idlocations", MySqlDbType.Int32,11)
                    
                   
                                          };
			parameters[0].Value = model.longitude;
			parameters[1].Value = model.latitude;
			parameters[2].Value = model.datetime;
			parameters[3].Value = model.uid;
			parameters[4].Value = model.trace_id;

            parameters[5].Value = model.Demo;
            parameters[6].Value = model.Data1;
            parameters[7].Value = model.Data2;
            parameters[8].Value = model.Lname;

			parameters[9].Value = model.idlocations;

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
		public bool Delete(int idlocations)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from locations ");
			strSql.Append(" where idlocations=@idlocations");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idlocations", MySqlDbType.Int32)
			};
			parameters[0].Value = idlocations;

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
		public bool DeleteList(string idlocationslist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from locations ");
			strSql.Append(" where idlocations in ("+idlocationslist + ")  ");
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
		public WoeMobile.Model.locations GetModel(int idlocations)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idlocations,longitude,latitude,datetime,uid,trace_id,demo,data1,data2,lname from locations ");
			strSql.Append(" where idlocations=@idlocations");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idlocations", MySqlDbType.Int32)
			};
			parameters[0].Value = idlocations;

			WoeMobile.Model.locations model=new WoeMobile.Model.locations();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idlocations"]!=null && ds.Tables[0].Rows[0]["idlocations"].ToString()!="")
				{
					model.idlocations=int.Parse(ds.Tables[0].Rows[0]["idlocations"].ToString());
				}
				if(ds.Tables[0].Rows[0]["longitude"]!=null && ds.Tables[0].Rows[0]["longitude"].ToString()!="")
				{
					model.longitude=ds.Tables[0].Rows[0]["longitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["latitude"]!=null && ds.Tables[0].Rows[0]["latitude"].ToString()!="")
				{
					model.latitude=ds.Tables[0].Rows[0]["latitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["datetime"]!=null && ds.Tables[0].Rows[0]["datetime"].ToString()!="")
				{
					model.datetime=ds.Tables[0].Rows[0]["datetime"].ToString();
				}
				if(ds.Tables[0].Rows[0]["uid"]!=null && ds.Tables[0].Rows[0]["uid"].ToString()!="")
				{
					model.uid=int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["trace_id"]!=null && ds.Tables[0].Rows[0]["trace_id"].ToString()!="")
				{
					model.trace_id=int.Parse(ds.Tables[0].Rows[0]["trace_id"].ToString());
				}

                if (ds.Tables[0].Rows[0]["demo"] != null && ds.Tables[0].Rows[0]["demo"].ToString() != "")
                {
                    model.Demo = ds.Tables[0].Rows[0]["demo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["data1"] != null && ds.Tables[0].Rows[0]["data1"].ToString() != "")
                {
                    model.Data1 = ds.Tables[0].Rows[0]["latitude"].ToString();
                }
                if (ds.Tables[0].Rows[0]["data2"] != null && ds.Tables[0].Rows[0]["data2"].ToString() != "")
                {
                    model.Data2 = ds.Tables[0].Rows[0]["data2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["lname"] != null && ds.Tables[0].Rows[0]["lname"].ToString() != "")
                {
                    model.Lname = ds.Tables[0].Rows[0]["lname"].ToString();
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
			strSql.Append("select idlocations,longitude,latitude,datetime,uid,trace_id,demo,data1,data2,lname ");
			strSql.Append(" FROM locations ");
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
			strSql.Append("select count(1) FROM locations ");
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
				strSql.Append("order by T.idlocations desc");
			}
			strSql.Append(")AS Row, T.*  from locations T ");
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
			parameters[0].Value = "locations";
			parameters[1].Value = "idlocations";
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

