using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// music_src:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class music_src
	{
		public music_src()
		{}
		#region Model
		private int _music_src_id;
		private int? _music_id;
		private string _src;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int music_src_id
		{
			set{ _music_src_id=value;}
			get{return _music_src_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? music_id
		{
			set{ _music_id=value;}
			get{return _music_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string src
		{
			set{ _src=value;}
			get{return _src;}
		}
		#endregion Model

	}
}

