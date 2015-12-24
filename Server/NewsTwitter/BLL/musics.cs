using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// musics
	/// </summary>
	public partial class MusicsManager
	{
		private readonly WoeMobile.DAL.musics dal=new WoeMobile.DAL.musics();
		public MusicsManager()
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
		public bool Exists(int music_id)
		{
			return dal.Exists(music_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.musics model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.musics model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int music_id)
		{
			
			return dal.Delete(music_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string music_idlist )
		{
			return dal.DeleteList(music_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.musics GetModel(int music_id)
		{
			
			return dal.GetModel(music_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.musics GetModelByCache(int music_id)
		{
			
			string CacheKey = "musicsModel-" + music_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(music_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.musics)objModel;
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
		public List<WoeMobile.Model.musics> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.musics> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.musics> modelList = new List<WoeMobile.Model.musics>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.musics model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.musics();
					if(dt.Rows[n]["music_id"]!=null && dt.Rows[n]["music_id"].ToString()!="")
					{
						model.music_id=int.Parse(dt.Rows[n]["music_id"].ToString());
					}
					if(dt.Rows[n]["music_name"]!=null && dt.Rows[n]["music_name"].ToString()!="")
					{
					model.music_name=dt.Rows[n]["music_name"].ToString();
					}
					if(dt.Rows[n]["abum_id"]!=null && dt.Rows[n]["abum_id"].ToString()!="")
					{
						model.abum_id=int.Parse(dt.Rows[n]["abum_id"].ToString());
					}
					if(dt.Rows[n]["duration"]!=null && dt.Rows[n]["duration"].ToString()!="")
					{
					model.duration=dt.Rows[n]["duration"].ToString();
					}
					if(dt.Rows[n]["src"]!=null && dt.Rows[n]["src"].ToString()!="")
					{
					model.src=dt.Rows[n]["src"].ToString();
					}
					if(dt.Rows[n]["lrc_src"]!=null && dt.Rows[n]["lrc_src"].ToString()!="")
					{
					model.lrc_src=dt.Rows[n]["lrc_src"].ToString();
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

