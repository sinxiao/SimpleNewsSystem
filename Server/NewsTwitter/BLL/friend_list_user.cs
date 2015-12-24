using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// friend_list_user
	/// </summary>
	public partial class Friend_list_userManager
	{
		private readonly WoeMobile.DAL.friend_list_user dal=new WoeMobile.DAL.friend_list_user();
		public Friend_list_userManager()
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
		public bool Exists(int idfriend_list_user)
		{
			return dal.Exists(idfriend_list_user);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.friend_list_user model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.friend_list_user model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idfriend_list_user)
		{
			
			return dal.Delete(idfriend_list_user);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idfriend_list_userlist )
		{
			return dal.DeleteList(idfriend_list_userlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.friend_list_user GetModel(int idfriend_list_user)
		{
			
			return dal.GetModel(idfriend_list_user);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.friend_list_user GetModelByCache(int idfriend_list_user)
		{
			
			string CacheKey = "friend_list_userModel-" + idfriend_list_user;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idfriend_list_user);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.friend_list_user)objModel;
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
		public List<WoeMobile.Model.friend_list_user> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.friend_list_user> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.friend_list_user> modelList = new List<WoeMobile.Model.friend_list_user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.friend_list_user model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.friend_list_user();
					if(dt.Rows[n]["idfriend_list_user"]!=null && dt.Rows[n]["idfriend_list_user"].ToString()!="")
					{
						model.idfriend_list_user=int.Parse(dt.Rows[n]["idfriend_list_user"].ToString());
					}
					if(dt.Rows[n]["group_id"]!=null && dt.Rows[n]["group_id"].ToString()!="")
					{
						model.group_id=int.Parse(dt.Rows[n]["group_id"].ToString());
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["back_name"]!=null && dt.Rows[n]["back_name"].ToString()!="")
					{
					model.back_name=dt.Rows[n]["back_name"].ToString();
					}
					if(dt.Rows[n]["friend_list_id"]!=null && dt.Rows[n]["friend_list_id"].ToString()!="")
					{
						model.friend_list_id=int.Parse(dt.Rows[n]["friend_list_id"].ToString());
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

