using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// manager
	/// </summary>
	public partial class AdminManager
	{
		protected readonly WoeMobile.DAL.manager dal=new WoeMobile.DAL.manager();
		public AdminManager()
		{}
		#region  Method

        
		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idmanager)
		{
			return dal.Exists(idmanager);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.manager model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.manager model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idmanager)
		{
			
			return dal.Delete(idmanager);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idmanagerlist )
		{
			return dal.DeleteList(idmanagerlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.manager GetModel(int idmanager)
		{
			
			return dal.GetModel(idmanager);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.manager GetModelByCache(int idmanager)
		{
			
			string CacheKey = "managerModel-" + idmanager;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idmanager);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.manager)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
                      
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.manager> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.manager> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.manager> modelList = new List<WoeMobile.Model.manager>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.manager model;
                OrganizationManager org = new OrganizationManager();
                RoleManager role = new RoleManager();
                EuserManager user = new EuserManager();
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.manager();
					if(dt.Rows[n]["idmanager"]!=null && dt.Rows[n]["idmanager"].ToString()!="")
					{
						model.idmanager=int.Parse(dt.Rows[n]["idmanager"].ToString());
					}
					if(dt.Rows[n]["username"]!=null && dt.Rows[n]["username"].ToString()!="")
					{
					model.username=dt.Rows[n]["username"].ToString();
					}
					if(dt.Rows[n]["email"]!=null && dt.Rows[n]["email"].ToString()!="")
					{
					model.email=dt.Rows[n]["email"].ToString();
					}
					if(dt.Rows[n]["pwdword"]!=null && dt.Rows[n]["pwdword"].ToString()!="")
					{
					model.pwdword=dt.Rows[n]["pwdword"].ToString();
					}
					if(dt.Rows[n]["phone"]!=null && dt.Rows[n]["phone"].ToString()!="")
					{
					model.phone=dt.Rows[n]["phone"].ToString();
					}
					if(dt.Rows[n]["QQ"]!=null && dt.Rows[n]["QQ"].ToString()!="")
					{
					model.QQ=dt.Rows[n]["QQ"].ToString();
					}
					if(dt.Rows[n]["to_id"]!=null && dt.Rows[n]["to_id"].ToString()!="")
					{
						model.to_id=int.Parse(dt.Rows[n]["to_id"].ToString());
					}
					if(dt.Rows[n]["realname"]!=null && dt.Rows[n]["realname"].ToString()!="")
					{
					model.realname=dt.Rows[n]["realname"].ToString();
					}
					if(dt.Rows[n]["u_code"]!=null && dt.Rows[n]["u_code"].ToString()!="")
					{
					model.u_code=dt.Rows[n]["u_code"].ToString();
					}
					if(dt.Rows[n]["last_login"]!=null && dt.Rows[n]["last_login"].ToString()!="")
					{
						model.last_login=DateTime.Parse(dt.Rows[n]["last_login"].ToString());
					}
					if(dt.Rows[n]["login_sum"]!=null && dt.Rows[n]["login_sum"].ToString()!="")
					{
						model.login_sum=int.Parse(dt.Rows[n]["login_sum"].ToString());
					}
					if(dt.Rows[n]["create_time"]!=null && dt.Rows[n]["create_time"].ToString()!="")
					{
					model.create_time=dt.Rows[n]["create_time"].ToString();
					}
					if(dt.Rows[n]["role_id"]!=null && dt.Rows[n]["role_id"].ToString()!="")
					{
						model.role_id=int.Parse(dt.Rows[n]["role_id"].ToString());
					}
					if(dt.Rows[n]["user_id"]!=null && dt.Rows[n]["user_id"].ToString()!="")
					{
						model.user_id=int.Parse(dt.Rows[n]["user_id"].ToString());
					}
					if(dt.Rows[n]["gender"]!=null && dt.Rows[n]["gender"].ToString()!="")
					{
						model.gender=int.Parse(dt.Rows[n]["gender"].ToString());
					}
                    if (model.to_id!=null)
                    {
                        model.Organization = org.GetModel(model.to_id.Value);
                    }
                    

                    if (model.role_id!=null)
                    {
                        model.Role = role.GetModel(model.role_id.Value);
                    }
                    
                    if (model.user_id!=null)
                    {
                        model.Euser = user.GetModel(model.user_id.Value);
                    }
                    
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 通过4张表获得mananager的全部详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetManagerDetail() 
        {
            return dal.GetManagerDetail();
        }
        /// <summary>
        /// 通过4张表获得mananager的一个详细信息
        /// </summary>
        /// <param name="id">用户标识</param>
        /// <returns></returns>
        public DataSet GetManagerDetailById(int id)
        {
            return dal.GetManagerDetailById(id);
        }
		#endregion  Method

        public WoeMobile.Model.manager loginWithEmail(String email, String passwd)
        {
            WoeMobile.Model.manager admin = GetManagerByEmail(email);
            if (admin == null)
            {
                return null;
            }
            else
            {
                if (admin.pwdword.Equals(passwd))
                {
                    admin.last_login = DateTime.Now;
                    Update(admin);
                    return admin;
                }
                return null;
            }


        }
        public WoeMobile.Model.manager GetManagerByEmail(String email)
        {
            DataSet ds = dal.GetList("email = '" + email + "'");
            List<WoeMobile.Model.manager> lt = DataTableToList(ds.Tables[0]);
            if (lt == null || lt.Count <= 0)
            {
                return null;
            }
            else
            {
                return lt[0];
            }

        }

        public WoeMobile.Model.manager RegisterManager(Model.manager manager)
        {
            WoeMobile.Model.manager lt = GetManagerByEmail(manager.email);
            if (lt != null)
            {

            }
            else
            {
                Boolean bl = Add(manager);
                if (bl == true)
                {
                    return GetManagerByEmail(manager.email);
                }
            }

            return null;
        }

        public DataSet GetRightByRoleId(int role)
        {
            //select rolerightreltion.right_type , rights.*  from rolerightreltion left join rights on
            //rights.idRights = rolerightreltion.right_id where rolerightreltion.role_id = 1
            // idRights   parent_r_id  name url right_type
            DataSet ds = Maticsoft.DBUtility.DbHelperMySQL.Query("select rolerightreltion.right_type , rights.*  from rolerightreltion left join rights on rights.idRights = rolerightreltion.right_id where rolerightreltion.role_id = " + role);

            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.manager> getManagerByPage(int page)
        {

            return null;
        }

	}
}

