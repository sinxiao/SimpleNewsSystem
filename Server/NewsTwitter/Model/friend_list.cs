using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// friend_list:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class friend_list
	{
		public friend_list()
		{}
		#region Model
		private int _idfriend_list;
		private int _u_id;
		private DateTime? _gen_time;
		private string _friend_list_name;
		/// <summary>
		/// 
		/// </summary>
		public int idfriend_list
		{
			set{ _idfriend_list=value;}
			get{return _idfriend_list;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int u_id
		{
			set{ _u_id=value;}
			get{return _u_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gen_time
		{
			set{ _gen_time=value;}
			get{return _gen_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string friend_list_name
		{
			set{ _friend_list_name=value;}
			get{return _friend_list_name;}
		}
		#endregion Model

	}
}

