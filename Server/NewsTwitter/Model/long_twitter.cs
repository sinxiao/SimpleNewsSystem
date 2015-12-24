using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// long_twitter:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class long_twitter
	{
		public long_twitter()
		{}
		#region Model
		private int _idtwitter_demo;
		private string _blog;
		private string _images;
		private int? _twitter_id;
		private int? _uid;
		private string _title;
		/// <summary>
		/// 
		/// </summary>
		public int idtwitter_demo
		{
			set{ _idtwitter_demo=value;}
			get{return _idtwitter_demo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string blog
		{
			set{ _blog=value;}
			get{return _blog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string images
		{
			set{ _images=value;}
			get{return _images;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? twitter_id
		{
			set{ _twitter_id=value;}
			get{return _twitter_id;}
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		#endregion Model

	}
}

