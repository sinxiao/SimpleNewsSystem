using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace WoeMobile.DAL
{
	/// <summary>
	/// 数据访问类:manager
	/// </summary>
	public partial class manager
	{
		public manager()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("idmanager", "manager"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idmanager)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from manager");
			strSql.Append(" where idmanager=@idmanager");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idmanager", MySqlDbType.Int32)
			};
			parameters[0].Value = idmanager;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.manager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into manager(");
			strSql.Append("username,email,pwdword,phone,QQ,to_id,realname,u_code,last_login,login_sum,create_time,role_id,user_id,gender)");
			strSql.Append(" values (");
			strSql.Append("@username,@email,@pwdword,@phone,@QQ,@to_id,@realname,@u_code,@last_login,@login_sum,@create_time,@role_id,@user_id,@gender)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@pwdword", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone", MySqlDbType.VarChar,45),
					new MySqlParameter("@QQ", MySqlDbType.VarChar,45),
					new MySqlParameter("@to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@realname", MySqlDbType.VarChar,45),
					new MySqlParameter("@u_code", MySqlDbType.VarChar,45),
					new MySqlParameter("@last_login", MySqlDbType.Timestamp),
					new MySqlParameter("@login_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@create_time", MySqlDbType.VarChar,45),
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@gender", MySqlDbType.Int32,11)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.email;
			parameters[2].Value = model.pwdword;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.QQ;
			parameters[5].Value = model.to_id;
			parameters[6].Value = model.realname;
			parameters[7].Value = model.u_code;
			parameters[8].Value = model.last_login;
			parameters[9].Value = model.login_sum;
			parameters[10].Value = model.create_time;
			parameters[11].Value = model.role_id;
			parameters[12].Value = model.user_id;
			parameters[13].Value = model.gender;

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
		public bool Update(WoeMobile.Model.manager model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update manager set ");
			strSql.Append("username=@username,");
			strSql.Append("email=@email,");
			strSql.Append("pwdword=@pwdword,");
			strSql.Append("phone=@phone,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("to_id=@to_id,");
			strSql.Append("realname=@realname,");
			strSql.Append("u_code=@u_code,");
			strSql.Append("login_sum=@login_sum,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("role_id=@role_id,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("gender=@gender");
			strSql.Append(" where idmanager=@idmanager");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@pwdword", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone", MySqlDbType.VarChar,45),
					new MySqlParameter("@QQ", MySqlDbType.VarChar,45),
					new MySqlParameter("@to_id", MySqlDbType.Int32,11),
					new MySqlParameter("@realname", MySqlDbType.VarChar,45),
					new MySqlParameter("@u_code", MySqlDbType.VarChar,45),
					new MySqlParameter("@login_sum", MySqlDbType.Int32,11),
					new MySqlParameter("@create_time", MySqlDbType.VarChar,45),
					new MySqlParameter("@role_id", MySqlDbType.Int32,11),
					new MySqlParameter("@user_id", MySqlDbType.Int32,11),
					new MySqlParameter("@gender", MySqlDbType.Int32,11),
					new MySqlParameter("@idmanager", MySqlDbType.Int32,11)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.email;
			parameters[2].Value = model.pwdword;
			parameters[3].Value = model.phone;
			parameters[4].Value = model.QQ;
			parameters[5].Value = model.to_id;
			parameters[6].Value = model.realname;
			parameters[7].Value = model.u_code;
			parameters[8].Value = model.login_sum;
			parameters[9].Value = model.create_time;
			parameters[10].Value = model.role_id;
			parameters[11].Value = model.user_id;
			parameters[12].Value = model.gender;
			parameters[13].Value = model.idmanager;

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
		public bool Delete(int idmanager)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from manager ");
			strSql.Append(" where idmanager=@idmanager");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idmanager", MySqlDbType.Int32)
			};
			parameters[0].Value = idmanager;

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
		public bool DeleteList(string idmanagerlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from manager ");
			strSql.Append(" where idmanager in ("+idmanagerlist + ")  ");
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
		public WoeMobile.Model.manager GetModel(int idmanager)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select idmanager,username,email,pwdword,phone,QQ,to_id,realname,u_code,last_login,login_sum,create_time,role_id,user_id,gender from manager ");
			strSql.Append(" where idmanager=@idmanager");
			MySqlParameter[] parameters = {
					new MySqlParameter("@idmanager", MySqlDbType.Int32)
			};
			parameters[0].Value = idmanager;

			WoeMobile.Model.manager model=new WoeMobile.Model.manager();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["idmanager"]!=null && ds.Tables[0].Rows[0]["idmanager"].ToString()!="")
				{
					model.idmanager=int.Parse(ds.Tables[0].Rows[0]["idmanager"].ToString());
				}
				if(ds.Tables[0].Rows[0]["username"]!=null && ds.Tables[0].Rows[0]["username"].ToString()!="")
				{
					model.username=ds.Tables[0].Rows[0]["username"].ToString();
				}
				if(ds.Tables[0].Rows[0]["email"]!=null && ds.Tables[0].Rows[0]["email"].ToString()!="")
				{
					model.email=ds.Tables[0].Rows[0]["email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pwdword"]!=null && ds.Tables[0].Rows[0]["pwdword"].ToString()!="")
				{
					model.pwdword=ds.Tables[0].Rows[0]["pwdword"].ToString();
				}
				if(ds.Tables[0].Rows[0]["phone"]!=null && ds.Tables[0].Rows[0]["phone"].ToString()!="")
				{
					model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QQ"]!=null && ds.Tables[0].Rows[0]["QQ"].ToString()!="")
				{
					model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				}
				if(ds.Tables[0].Rows[0]["to_id"]!=null && ds.Tables[0].Rows[0]["to_id"].ToString()!="")
				{
					model.to_id=int.Parse(ds.Tables[0].Rows[0]["to_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["realname"]!=null && ds.Tables[0].Rows[0]["realname"].ToString()!="")
				{
					model.realname=ds.Tables[0].Rows[0]["realname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["u_code"]!=null && ds.Tables[0].Rows[0]["u_code"].ToString()!="")
				{
					model.u_code=ds.Tables[0].Rows[0]["u_code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["last_login"]!=null && ds.Tables[0].Rows[0]["last_login"].ToString()!="")
				{
					model.last_login=DateTime.Parse(ds.Tables[0].Rows[0]["last_login"].ToString());
				}
				if(ds.Tables[0].Rows[0]["login_sum"]!=null && ds.Tables[0].Rows[0]["login_sum"].ToString()!="")
				{
					model.login_sum=int.Parse(ds.Tables[0].Rows[0]["login_sum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["create_time"]!=null && ds.Tables[0].Rows[0]["create_time"].ToString()!="")
				{
					model.create_time=ds.Tables[0].Rows[0]["create_time"].ToString();
				}
				if(ds.Tables[0].Rows[0]["role_id"]!=null && ds.Tables[0].Rows[0]["role_id"].ToString()!="")
				{
					model.role_id=int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_id"]!=null && ds.Tables[0].Rows[0]["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["gender"]!=null && ds.Tables[0].Rows[0]["gender"].ToString()!="")
				{
					model.gender=int.Parse(ds.Tables[0].Rows[0]["gender"].ToString());
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
			strSql.Append("select idmanager,username,email,pwdword,phone,QQ,to_id,realname,u_code,last_login,login_sum,create_time,role_id,user_id,gender ");
			strSql.Append(" FROM manager ");
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
			strSql.Append("select count(1) FROM manager ");
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
				strSql.Append("order by T.idmanager desc");
			}
			strSql.Append(")AS Row, T.*  from manager T ");
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
			parameters[0].Value = "manager";
			parameters[1].Value = "idmanager";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 通过4张表获得mananager的全部详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetManagerDetail() 
        {
            String strSql = "select manager.* ,role.rname,euser.*,organization.org_name from manager left join role on manager.role_id=role.idRole left join organization on manager.to_id= organization.idOrganization left join euser on  manager.user_id = euser.uid ;";
            return DbHelperMySQL.Query(strSql);
        }

        /// <summary>
        /// 通过4张表获得mananager的一个的详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetManagerDetailById(int idManager)
        {
            String strSql = "select manager.* ,role.rname,euser.*,organization.org_name from manager left join role on manager.role_id=role.idRole left join organization on manager.to_id= organization.idOrganization left join euser on  manager.user_id = euser.uid where manager.idmanager = "+idManager;
            return DbHelperMySQL.Query(strSql);
        }

		#endregion  Method
	}
}

