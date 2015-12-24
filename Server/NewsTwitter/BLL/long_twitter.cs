using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// long_twitter
	/// </summary>
	public partial class Long_twitterManager
	{
		private readonly WoeMobile.DAL.long_twitter dal=new WoeMobile.DAL.long_twitter();
		public Long_twitterManager()
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
		public bool Exists(int idtwitter_demo)
		{
			return dal.Exists(idtwitter_demo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.long_twitter model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.long_twitter model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idtwitter_demo)
		{
			
			return dal.Delete(idtwitter_demo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idtwitter_demolist )
		{
			return dal.DeleteList(idtwitter_demolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.long_twitter GetModel(int idtwitter_demo)
		{
			
			return dal.GetModel(idtwitter_demo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.long_twitter GetModelByCache(int idtwitter_demo)
		{
			
			string CacheKey = "long_twitterModel-" + idtwitter_demo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idtwitter_demo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.long_twitter)objModel;
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
		public List<WoeMobile.Model.long_twitter> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.long_twitter> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.long_twitter> modelList = new List<WoeMobile.Model.long_twitter>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.long_twitter model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.long_twitter();
					if(dt.Rows[n]["idtwitter_demo"]!=null && dt.Rows[n]["idtwitter_demo"].ToString()!="")
					{
						model.idtwitter_demo=int.Parse(dt.Rows[n]["idtwitter_demo"].ToString());
					}
					if(dt.Rows[n]["blog"]!=null && dt.Rows[n]["blog"].ToString()!="")
					{
					model.blog=dt.Rows[n]["blog"].ToString();
					}
					if(dt.Rows[n]["images"]!=null && dt.Rows[n]["images"].ToString()!="")
					{
					model.images=dt.Rows[n]["images"].ToString();
					}
					if(dt.Rows[n]["twitter_id"]!=null && dt.Rows[n]["twitter_id"].ToString()!="")
					{
						model.twitter_id=int.Parse(dt.Rows[n]["twitter_id"].ToString());
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
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

