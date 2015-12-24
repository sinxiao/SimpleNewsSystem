using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// artists:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class artists
	{
		public artists()
		{}
		#region Model
		private int _artist_id;
		private int? _height;
		private string _name;
		private string _name_eg;
		private string _weight;
		private string _langrange;
		private string _start;
		private string _live_pet;
		private string _blood_type;
		private string _love_to_say;
		private string _job;
		private string _company;
		private string _best_hobby;
		private string _worst_bobby;
		private string _birth_date;
		private string _best_wish;
		private string _hobby;
		private string _like_color;
		private string _likedrink;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int artist_id
		{
			set{ _artist_id=value;}
			get{return _artist_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? height
		{
			set{ _height=value;}
			get{return _height;}
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
		public string name_eg
		{
			set{ _name_eg=value;}
			get{return _name_eg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string langrange
		{
			set{ _langrange=value;}
			get{return _langrange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string start
		{
			set{ _start=value;}
			get{return _start;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string live_pet
		{
			set{ _live_pet=value;}
			get{return _live_pet;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string blood_type
		{
			set{ _blood_type=value;}
			get{return _blood_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string love_to_say
		{
			set{ _love_to_say=value;}
			get{return _love_to_say;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string job
		{
			set{ _job=value;}
			get{return _job;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string best_hobby
		{
			set{ _best_hobby=value;}
			get{return _best_hobby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worst_bobby
		{
			set{ _worst_bobby=value;}
			get{return _worst_bobby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string birth_date
		{
			set{ _birth_date=value;}
			get{return _birth_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string best_wish
		{
			set{ _best_wish=value;}
			get{return _best_wish;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string hobby
		{
			set{ _hobby=value;}
			get{return _hobby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string like_color
		{
			set{ _like_color=value;}
			get{return _like_color;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string likedrink
		{
			set{ _likedrink=value;}
			get{return _likedrink;}
		}
		#endregion Model

	}
}

