using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// twitter
	/// </summary>
	public partial class TwitterManager
	{
		private readonly WoeMobile.DAL.twitter dal=new WoeMobile.DAL.twitter();
		public TwitterManager()
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
		public bool Exists(int twitter_id)
		{
			return dal.Exists(twitter_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.twitter model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int twitter_id)
		{
			
			return dal.Delete(twitter_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string twitter_idlist )
		{
			return dal.DeleteList(twitter_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.twitter GetModel(int twitter_id)
		{
			
			return dal.GetModel(twitter_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.twitter GetModelByCache(int twitter_id)
		{
			
			string CacheKey = "twitterModel-" + twitter_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(twitter_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.twitter)objModel;
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
		public List<WoeMobile.Model.twitter> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.twitter> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.twitter> modelList = new List<WoeMobile.Model.twitter>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.twitter model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.twitter();
					if(dt.Rows[n]["datatime"]!=null && dt.Rows[n]["datatime"].ToString()!="")
					{
					model.datatime=dt.Rows[n]["datatime"].ToString();
					}
					if(dt.Rows[n]["detial"]!=null && dt.Rows[n]["detial"].ToString()!="")
					{
					model.detial=dt.Rows[n]["detial"].ToString();
					}
					if(dt.Rows[n]["ower_id_twitter"]!=null && dt.Rows[n]["ower_id_twitter"].ToString()!="")
					{
						model.ower_id_twitter=int.Parse(dt.Rows[n]["ower_id_twitter"].ToString());
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["tw_type"]!=null && dt.Rows[n]["tw_type"].ToString()!="")
					{
						model.tw_type=int.Parse(dt.Rows[n]["tw_type"].ToString());
					}
					if(dt.Rows[n]["target_id"]!=null && dt.Rows[n]["target_id"].ToString()!="")
					{
						model.target_id=int.Parse(dt.Rows[n]["target_id"].ToString());
					}
					if(dt.Rows[n]["target_type"]!=null && dt.Rows[n]["target_type"].ToString()!="")
					{
						model.target_type=int.Parse(dt.Rows[n]["target_type"].ToString());
					}
					if(dt.Rows[n]["twitter_id"]!=null && dt.Rows[n]["twitter_id"].ToString()!="")
					{
						model.twitter_id=int.Parse(dt.Rows[n]["twitter_id"].ToString());
					}
					if(dt.Rows[n]["pinglun_sum"]!=null && dt.Rows[n]["pinglun_sum"].ToString()!="")
					{
						model.pinglun_sum=int.Parse(dt.Rows[n]["pinglun_sum"].ToString());
					}
					if(dt.Rows[n]["zhuangfa_sum"]!=null && dt.Rows[n]["zhuangfa_sum"].ToString()!="")
					{
						model.zhuangfa_sum=int.Parse(dt.Rows[n]["zhuangfa_sum"].ToString());
					}
					if(dt.Rows[n]["topic"]!=null && dt.Rows[n]["topic"].ToString()!="")
					{
					model.topic=dt.Rows[n]["topic"].ToString();
					}
					if(dt.Rows[n]["linked"]!=null && dt.Rows[n]["linked"].ToString()!="")
					{
					model.linked=dt.Rows[n]["linked"].ToString();
					}
					if(dt.Rows[n]["love_sum"]!=null && dt.Rows[n]["love_sum"].ToString()!="")
					{
						model.love_sum=int.Parse(dt.Rows[n]["love_sum"].ToString());
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

