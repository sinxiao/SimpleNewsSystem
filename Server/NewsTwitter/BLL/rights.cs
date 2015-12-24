using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// rights
	/// </summary>
	public partial class RightsManager
	{
		protected readonly WoeMobile.DAL.rights dal=new WoeMobile.DAL.rights();
		public RightsManager()
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
		public bool Exists(int idRights)
		{
			return dal.Exists(idRights);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.rights model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.rights model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idRights)
		{
			
			return dal.Delete(idRights);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idRightslist )
		{
			return dal.DeleteList(idRightslist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.rights GetModel(int idRights)
		{
			
			return dal.GetModel(idRights);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.rights GetModelByCache(int idRights)
		{
			
			string CacheKey = "rightsModel-" + idRights;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idRights);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.rights)objModel;
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
		public List<WoeMobile.Model.rights> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.rights> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.rights> modelList = new List<WoeMobile.Model.rights>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.rights model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.rights();
					if(dt.Rows[n]["idRights"]!=null && dt.Rows[n]["idRights"].ToString()!="")
					{
						model.idRights=int.Parse(dt.Rows[n]["idRights"].ToString());
					}
					if(dt.Rows[n]["parent_r_id"]!=null && dt.Rows[n]["parent_r_id"].ToString()!="")
					{
						model.parent_r_id=int.Parse(dt.Rows[n]["parent_r_id"].ToString());
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["url"]!=null && dt.Rows[n]["url"].ToString()!="")
					{
					model.url=dt.Rows[n]["url"].ToString();
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

