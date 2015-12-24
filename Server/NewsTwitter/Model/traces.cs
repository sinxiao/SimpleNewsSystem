using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// traces:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class traces
	{
		public traces()
		{}
		#region Model
		private int _idtraces;
		private int? _uid;
		private string _trace_name;
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
		private string _build_time;
		private string _end_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idtraces
		{
			set{ _idtraces=value;}
			get{return _idtraces;}
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
		public string trace_name
		{
			set{ _trace_name=value;}
			get{return _trace_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string build_time
		{
			set{ _build_time=value;}
			get{return _build_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string end_time
		{
			set{ _end_time=value;}
			get{return _end_time;}
		}
		#endregion Model

	}
}

