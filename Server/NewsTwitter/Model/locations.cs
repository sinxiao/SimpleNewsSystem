using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// locations:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class locations
	{
		public locations()
		{}
		#region Model
		private int _idlocations;
		private string _longitude;
		private string _latitude;
		private string _datetime;
		private int? _uid;
		private int? _trace_id;
        private string _lname;

        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }
        private string _data1;

        public string Data1
        {
            get { return _data1; }
            set { _data1 = value; }
        }
        private string _data2;

        public string Data2
        {
            get { return _data2; }
            set { _data2 = value; }
        }
        private string _demo;

        public string Demo
        {
            get { return _demo; }
            set { _demo = value; }
        }
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idlocations
		{
			set{ _idlocations=value;}
			get{return _idlocations;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
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
		public int? trace_id
		{
			set{ _trace_id=value;}
			get{return _trace_id;}
		}
		#endregion Model

	}
}

