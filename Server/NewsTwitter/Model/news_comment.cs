using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// news_comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class news_comment
	{
		public news_comment()
		{}
		#region Model
		private int _idnews_comment;
		private string _comment_name;
		private string _email;
		private int? _user_id;
		private string _content;
		private DateTime? _gen_time;
		private int? _news_id;
        private int _c_type;

        public int C_type
        {
            get { return _c_type; }
            set { _c_type = value; }
        }
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idnews_comment
		{
			set{ _idnews_comment=value;}
			get{return _idnews_comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comment_name
		{
			set{ _comment_name=value;}
			get{return _comment_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? news_id
		{
			set{ _news_id=value;}
			get{return _news_id;}
		}
		#endregion Model

	}
}

