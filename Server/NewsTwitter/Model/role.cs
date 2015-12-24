using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class role
	{
		public role()
		{}
		#region Model
		private int _idrole;
		private string _rname;
		private string _desription;
		private string _parent_r_id;
		private DateTime? _gen_time;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idRole
		{
			set{ _idrole=value;}
			get{return _idrole;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rname
		{
			set{ _rname=value;}
			get{return _rname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string desription
		{
			set{ _desription=value;}
			get{return _desription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parent_r_id
		{
			set{ _parent_r_id=value;}
			get{return _parent_r_id;}
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

