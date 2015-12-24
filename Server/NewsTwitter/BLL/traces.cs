using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// traces
	/// </summary>
	public partial class TracesManager
	{
		private readonly WoeMobile.DAL.traces dal=new WoeMobile.DAL.traces();
		public TracesManager()
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
		public bool Exists(int idtraces)
		{
			return dal.Exists(idtraces);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.traces model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.traces model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idtraces)
		{
			
			return dal.Delete(idtraces);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idtraceslist )
		{
			return dal.DeleteList(idtraceslist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.traces GetModel(int idtraces)
		{
			
			return dal.GetModel(idtraces);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.traces GetModelByCache(int idtraces)
		{
			
			string CacheKey = "tracesModel-" + idtraces;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idtraces);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.traces)objModel;
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
		public List<WoeMobile.Model.traces> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.traces> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.traces> modelList = new List<WoeMobile.Model.traces>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.traces model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.traces();
					if(dt.Rows[n]["idtraces"]!=null && dt.Rows[n]["idtraces"].ToString()!="")
					{
						model.idtraces=int.Parse(dt.Rows[n]["idtraces"].ToString());
					}
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["trace_name"]!=null && dt.Rows[n]["trace_name"].ToString()!="")
					{
					model.trace_name=dt.Rows[n]["trace_name"].ToString();
					}
					if(dt.Rows[n]["build_time"]!=null && dt.Rows[n]["build_time"].ToString()!="")
					{
					model.build_time=dt.Rows[n]["build_time"].ToString();
					}
					if(dt.Rows[n]["end_time"]!=null && dt.Rows[n]["end_time"].ToString()!="")
					{
					model.end_time=dt.Rows[n]["end_time"].ToString();
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

