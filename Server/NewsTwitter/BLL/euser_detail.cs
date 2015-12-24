using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// euser_detail
	/// </summary>
	public partial class Euser_detailManager
	{
		private readonly WoeMobile.DAL.euser_detail dal=new WoeMobile.DAL.euser_detail();
		public Euser_detailManager()
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
		public bool Exists(int id_User_detail)
		{
			return dal.Exists(id_User_detail);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.euser_detail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.euser_detail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id_User_detail)
		{
			
			return dal.Delete(id_User_detail);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string id_User_detaillist )
		{
			return dal.DeleteList(id_User_detaillist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.euser_detail GetModel(int id_User_detail)
		{
			
			return dal.GetModel(id_User_detail);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.euser_detail GetModelByCache(int id_User_detail)
		{
			
			string CacheKey = "euser_detailModel-" + id_User_detail;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id_User_detail);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.euser_detail)objModel;
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
		public List<WoeMobile.Model.euser_detail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.euser_detail> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.euser_detail> modelList = new List<WoeMobile.Model.euser_detail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.euser_detail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.euser_detail();
					if(dt.Rows[n]["id_User_detail"]!=null && dt.Rows[n]["id_User_detail"].ToString()!="")
					{
						model.id_User_detail=int.Parse(dt.Rows[n]["id_User_detail"].ToString());
					}
					if(dt.Rows[n]["user_id"]!=null && dt.Rows[n]["user_id"].ToString()!="")
					{
						model.user_id=int.Parse(dt.Rows[n]["user_id"].ToString());
					}
					if(dt.Rows[n]["qq_no"]!=null && dt.Rows[n]["qq_no"].ToString()!="")
					{
					model.qq_no=dt.Rows[n]["qq_no"].ToString();
					}
					if(dt.Rows[n]["imei"]!=null && dt.Rows[n]["imei"].ToString()!="")
					{
					model.imei=dt.Rows[n]["imei"].ToString();
					}
					if(dt.Rows[n]["cell_phone_no"]!=null && dt.Rows[n]["cell_phone_no"].ToString()!="")
					{
					model.cell_phone_no=dt.Rows[n]["cell_phone_no"].ToString();
					}
					if(dt.Rows[n]["contact"]!=null && dt.Rows[n]["contact"].ToString()!="")
					{
						model.contact=int.Parse(dt.Rows[n]["contact"].ToString());
					}
					if(dt.Rows[n]["location"]!=null && dt.Rows[n]["location"].ToString()!="")
					{
						model.location=int.Parse(dt.Rows[n]["location"].ToString());
					}
					if(dt.Rows[n]["gender"]!=null && dt.Rows[n]["gender"].ToString()!="")
					{
						model.gender=int.Parse(dt.Rows[n]["gender"].ToString());
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
        public WoeMobile.Model.euser_detail GetDetailByUserId(int uid)
        {
            List<WoeMobile.Model.euser_detail> lt = GetModelList("user_id = "+uid);
            if(lt!=null&&lt.Count>=1)
            {
                return lt[0];
            }
            return null;
        }
		#endregion  Method
	}
}

