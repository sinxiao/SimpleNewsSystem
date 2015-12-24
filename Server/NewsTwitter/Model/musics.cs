using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// musics:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class musics
	{
		public musics()
		{}
		#region Model
		private int _music_id;
		private string _music_name;
		private int? _abum_id;
		private string _duration;
		private string _src;
		private string _lrc_src;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int music_id
		{
			set{ _music_id=value;}
			get{return _music_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string music_name
		{
			set{ _music_name=value;}
			get{return _music_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? abum_id
		{
			set{ _abum_id=value;}
			get{return _abum_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string duration
		{
			set{ _duration=value;}
			get{return _duration;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string src
		{
			set{ _src=value;}
			get{return _src;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lrc_src
		{
			set{ _lrc_src=value;}
			get{return _lrc_src;}
		}
		#endregion Model

	}
}

