using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// information
	/// </summary>
	public partial class InformationManager
	{
		private readonly WoeMobile.DAL.information dal=new WoeMobile.DAL.information();
		public InformationManager()
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
		public bool Exists(int idinformation)
		{
			return dal.Exists(idinformation);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.information model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.information model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idinformation)
		{
			
			return dal.Delete(idinformation);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idinformationlist )
		{
			return dal.DeleteList(idinformationlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.information GetModel(int idinformation)
		{
			
			return dal.GetModel(idinformation);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.information GetModelByCache(int idinformation)
		{
			
			string CacheKey = "informationModel-" + idinformation;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idinformation);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.information)objModel;
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
		public List<WoeMobile.Model.information> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.information> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.information> modelList = new List<WoeMobile.Model.information>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.information model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.information();
					if(dt.Rows[n]["idinformation"]!=null && dt.Rows[n]["idinformation"].ToString()!="")
					{
						model.idinformation=int.Parse(dt.Rows[n]["idinformation"].ToString());
					}
					if(dt.Rows[n]["from_id"]!=null && dt.Rows[n]["from_id"].ToString()!="")
					{
						model.from_id=int.Parse(dt.Rows[n]["from_id"].ToString());
					}
					if(dt.Rows[n]["to_id"]!=null && dt.Rows[n]["to_id"].ToString()!="")
					{
						model.to_id=int.Parse(dt.Rows[n]["to_id"].ToString());
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
					}
					if(dt.Rows[n]["readed"]!=null && dt.Rows[n]["readed"].ToString()!="")
					{
						model.readed=int.Parse(dt.Rows[n]["readed"].ToString());
					}
					if(dt.Rows[n]["gen_time"]!=null && dt.Rows[n]["gen_time"].ToString()!="")
					{
						model.gen_time=DateTime.Parse(dt.Rows[n]["gen_time"].ToString());
					}
					if(dt.Rows[n]["infor_type"]!=null && dt.Rows[n]["infor_type"].ToString()!="")
					{
						model.infor_type=int.Parse(dt.Rows[n]["infor_type"].ToString());
					}
					if(dt.Rows[n]["manager_id"]!=null && dt.Rows[n]["manager_id"].ToString()!="")
					{
						model.manager_id=int.Parse(dt.Rows[n]["manager_id"].ToString());
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

