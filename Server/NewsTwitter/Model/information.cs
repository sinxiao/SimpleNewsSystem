using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// information:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class information
	{
		public information()
		{}
		#region Model
		private int _idinformation;
		private int? _from_id;
		private int _to_id;
		private string _content;
		private int? _readed;
		private DateTime? _gen_time;
		private int? _infor_type;
		private int? _manager_id;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idinformation
		{
			set{ _idinformation=value;}
			get{return _idinformation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? from_id
		{
			set{ _from_id=value;}
			get{return _from_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int to_id
		{
			set{ _to_id=value;}
			get{return _to_id;}
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
		public int? readed
		{
			set{ _readed=value;}
			get{return _readed;}
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
		public int? infor_type
		{
			set{ _infor_type=value;}
			get{return _infor_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? manager_id
		{
			set{ _manager_id=value;}
			get{return _manager_id;}
		}
		#endregion Model

	}
}

