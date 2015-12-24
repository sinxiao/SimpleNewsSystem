using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// twitter_comment
	/// </summary>
	public partial class Twitter_commentManager
	{
		private readonly WoeMobile.DAL.twitter_comment dal=new WoeMobile.DAL.twitter_comment();
		public Twitter_commentManager()
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
		public bool Exists(int idtwitter_comment)
		{
			return dal.Exists(idtwitter_comment);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.twitter_comment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.twitter_comment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idtwitter_comment)
		{
			
			return dal.Delete(idtwitter_comment);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idtwitter_commentlist )
		{
			return dal.DeleteList(idtwitter_commentlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.twitter_comment GetModel(int idtwitter_comment)
		{
			
			return dal.GetModel(idtwitter_comment);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.twitter_comment GetModelByCache(int idtwitter_comment)
		{
			
			string CacheKey = "twitter_commentModel-" + idtwitter_comment;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idtwitter_comment);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.twitter_comment)objModel;
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
		public List<WoeMobile.Model.twitter_comment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.twitter_comment> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.twitter_comment> modelList = new List<WoeMobile.Model.twitter_comment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.twitter_comment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.twitter_comment();
					if(dt.Rows[n]["idtwitter_comment"]!=null && dt.Rows[n]["idtwitter_comment"].ToString()!="")
					{
						model.idtwitter_comment=int.Parse(dt.Rows[n]["idtwitter_comment"].ToString());
					}
					if(dt.Rows[n]["twitter_id"]!=null && dt.Rows[n]["twitter_id"].ToString()!="")
					{
						model.twitter_id=int.Parse(dt.Rows[n]["twitter_id"].ToString());
					}
					if(dt.Rows[n]["comment"]!=null && dt.Rows[n]["comment"].ToString()!="")
					{
					model.comment=dt.Rows[n]["comment"].ToString();
					}
					if(dt.Rows[n]["uuser_id"]!=null && dt.Rows[n]["uuser_id"].ToString()!="")
					{
						model.uuser_id=int.Parse(dt.Rows[n]["uuser_id"].ToString());
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

