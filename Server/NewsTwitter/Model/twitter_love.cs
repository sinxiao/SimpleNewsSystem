using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// twitter_love:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class twitter_love
	{
		public twitter_love()
		{}
		#region Model
		private int _idtwitter_love;
		private int _twitter_id;
		private int _euser_id;
		private string _content;
		private DateTime? _gen_time;
		/// <summary>
		/// 
		/// </summary>
		public int idtwitter_love
		{
			set{ _idtwitter_love=value;}
			get{return _idtwitter_love;}
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
		public int euser_id
		{
			set{ _euser_id=value;}
			get{return _euser_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
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

