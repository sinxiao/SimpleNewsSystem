using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// tw_types:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tw_types
	{
		public tw_types()
		{}
		#region Model
		private int _id_tw_types;
		private string _name;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id_tw_types
		{
			set{ _id_tw_types=value;}
			get{return _id_tw_types;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

