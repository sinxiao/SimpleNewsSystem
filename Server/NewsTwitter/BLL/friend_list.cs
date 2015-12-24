using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// friend_list
	/// </summary>
	public partial class Friend_listManager
	{
		private readonly WoeMobile.DAL.friend_list dal=new WoeMobile.DAL.friend_list();
		public Friend_listManager()
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
		public bool Exists(int idfriend_list)
		{
			return dal.Exists(idfriend_list);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.friend_list model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.friend_list model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idfriend_list)
		{
			
			return dal.Delete(idfriend_list);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idfriend_listlist )
		{
			return dal.DeleteList(idfriend_listlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.friend_list GetModel(int idfriend_list)
		{
			
			return dal.GetModel(idfriend_list);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.friend_list GetModelByCache(int idfriend_list)
		{
			
			string CacheKey = "friend_listModel-" + idfriend_list;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idfriend_list);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.friend_list)objModel;
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
		public List<WoeMobile.Model.friend_list> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.friend_list> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.friend_list> modelList = new List<WoeMobile.Model.friend_list>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.friend_list model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.friend_list();
					if(dt.Rows[n]["idfriend_list"]!=null && dt.Rows[n]["idfriend_list"].ToString()!="")
					{
						model.idfriend_list=int.Parse(dt.Rows[n]["idfriend_list"].ToString());
					}
					if(dt.Rows[n]["u_id"]!=null && dt.Rows[n]["u_id"].ToString()!="")
					{
						model.u_id=int.Parse(dt.Rows[n]["u_id"].ToString());
					}
					if(dt.Rows[n]["gen_time"]!=null && dt.Rows[n]["gen_time"].ToString()!="")
					{
						model.gen_time=DateTime.Parse(dt.Rows[n]["gen_time"].ToString());
					}
					if(dt.Rows[n]["friend_list_name"]!=null && dt.Rows[n]["friend_list_name"].ToString()!="")
					{
					model.friend_list_name=dt.Rows[n]["friend_list_name"].ToString();
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

