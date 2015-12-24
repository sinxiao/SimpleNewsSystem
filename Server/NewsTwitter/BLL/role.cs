using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// role
	/// </summary>
	public partial class RoleManager
	{
		private readonly WoeMobile.DAL.role dal=new WoeMobile.DAL.role();
		public RoleManager()
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
		public bool Exists(int idRole)
		{
			return dal.Exists(idRole);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idRole)
		{
			
			return dal.Delete(idRole);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idRolelist )
		{
			return dal.DeleteList(idRolelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.role GetModel(int idRole)
		{
			
			return dal.GetModel(idRole);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.role GetModelByCache(int idRole)
		{
			
			string CacheKey = "roleModel-" + idRole;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idRole);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.role)objModel;
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
		public List<WoeMobile.Model.role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.role> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.role> modelList = new List<WoeMobile.Model.role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.role();
					if(dt.Rows[n]["idRole"]!=null && dt.Rows[n]["idRole"].ToString()!="")
					{
						model.idRole=int.Parse(dt.Rows[n]["idRole"].ToString());
					}
					if(dt.Rows[n]["rname"]!=null && dt.Rows[n]["rname"].ToString()!="")
					{
					model.rname=dt.Rows[n]["rname"].ToString();
					}
					if(dt.Rows[n]["desription"]!=null && dt.Rows[n]["desription"].ToString()!="")
					{
					model.desription=dt.Rows[n]["desription"].ToString();
					}
					if(dt.Rows[n]["parent_r_id"]!=null && dt.Rows[n]["parent_r_id"].ToString()!="")
					{
					model.parent_r_id=dt.Rows[n]["parent_r_id"].ToString();
					}
					if(dt.Rows[n]["gen_time"]!=null && dt.Rows[n]["gen_time"].ToString()!="")
					{
						model.gen_time=DateTime.Parse(dt.Rows[n]["gen_time"].ToString());
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

