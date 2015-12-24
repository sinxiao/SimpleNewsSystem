using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// organization
	/// </summary>
	public partial class OrganizationManager
	{
		private readonly WoeMobile.DAL.organization dal=new WoeMobile.DAL.organization();
		public OrganizationManager()
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
		public bool Exists(int idOrganization)
		{
			return dal.Exists(idOrganization);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.organization model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.organization model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idOrganization)
		{
			
			return dal.Delete(idOrganization);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idOrganizationlist )
		{
			return dal.DeleteList(idOrganizationlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.organization GetModel(int idOrganization)
		{
			
			return dal.GetModel(idOrganization);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.organization GetModelByCache(int idOrganization)
		{
			
			string CacheKey = "organizationModel-" + idOrganization;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idOrganization);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.organization)objModel;
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
		public List<WoeMobile.Model.organization> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.organization> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.organization> modelList = new List<WoeMobile.Model.organization>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.organization model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.organization();
					if(dt.Rows[n]["idOrganization"]!=null && dt.Rows[n]["idOrganization"].ToString()!="")
					{
						model.idOrganization=int.Parse(dt.Rows[n]["idOrganization"].ToString());
					}
					if(dt.Rows[n]["parent_to_id"]!=null && dt.Rows[n]["parent_to_id"].ToString()!="")
					{
						model.parent_to_id=int.Parse(dt.Rows[n]["parent_to_id"].ToString());
					}
					if(dt.Rows[n]["org_name"]!=null && dt.Rows[n]["org_name"].ToString()!="")
					{
					model.org_name=dt.Rows[n]["org_name"].ToString();
					}
					if(dt.Rows[n]["org_gen"]!=null && dt.Rows[n]["org_gen"].ToString()!="")
					{
						model.org_gen=DateTime.Parse(dt.Rows[n]["org_gen"].ToString());
					}
					if(dt.Rows[n]["destription"]!=null && dt.Rows[n]["destription"].ToString()!="")
					{
					model.destription=dt.Rows[n]["destription"].ToString();
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

		#endregion  Method
	}
}

