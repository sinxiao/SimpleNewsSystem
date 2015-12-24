using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// rolerightreltion
	/// </summary>
	public partial class RolerightreltionManager
	{
		private readonly WoeMobile.DAL.rolerightreltion dal=new WoeMobile.DAL.rolerightreltion();
		public RolerightreltionManager()
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
		public bool Exists(int idRoleRightReltion)
		{
			return dal.Exists(idRoleRightReltion);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.rolerightreltion model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.rolerightreltion model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idRoleRightReltion)
		{
			
			return dal.Delete(idRoleRightReltion);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idRoleRightReltionlist )
		{
			return dal.DeleteList(idRoleRightReltionlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.rolerightreltion GetModel(int idRoleRightReltion)
		{
			
			return dal.GetModel(idRoleRightReltion);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.rolerightreltion GetModelByCache(int idRoleRightReltion)
		{
			
			string CacheKey = "rolerightreltionModel-" + idRoleRightReltion;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idRoleRightReltion);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.rolerightreltion)objModel;
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
		public List<WoeMobile.Model.rolerightreltion> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.rolerightreltion> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.rolerightreltion> modelList = new List<WoeMobile.Model.rolerightreltion>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.rolerightreltion model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.rolerightreltion();
					if(dt.Rows[n]["idRoleRightReltion"]!=null && dt.Rows[n]["idRoleRightReltion"].ToString()!="")
					{
						model.idRoleRightReltion=int.Parse(dt.Rows[n]["idRoleRightReltion"].ToString());
					}
					if(dt.Rows[n]["role_id"]!=null && dt.Rows[n]["role_id"].ToString()!="")
					{
						model.role_id=int.Parse(dt.Rows[n]["role_id"].ToString());
					}
					if(dt.Rows[n]["right_id"]!=null && dt.Rows[n]["right_id"].ToString()!="")
					{
						model.right_id=int.Parse(dt.Rows[n]["right_id"].ToString());
					}
					if(dt.Rows[n]["right_type"]!=null && dt.Rows[n]["right_type"].ToString()!="")
					{
						model.right_type=int.Parse(dt.Rows[n]["right_type"].ToString());
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

