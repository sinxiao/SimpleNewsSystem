using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class item
	{
		public item()
		{}
		#region Model
		private int _iditem;
		private string _name;
		private string _ename;
		private int? _showathome;
		private int? _item_parent;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int iditem
		{
			set{ _iditem=value;}
			get{return _iditem;}
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
		public string ename
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? showathome
		{
			set{ _showathome=value;}
			get{return _showathome;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? item_parent
		{
			set{ _item_parent=value;}
			get{return _item_parent;}
		}
		#endregion Model

	}
}

