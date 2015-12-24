using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// twitter:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class twitter
	{
		public twitter()
		{}
		#region Model
		private string _datatime;
		private string _detial;
		private int? _ower_id_twitter;
		private int _uid;
		private int? _tw_type;
		private int? _target_id;
		private int? _target_type;
		private int _twitter_id;
		private int? _pinglun_sum;
		private int? _zhuangfa_sum;
		private string _topic;
		private string _linked;
		private int? _love_sum;
		/// <summary>
		/// 
		/// </summary>
		public string datatime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detial
		{
			set{ _detial=value;}
			get{return _detial;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ower_id_twitter
		{
			set{ _ower_id_twitter=value;}
			get{return _ower_id_twitter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tw_type
		{
			set{ _tw_type=value;}
			get{return _tw_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? target_id
		{
			set{ _target_id=value;}
			get{return _target_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? target_type
		{
			set{ _target_type=value;}
			get{return _target_type;}
		}
		/// <summary>
		/// auto_increment
		/// </summary>
		public int twitter_id
		{
			set{ _twitter_id=value;}
			get{return _twitter_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pinglun_sum
		{
			set{ _pinglun_sum=value;}
			get{return _pinglun_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? zhuangfa_sum
		{
			set{ _zhuangfa_sum=value;}
			get{return _zhuangfa_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string topic
		{
			set{ _topic=value;}
			get{return _topic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linked
		{
			set{ _linked=value;}
			get{return _linked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? love_sum
		{
			set{ _love_sum=value;}
			get{return _love_sum;}
		}
		#endregion Model

	}
}

