using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
using Maticsoft.DBUtility;
namespace WoeMobile.BLL
{
	/// <summary>
	/// news
	/// </summary>
	public partial class NewsManager
	{
		private readonly WoeMobile.DAL.news dal=new WoeMobile.DAL.news();
		public NewsManager()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}
        public List<Model.news> GetNewsByItem(int nid) 
        {
            return GetModelList(" itemid = "+nid);
        }

        public int GetSizeByItem(int nid)
        {
             List<Model.news> ns = GetNewsByItem(nid);
             int size = 0;
            if(ns!=null)
            {
                size = ns.Count;
            }
            
            return size;
        }
        public int ExecuteSql(String sql) {
            return dal.ExecuteSql(sql);
        }
        public String QuerySql(String sql) 
        {
            return DbHelperMySQL.Query(sql).GetXml();
        }
        public List<Model.news> GetNewsByItemAndPage(int nid,int page ,int size )
        {
            return GetModelList(" itemid = " + nid+" limit "+(page-1)*size+" , "+size);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int idnews)
		{
			return dal.Exists(idnews);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.news model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.news model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idnews)
		{
			
			return dal.Delete(idnews);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idnewslist )
		{
			return dal.DeleteList(idnewslist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.news GetModel(int idnews)
		{
			
			return dal.GetModel(idnews);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.news GetModelByCache(int idnews)
		{
			
			string CacheKey = "newsModel-" + idnews;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idnews);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.news)objModel;
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
		public List<WoeMobile.Model.news> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.news> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.news> modelList = new List<WoeMobile.Model.news>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.news model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.news();
					if(dt.Rows[n]["idnews"]!=null && dt.Rows[n]["idnews"].ToString()!="")
					{
						model.idnews=int.Parse(dt.Rows[n]["idnews"].ToString());
					}
					if(dt.Rows[n]["intro"]!=null && dt.Rows[n]["intro"].ToString()!="")
					{
					model.intro=dt.Rows[n]["intro"].ToString();
					}
					if(dt.Rows[n]["gen_time"]!=null && dt.Rows[n]["gen_time"].ToString()!="")
					{
						model.gen_time=DateTime.Parse(dt.Rows[n]["gen_time"].ToString());
					}
					if(dt.Rows[n]["writer"]!=null && dt.Rows[n]["writer"].ToString()!="")
					{
						model.writer=int.Parse(dt.Rows[n]["writer"].ToString());
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
					}
					if(dt.Rows[n]["itemid"]!=null && dt.Rows[n]["itemid"].ToString()!="")
					{
						model.itemid=int.Parse(dt.Rows[n]["itemid"].ToString());
					}
					if(dt.Rows[n]["passcheked"]!=null && dt.Rows[n]["passcheked"].ToString()!="")
					{
						model.passcheked=int.Parse(dt.Rows[n]["passcheked"].ToString());
					}
					if(dt.Rows[n]["keyword"]!=null && dt.Rows[n]["keyword"].ToString()!="")
					{
						model.keyword=(dt.Rows[n]["keyword"].ToString());
					}
					if(dt.Rows[n]["default_news"]!=null && dt.Rows[n]["default_news"].ToString()!="")
					{
						model.default_news=int.Parse(dt.Rows[n]["default_news"].ToString());
					}
					if(dt.Rows[n]["clicked"]!=null && dt.Rows[n]["clicked"].ToString()!="")
					{
						model.clicked=int.Parse(dt.Rows[n]["clicked"].ToString());
					}
					if(dt.Rows[n]["news_url"]!=null && dt.Rows[n]["news_url"].ToString()!="")
					{
					model.news_url=dt.Rows[n]["news_url"].ToString();
					}
					if(dt.Rows[n]["image_url"]!=null && dt.Rows[n]["image_url"].ToString()!="")
					{
					model.image_url=dt.Rows[n]["image_url"].ToString();
					}
					if(dt.Rows[n]["comment_sum"]!=null && dt.Rows[n]["comment_sum"].ToString()!="")
					{
						model.comment_sum=int.Parse(dt.Rows[n]["comment_sum"].ToString());
					}
                    if (dt.Rows[n]["verify"] != null && dt.Rows[n]["verify"].ToString() != "")
                    {
                        model.Verify = int.Parse(dt.Rows[n]["verify"].ToString());
                    }
                    if (dt.Rows[n]["verify_id"] != null && dt.Rows[n]["verify_id"].ToString() != "")
                    {
                        model.Verify_id = int.Parse(dt.Rows[n]["verify_id"].ToString());
                    }
                    if (dt.Rows[n]["verify_date"] != null && dt.Rows[n]["verify_date"].ToString() != "")
                    {
                        model.Verify_date = DateTime.Parse(dt.Rows[n]["verify_date"].ToString());
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
        public List<Model.news> getNewsByItemAndStatus(int itemId, int status)
        {
            if(status==2)//显示全部新闻
            {
                return GetModelList("itemid = " + itemId);
            }
            return GetModelList("itemid = " + itemId + " and verify = " + status);
        }
        public List<Model.news> getNewsByKeyWord(String keyword)
        {
            return GetModelList(" title like '%" + keyword + "%' or content like '%" + keyword + "%' or keyword like '%" + keyword + "%'");
        }

		



        public List<news> getNewsByMidStatus(int mid, int tid)
        {
            return GetModelList(" writer = "+mid +" and verify = "+tid);
        }

        #endregion  Method
    }
}

