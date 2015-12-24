using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// images
	/// </summary>
	public partial class ImagesManager
	{
		private readonly WoeMobile.DAL.images dal=new WoeMobile.DAL.images();
		public ImagesManager()
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
		public bool Exists(int image_id)
		{
			return dal.Exists(image_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.images model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.images model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int image_id)
		{
			
			return dal.Delete(image_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string image_idlist )
		{
			return dal.DeleteList(image_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.images GetModel(int image_id)
		{
			
			return dal.GetModel(image_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.images GetModelByCache(int image_id)
		{
			
			string CacheKey = "imagesModel-" + image_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(image_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.images)objModel;
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
		public List<WoeMobile.Model.images> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public List<Model.images> GetImagesByLocationAndPage(int nid, int page, int size)
        {
            return GetModelList(" location_id = " + nid + " limit " + (page - 1) * size + " , " + size);
        }


        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.images> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.images> modelList = new List<WoeMobile.Model.images>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.images model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.images();
					if(dt.Rows[n]["image_id"]!=null && dt.Rows[n]["image_id"].ToString()!="")
					{
						model.image_id=int.Parse(dt.Rows[n]["image_id"].ToString());
					}
					if(dt.Rows[n]["image_src"]!=null && dt.Rows[n]["image_src"].ToString()!="")
					{
					model.image_src=dt.Rows[n]["image_src"].ToString();
					}
					if(dt.Rows[n]["image_owner"]!=null && dt.Rows[n]["image_owner"].ToString()!="")
					{
						model.image_owner=int.Parse(dt.Rows[n]["image_owner"].ToString());
					}
					if(dt.Rows[n]["demo"]!=null && dt.Rows[n]["demo"].ToString()!="")
					{
					model.demo=dt.Rows[n]["demo"].ToString();
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["trace_id"]!=null && dt.Rows[n]["trace_id"].ToString()!="")
					{
						model.trace_id=int.Parse(dt.Rows[n]["trace_id"].ToString());
					}
					if(dt.Rows[n]["location_id"]!=null && dt.Rows[n]["location_id"].ToString()!="")
					{
						model.location_id=int.Parse(dt.Rows[n]["location_id"].ToString());
					}
					if(dt.Rows[n]["bdata"]!=null && dt.Rows[n]["bdata"].ToString()!="")
					{
						model.bdata=(byte[])dt.Rows[n]["bdata"];
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

