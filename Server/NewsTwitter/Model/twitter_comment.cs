using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// twitter_comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class twitter_comment
	{
		public twitter_comment()
		{}
		#region Model
		private int _idtwitter_comment;
		private int _twitter_id;
		private string _comment;
		private int? _uuser_id;
		private DateTime? _gen_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idtwitter_comment
		{
			set{ _idtwitter_comment=value;}
			get{return _idtwitter_comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int twitter_id
		{
			set{ _twitter_id=value;}
			get{return _twitter_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? uuser_id
		{
			set{ _uuser_id=value;}
			get{return _uuser_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gen_time
		{
			set{ _gen_time=value;}
			get{return _gen_time;}
		}
		#endregion Model

	}
}

