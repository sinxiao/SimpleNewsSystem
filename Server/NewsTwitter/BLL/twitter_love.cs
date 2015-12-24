using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// twitter_love
	/// </summary>
	public partial class Twitter_loveManager
	{
		private readonly WoeMobile.DAL.twitter_love dal=new WoeMobile.DAL.twitter_love();
		public Twitter_loveManager()
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
		public bool Exists(int idtwitter_love)
		{
			return dal.Exists(idtwitter_love);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter_love model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.twitter_love model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idtwitter_love)
		{
			
			return dal.Delete(idtwitter_love);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idtwitter_lovelist )
		{
			return dal.DeleteList(idtwitter_lovelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.twitter_love GetModel(int idtwitter_love)
		{
			
			return dal.GetModel(idtwitter_love);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.twitter_love GetModelByCache(int idtwitter_love)
		{
			
			string CacheKey = "twitter_loveModel-" + idtwitter_love;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idtwitter_love);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.twitter_love)objModel;
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
		public List<WoeMobile.Model.twitter_love> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.twitter_love> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.twitter_love> modelList = new List<WoeMobile.Model.twitter_love>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.twitter_love model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.twitter_love();
					if(dt.Rows[n]["idtwitter_love"]!=null && dt.Rows[n]["idtwitter_love"].ToString()!="")
					{
						model.idtwitter_love=int.Parse(dt.Rows[n]["idtwitter_love"].ToString());
					}
					if(dt.Rows[n]["twitter_id"]!=null && dt.Rows[n]["twitter_id"].ToString()!="")
					{
						model.twitter_id=int.Parse(dt.Rows[n]["twitter_id"].ToString());
					}
					if(dt.Rows[n]["euser_id"]!=null && dt.Rows[n]["euser_id"].ToString()!="")
					{
						model.euser_id=int.Parse(dt.Rows[n]["euser_id"].ToString());
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
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

