using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// news_comment
	/// </summary>
	public partial class News_commentManager
	{
		private readonly WoeMobile.DAL.news_comment dal=new WoeMobile.DAL.news_comment();
		public News_commentManager()
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
		public bool Exists(int idnews_comment)
		{
			return dal.Exists(idnews_comment);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.news_comment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.news_comment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idnews_comment)
		{
			
			return dal.Delete(idnews_comment);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idnews_commentlist )
		{
			return dal.DeleteList(idnews_commentlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.news_comment GetModel(int idnews_comment)
		{
			
			return dal.GetModel(idnews_comment);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.news_comment GetModelByCache(int idnews_comment)
		{
			
			string CacheKey = "news_commentModel-" + idnews_comment;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idnews_comment);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.news_comment)objModel;
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
		public List<WoeMobile.Model.news_comment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.news_comment> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.news_comment> modelList = new List<WoeMobile.Model.news_comment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.news_comment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.news_comment();
					if(dt.Rows[n]["idnews_comment"]!=null && dt.Rows[n]["idnews_comment"].ToString()!="")
					{
						model.idnews_comment=int.Parse(dt.Rows[n]["idnews_comment"].ToString());
					}
					if(dt.Rows[n]["comment_name"]!=null && dt.Rows[n]["comment_name"].ToString()!="")
					{
					model.comment_name=dt.Rows[n]["comment_name"].ToString();
					}
					if(dt.Rows[n]["email"]!=null && dt.Rows[n]["email"].ToString()!="")
					{
					model.email=dt.Rows[n]["email"].ToString();
					}
					if(dt.Rows[n]["user_id"]!=null && dt.Rows[n]["user_id"].ToString()!="")
					{
						model.user_id=int.Parse(dt.Rows[n]["user_id"].ToString());
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
					}
					if(dt.Rows[n]["gen_time"]!=null && dt.Rows[n]["gen_time"].ToString()!="")
					{
						model.gen_time=DateTime.Parse(dt.Rows[n]["gen_time"].ToString());
					}
					if(dt.Rows[n]["news_id"]!=null && dt.Rows[n]["news_id"].ToString()!="")
					{
						model.news_id=int.Parse(dt.Rows[n]["news_id"].ToString());
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
        public List<Model.news_comment> GetCommentByNewsId(int newsId) 
        {
            return GetModelList(" news_id = "+newsId);
        }
		#endregion  Method
        /***
         * get comment by page 
         * page begin from 1 
         */
        public List<Model.news_comment> GetCommentByItemAndPage(int nid, int page, int size)
        {
            return GetModelList(" news_id = " + nid + " limit " + (page - 1) * size + " , " + size );
        }

        /***
         * get comment by page 
         * page begin from 1 
         */
        public List<Model.news_comment> GetCommentByItemAndPage(int nid, int page, int size,String whr)
        {
            return GetModelList(" news_id = " + nid + " and "+whr+" limit " + (page - 1) * size + " , " + size);
        }
    }
}

