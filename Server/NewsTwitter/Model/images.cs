using System;
namespace WoeMobile.Model
{
	/// <summary>
	/// images:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class images
	{
		public images()
		{}
		#region Model
		private int _image_id;
		private string _image_src;
		private int? _image_owner;
		private string _demo;
		private int? _uid;
		private int? _trace_id;
		private int? _location_id;
        private String data1;

        public String Data1
        {
            get { return data1; }
            set { data1 = value; }
        }
        private String data2;

        public String Data2
        {
            get { return data2; }
            set { data2 = value; }
        }

        public String Demo
        {
            get { return demo; }
            set { demo = value; }
        }
        private float rate;

        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }
		private byte[] _bdata;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int image_id
		{
			set{ _image_id=value;}
			get{return _image_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string image_src
		{
			set{ _image_src=value;}
			get{return _image_src;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? image_owner
		{
			set{ _image_owner=value;}
			get{return _image_owner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string demo
		{
			set{ _demo=value;}
			get{return _demo;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? location_id
		{
			set{ _location_id=value;}
			get{return _location_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] bdata
		{
			set{ _bdata=value;}
			get{return _bdata;}
		}
		#endregion Model

	}
}

