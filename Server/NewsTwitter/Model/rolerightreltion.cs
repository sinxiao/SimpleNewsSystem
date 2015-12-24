using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// rolerightreltion:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class rolerightreltion
	{
		public rolerightreltion()
		{}
		#region Model
		private int _idrolerightreltion;
		private int _role_id;
		private int _right_id;
		private int _right_type=0;
		/// <summary>
		/// 
		/// </summary>
		public int idRoleRightReltion
		{
			set{ _idrolerightreltion=value;}
			get{return _idrolerightreltion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int right_id
		{
			set{ _right_id=value;}
			get{return _right_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int right_type
		{
			set{ _right_type=value;}
			get{return _right_type;}
		}
		#endregion Model

	}
}

