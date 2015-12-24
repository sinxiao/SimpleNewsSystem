using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// albums:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class albums
	{
		public albums()
		{}
		#region Model
		private int _album_id;
		private string _name_eg;
		private string _name_ch;
		private int? _artist_id;
		private string _pub_date;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int album_id
		{
			set{ _album_id=value;}
			get{return _album_id;}
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
		public string name_ch
		{
			set{ _name_ch=value;}
			get{return _name_ch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? artist_id
		{
			set{ _artist_id=value;}
			get{return _artist_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pub_date
		{
			set{ _pub_date=value;}
			get{return _pub_date;}
		}
		#endregion Model

	}
}

