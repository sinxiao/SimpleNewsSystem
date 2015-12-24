using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// template
	/// </summary>
	public partial class TemplateManager
	{
		private readonly WoeMobile.DAL.template dal=new WoeMobile.DAL.template();
		public TemplateManager()
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
		public bool Exists(int idtemplate)
		{
			return dal.Exists(idtemplate);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.template model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.template model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int idtemplate)
		{
			
			return dal.Delete(idtemplate);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idtemplatelist )
		{
			return dal.DeleteList(idtemplatelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.template GetModel(int idtemplate)
		{
			
			return dal.GetModel(idtemplate);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.template GetModelByCache(int idtemplate)
		{
			
			string CacheKey = "templateModel-" + idtemplate;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(idtemplate);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.template)objModel;
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
		public List<WoeMobile.Model.template> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.template> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.template> modelList = new List<WoeMobile.Model.template>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.template model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.template();
					if(dt.Rows[n]["idtemplate"]!=null && dt.Rows[n]["idtemplate"].ToString()!="")
					{
						model.idtemplate=int.Parse(dt.Rows[n]["idtemplate"].ToString());
					}
					if(dt.Rows[n]["name"]!=null && dt.Rows[n]["name"].ToString()!="")
					{
					model.name=dt.Rows[n]["name"].ToString();
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
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

