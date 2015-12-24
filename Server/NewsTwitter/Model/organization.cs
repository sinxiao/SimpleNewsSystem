using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// organization:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class organization
	{
		public organization()
		{}
		#region Model
		private int _idorganization;
		private int? _parent_to_id;
		private string _org_name;
		private DateTime? _org_gen;
		private string _destription;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idOrganization
		{
			set{ _idorganization=value;}
			get{return _idorganization;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parent_to_id
		{
			set{ _parent_to_id=value;}
			get{return _parent_to_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string org_name
		{
			set{ _org_name=value;}
			get{return _org_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? org_gen
		{
			set{ _org_gen=value;}
			get{return _org_gen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string destription
		{
			set{ _destription=value;}
			get{return _destription;}
		}
		#endregion Model

	}
}

