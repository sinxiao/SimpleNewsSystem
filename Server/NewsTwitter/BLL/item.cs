using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// item
	/// </summary>
	public partial class ItemManager
	{
		private readonly WoeMobile.DAL.item dal=new WoeMobile.DAL.item();
		public ItemManager()
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
		public bool Exists(int iditem)
		{
			return dal.Exists(iditem);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.item model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.item model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int iditem)
		{
			
			return dal.Delete(iditem);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string iditemlist )
		{
			return dal.DeleteList(iditemlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.item GetModel(int iditem)
		{
			
			return dal.GetModel(iditem);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.item GetModelByCache(int iditem)
		{
			
			string CacheKey = "itemModel-" + iditem;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(iditem);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.item)objModel;
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
		public List<WoeMobile.Model.item> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.item> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.item> modelList = new List<WoeMobile.Model.item>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.item model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.item();
					if(dt.Rows[n]["iditem"]!=null && dt.Rows[n]["iditem"].ToString()!="")
					{
						model.iditem=int.Parse(dt.Rows[n]["iditem"].ToString());
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["ename"]!=null && dt.Rows[n]["ename"].ToString()!="")
					{
					model.ename=dt.Rows[n]["ename"].ToString();
					}
					if(dt.Rows[n]["showathome"]!=null && dt.Rows[n]["showathome"].ToString()!="")
					{
						model.showathome=int.Parse(dt.Rows[n]["showathome"].ToString());
					}
					if(dt.Rows[n]["item_parent"]!=null && dt.Rows[n]["item_parent"].ToString()!="")
					{
						model.item_parent=int.Parse(dt.Rows[n]["item_parent"].ToString());
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

        public List<Model.item> getParentItem()
        {
            List<Model.item> lt = GetModelList(" item_parent is null ");

            return lt;
        }

        public List<Model.item> getItemByParent(int parent)
        {
            List<Model.item> lt = GetModelList(" item_parent =" + parent);

            return lt;
        }


        public Model.item GetItemByName(string name)
        {
            return GetModelList(" name = '"+name+"' or ename = "+name)[0];
        }
    }
}

