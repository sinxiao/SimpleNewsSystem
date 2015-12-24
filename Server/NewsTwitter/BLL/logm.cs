using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// logm
	/// </summary>
	public partial class LogmManager
	{
		private readonly WoeMobile.DAL.logm dal=new WoeMobile.DAL.logm();
		public LogmManager()
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
		public bool Exists(int idLogM)
		{
			return dal.Exists(idLogM);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.logm model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.logm model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idLogM)
		{
			
			return dal.Delete(idLogM);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idLogMlist )
		{
			return dal.DeleteList(idLogMlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.logm GetModel(int idLogM)
		{
			
			return dal.GetModel(idLogM);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.logm GetModelByCache(int idLogM)
		{
			
			string CacheKey = "logmModel-" + idLogM;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idLogM);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.logm)objModel;
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
		public List<WoeMobile.Model.logm> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.logm> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.logm> modelList = new List<WoeMobile.Model.logm>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.logm model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.logm();
					if(dt.Rows[n]["idLogM"]!=null && dt.Rows[n]["idLogM"].ToString()!="")
					{
						model.idLogM=int.Parse(dt.Rows[n]["idLogM"].ToString());
					}
					if(dt.Rows[n]["op_type"]!=null && dt.Rows[n]["op_type"].ToString()!="")
					{
						model.op_type=int.Parse(dt.Rows[n]["op_type"].ToString());
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
					}
					if(dt.Rows[n]["manger_id"]!=null && dt.Rows[n]["manger_id"].ToString()!="")
					{
						model.manger_id=int.Parse(dt.Rows[n]["manger_id"].ToString());
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

