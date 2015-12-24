using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// news:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class news
	{
		public news()
		{}
		#region Model
		private int _idnews;
		private string _intro;
		private DateTime? _gen_time;
		private int? _writer;
        private manager manager;
        private int verify_id;
        private String username;
        private String userid;

        public String Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public int Verify_id
        {
            get { return verify_id; }
            set { verify_id = value; }
        }
        private DateTime verify_date = DateTime.MinValue;

        public DateTime Verify_date
        {
            get { return verify_date; }
            set { verify_date = value; }
        }
        private int verify;

        public int Verify
        {
            get { return verify; }
            set { verify = value; }
        }
        public manager Manager
        {
            get { return manager; }
            set { manager = value; }
        }
		private string _title;
		private string _content;
		private int? _itemid;
        private item item;

        public item Item
        {
            get { return item; }
            set { item = value; }
        }

		private int? _passcheked;
		private String _keyword;
		private int? _default_news;
		private int? _clicked;
		private string _news_url;
		private string _image_url;
		private int? _comment_sum;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idnews
		{
			set{ _idnews=value;}
			get{return _idnews;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
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
		public int? writer
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
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
		public int? itemid
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? passcheked
		{
			set{ _passcheked=value;}
			get{return _passcheked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public String keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? default_news
		{
			set{ _default_news=value;}
			get{return _default_news;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? clicked
		{
			set{ _clicked=value;}
			get{return _clicked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_url
		{
			set{ _news_url=value;}
			get{return _news_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string image_url
		{
			set{ _image_url=value;}
			get{return _image_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? comment_sum
		{
			set{ _comment_sum=value;}
			get{return _comment_sum;}
		}
		#endregion Model

	}
}

