using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// friend_list_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class friend_list_user
	{
		public friend_list_user()
		{}
		#region Model
		private int _idfriend_list_user;
		private int? _group_id;
		private int? _uid;
		private string _back_name;
		private int? _friend_list_id;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idfriend_list_user
		{
			set{ _idfriend_list_user=value;}
			get{return _idfriend_list_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string back_name
		{
			set{ _back_name=value;}
			get{return _back_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? friend_list_id
		{
			set{ _friend_list_id=value;}
			get{return _friend_list_id;}
		}
		#endregion Model

	}
}

