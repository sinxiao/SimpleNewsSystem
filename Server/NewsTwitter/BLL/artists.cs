using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// artists
	/// </summary>
	public partial class ArtistsManager
	{
		private readonly WoeMobile.DAL.artists dal=new WoeMobile.DAL.artists();
		public ArtistsManager()
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
		public bool Exists(int artist_id)
		{
			return dal.Exists(artist_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.artists model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.artists model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int artist_id)
		{
			
			return dal.Delete(artist_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string artist_idlist )
		{
			return dal.DeleteList(artist_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.artists GetModel(int artist_id)
		{
			
			return dal.GetModel(artist_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.artists GetModelByCache(int artist_id)
		{
			
			string CacheKey = "artistsModel-" + artist_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(artist_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.artists)objModel;
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
		public List<WoeMobile.Model.artists> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.artists> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.artists> modelList = new List<WoeMobile.Model.artists>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.artists model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.artists();
					if(dt.Rows[n]["artist_id"]!=null && dt.Rows[n]["artist_id"].ToString()!="")
					{
						model.artist_id=int.Parse(dt.Rows[n]["artist_id"].ToString());
					}
					if(dt.Rows[n]["height"]!=null && dt.Rows[n]["height"].ToString()!="")
					{
						model.height=int.Parse(dt.Rows[n]["height"].ToString());
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["name_eg"]!=null && dt.Rows[n]["name_eg"].ToString()!="")
					{
					model.name_eg=dt.Rows[n]["name_eg"].ToString();
					}
					if(dt.Rows[n]["weight"]!=null && dt.Rows[n]["weight"].ToString()!="")
					{
					model.weight=dt.Rows[n]["weight"].ToString();
					}
					if(dt.Rows[n]["langrange"]!=null && dt.Rows[n]["langrange"].ToString()!="")
					{
					model.langrange=dt.Rows[n]["langrange"].ToString();
					}
					if(dt.Rows[n]["start"]!=null && dt.Rows[n]["start"].ToString()!="")
					{
					model.start=dt.Rows[n]["start"].ToString();
					}
					if(dt.Rows[n]["live_pet"]!=null && dt.Rows[n]["live_pet"].ToString()!="")
					{
					model.live_pet=dt.Rows[n]["live_pet"].ToString();
					}
					if(dt.Rows[n]["blood_type"]!=null && dt.Rows[n]["blood_type"].ToString()!="")
					{
					model.blood_type=dt.Rows[n]["blood_type"].ToString();
					}
					if(dt.Rows[n]["love_to_say"]!=null && dt.Rows[n]["love_to_say"].ToString()!="")
					{
					model.love_to_say=dt.Rows[n]["love_to_say"].ToString();
					}
					if(dt.Rows[n]["job"]!=null && dt.Rows[n]["job"].ToString()!="")
					{
					model.job=dt.Rows[n]["job"].ToString();
					}
					if(dt.Rows[n]["Company"]!=null && dt.Rows[n]["Company"].ToString()!="")
					{
					model.Company=dt.Rows[n]["Company"].ToString();
					}
					if(dt.Rows[n]["best_hobby"]!=null && dt.Rows[n]["best_hobby"].ToString()!="")
					{
					model.best_hobby=dt.Rows[n]["best_hobby"].ToString();
					}
					if(dt.Rows[n]["worst_bobby"]!=null && dt.Rows[n]["worst_bobby"].ToString()!="")
					{
					model.worst_bobby=dt.Rows[n]["worst_bobby"].ToString();
					}
					if(dt.Rows[n]["birth_date"]!=null && dt.Rows[n]["birth_date"].ToString()!="")
					{
					model.birth_date=dt.Rows[n]["birth_date"].ToString();
					}
					if(dt.Rows[n]["best_wish"]!=null && dt.Rows[n]["best_wish"].ToString()!="")
					{
					model.best_wish=dt.Rows[n]["best_wish"].ToString();
					}
					if(dt.Rows[n]["hobby"]!=null && dt.Rows[n]["hobby"].ToString()!="")
					{
					model.hobby=dt.Rows[n]["hobby"].ToString();
					}
					if(dt.Rows[n]["like_color"]!=null && dt.Rows[n]["like_color"].ToString()!="")
					{
					model.like_color=dt.Rows[n]["like_color"].ToString();
					}
					if(dt.Rows[n]["likedrink"]!=null && dt.Rows[n]["likedrink"].ToString()!="")
					{
					model.likedrink=dt.Rows[n]["likedrink"].ToString();
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

