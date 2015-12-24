using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// template:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class template
	{
		public template()
		{}
		#region Model
		private int _idtemplate;
		private string _name;
		private string _content;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int idtemplate
		{
			set{ _idtemplate=value;}
			get{return _idtemplate;}
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
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

