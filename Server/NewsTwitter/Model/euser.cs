using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// euser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class euser
	{
		public euser()
		{}
		#region Model
		private int _uid;
		private string _in_email;
		private string _in_pwd;
		private string _nick_name;
        private euser_detail user_detail;

        public euser_detail User_detail
        {
            get { return user_detail; }
            set { user_detail = value; }
        }
		/// <summary>
		/// auto_increment
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string in_email
		{
			set{ _in_email=value;}
			get{return _in_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string in_pwd
		{
			set{ _in_pwd=value;}
			get{return _in_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nick_name
		{
			set{ _nick_name=value;}
			get{return _nick_name;}
		}
		#endregion Model

	}
}

