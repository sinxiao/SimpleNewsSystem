using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using WoeMobile.Model;
namespace WoeMobile.BLL
{
	/// <summary>
	/// euser
	/// </summary>
	public partial class EuserManager
	{
		protected readonly WoeMobile.DAL.euser dal=new WoeMobile.DAL.euser();
		public EuserManager()
		{}
        private Configer configer;

        public Configer Configer
        {
            get { return configer; }
            set { configer = value; }
        }
        
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
		public bool Exists(int uid)
		{
			return dal.Exists(uid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(WoeMobile.Model.euser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(WoeMobile.Model.euser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int uid)
		{
			
			return dal.Delete(uid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string uidlist )
		{
			return dal.DeleteList(uidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WoeMobile.Model.euser GetModel(int uid)
		{
			
			return dal.GetModel(uid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public WoeMobile.Model.euser GetModelByCache(int uid)
		{
			
			string CacheKey = "euserModel-" + uid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(uid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WoeMobile.Model.euser)objModel;
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
		public List<WoeMobile.Model.euser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WoeMobile.Model.euser> DataTableToList(DataTable dt)
		{
			List<WoeMobile.Model.euser> modelList = new List<WoeMobile.Model.euser>();
            Euser_detailManager edetail = new Euser_detailManager();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				WoeMobile.Model.euser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WoeMobile.Model.euser();
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
						model.uid=int.Parse(dt.Rows[n]["uid"].ToString());
					}
					if(dt.Rows[n]["in_email"]!=null && dt.Rows[n]["in_email"].ToString()!="")
					{
					model.in_email=dt.Rows[n]["in_email"].ToString();
					}
					if(dt.Rows[n]["in_pwd"]!=null && dt.Rows[n]["in_pwd"].ToString()!="")
					{
					model.in_pwd=dt.Rows[n]["in_pwd"].ToString();
					}
					if(dt.Rows[n]["nick_name"]!=null && dt.Rows[n]["nick_name"].ToString()!="")
					{
					model.nick_name=dt.Rows[n]["nick_name"].ToString();
					}
                    model.User_detail = edetail.GetDetailByUserId(model.uid);
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

