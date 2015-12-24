using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// albums
	/// </summary>
	public partial class AlbumsManager
	{
		private readonly WoeMobile.DAL.albums dal=new WoeMobile.DAL.albums();
		public AlbumsManager()
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
		public bool Exists(int album_id)
		{
			return dal.Exists(album_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.albums model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.albums model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int album_id)
		{
			
			return dal.Delete(album_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string album_idlist )
		{
			return dal.DeleteList(album_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.albums GetModel(int album_id)
		{
			
			return dal.GetModel(album_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.albums GetModelByCache(int album_id)
		{
			
			string CacheKey = "albumsModel-" + album_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(album_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.albums)objModel;
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
		public List<WoeMobile.Model.albums> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.albums> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.albums> modelList = new List<WoeMobile.Model.albums>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.albums model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.albums();
					if(dt.Rows[n]["album_id"]!=null && dt.Rows[n]["album_id"].ToString()!="")
					{
						model.album_id=int.Parse(dt.Rows[n]["album_id"].ToString());
					}
					if(dt.Rows[n]["name_eg"]!=null && dt.Rows[n]["name_eg"].ToString()!="")
					{
					model.name_eg=dt.Rows[n]["name_eg"].ToString();
					}
					if(dt.Rows[n]["name_ch"]!=null && dt.Rows[n]["name_ch"].ToString()!="")
					{
					model.name_ch=dt.Rows[n]["name_ch"].ToString();
					}
					if(dt.Rows[n]["artist_id"]!=null && dt.Rows[n]["artist_id"].ToString()!="")
					{
						model.artist_id=int.Parse(dt.Rows[n]["artist_id"].ToString());
					}
					if(dt.Rows[n]["pub_date"]!=null && dt.Rows[n]["pub_date"].ToString()!="")
					{
					model.pub_date=dt.Rows[n]["pub_date"].ToString();
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

