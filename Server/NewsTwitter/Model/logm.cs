using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// logm:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class logm
	{
		public logm()
		{}
		#region Model
		private int _idlogm;
		private int? _op_type;
		private string _content;
		private int _manger_id;
		private DateTime? _gen_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idLogM
		{
			set{ _idlogm=value;}
			get{return _idlogm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? op_type
		{
			set{ _op_type=value;}
			get{return _op_type;}
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
		public int manger_id
		{
			set{ _manger_id=value;}
			get{return _manger_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? gen_time
		{
			set{ _gen_time=value;}
			get{return _gen_time;}
		}
		#endregion Model

	}
}

