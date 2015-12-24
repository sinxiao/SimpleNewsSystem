using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// euser_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class euser_detail
	{
		public euser_detail()
		{}
		#region Model
		private int _id_user_detail;
		private int? _user_id;
		private string _qq_no;
		private string _imei;
		private string _cell_phone_no;
		private int? _contact;
		private int? _location;
		private int? _gender;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id_User_detail
		{
			set{ _id_user_detail=value;}
			get{return _id_user_detail;}
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
		public string qq_no
		{
			set{ _qq_no=value;}
			get{return _qq_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imei
		{
			set{ _imei=value;}
			get{return _imei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cell_phone_no
		{
			set{ _cell_phone_no=value;}
			get{return _cell_phone_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? contact
		{
			set{ _contact=value;}
			get{return _contact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? location
		{
			set{ _location=value;}
			get{return _location;}
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

