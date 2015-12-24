using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// locations
	/// </summary>
	public partial class LocationsManager
	{
		private readonly WoeMobile.DAL.locations dal=new WoeMobile.DAL.locations();
		public LocationsManager()
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
		public bool Exists(int idlocations)
		{
			return dal.Exists(idlocations);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.locations model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.locations model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idlocations)
		{
			
			return dal.Delete(idlocations);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlocationslist )
		{
			return dal.DeleteList(idlocationslist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.locations GetModel(int idlocations)
		{
			
			return dal.GetModel(idlocations);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.locations GetModelByCache(int idlocations)
		{
			
			string CacheKey = "locationsModel-" + idlocations;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idlocations);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.locations)objModel;
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
		public List<WoeMobile.Model.locations> GetModelList(string strWhere)
		{
			DataSet dt = dal.GetList(strWhere);
			return DataTableToList(dt.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.locations> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.locations> modelList = new List<WoeMobile.Model.locations>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.locations model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.locations();
					if(dt.Rows[n]["idlocations"]!=null && dt.Rows[n]["idlocations"].ToString()!="")
					{
						model.idlocations=int.Parse(dt.Rows[n]["idlocations"].ToString());
					}
					if(dt.Rows[n]["longitude"]!=null && dt.Rows[n]["longitude"].ToString()!="")
					{
					model.longitude=dt.Rows[n]["longitude"].ToString();
					}
					if(dt.Rows[n]["latitude"]!=null && dt.Rows[n]["latitude"].ToString()!="")
					{
					model.latitude=dt.Rows[n]["latitude"].ToString();
					}
					if(dt.Rows[n]["datetime"]!=null && dt.Rows[n]["datetime"].ToString()!="")
					{
					model.datetime=dt.Rows[n]["datetime"].ToString();
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["trace_id"]!=null && dt.Rows[n]["trace_id"].ToString()!="")
					{
						model.trace_id=int.Parse(dt.Rows[n]["trace_id"].ToString());
					}

                    if (dt.Rows[0]["demo"] != null && dt.Rows[0]["demo"].ToString() != "")
                    {
                        model.Demo = dt.Rows[0]["demo"].ToString();
                    }
                    if (dt.Rows[0]["data1"] != null && dt.Rows[0]["data1"].ToString() != "")
                    {
                        model.Data1 = dt.Rows[0]["latitude"].ToString();
                    }
                    if (dt.Rows[0]["data2"] != null && dt.Rows[0]["data2"].ToString() != "")
                    {
                        model.Data2 = dt.Rows[0]["data2"].ToString();
                    }
                    if (dt.Rows[0]["lname"] != null && dt.Rows[0]["lname"].ToString() != "")
                    {
                        model.Lname = dt.Rows[0]["lname"].ToString();
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

