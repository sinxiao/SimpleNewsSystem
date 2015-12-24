using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// rights:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class rights
	{
		public rights()
		{}
		#region Model
		private int _idrights;
		private int? _parent_r_id;
		private string _name;
		private string _url;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idRights
		{
			set{ _idrights=value;}
			get{return _idrights;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parent_r_id
		{
			set{ _parent_r_id=value;}
			get{return _parent_r_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		#endregion Model

	}
}

