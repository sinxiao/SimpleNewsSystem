using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// manager:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class manager
	{
		public manager()
		{}
		#region Model
		private int _idmanager;
		private string _username;
		private string _email;
		private string _pwdword;
		private string _phone;
		private string _qq;
		private int? _to_id;
        private organization organization;

        public organization Organization
        {
            get { return organization; }
            set { organization = value; }
        }

		private string _realname;
		private string _u_code;
		private DateTime? _last_login;
		private int? _login_sum;
		private string _create_time;
		private int? _role_id;
        private role role;

        public role Role
        {
            get { return role; }
            set { role = value; }
        }
		private int? _user_id;
        private euser euser;

        public euser Euser
        {
            get { return euser; }
            set { euser = value; }
        }
		private int? _gender;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idmanager
		{
			set{ _idmanager=value;}
			get{return _idmanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pwdword
		{
			set{ _pwdword=value;}
			get{return _pwdword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? to_id
		{
			set{ _to_id=value;}
			get{return _to_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string u_code
		{
			set{ _u_code=value;}
			get{return _u_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? last_login
		{
			set{ _last_login=value;}
			get{return _last_login;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? login_sum
		{
			set{ _login_sum=value;}
			get{return _login_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		#endregion Model

	}
}

