package cn.com.dc.app.client.util;

public class Configer {
	// public static final String SERVER$URL =
	// "http://192.168.0.41:3449/NewsTwitter/" ;
	// public static final String SERVER$URL =
	// "http://192.168.0.105:3449/NewsTwitter/" ;
	// public static final String SERVER$URL =
	// "http://192.168.0.41:3449/NewsTwitter/" ;
	public static final String SERVER$URL = "http://192.168.10.106:3449/NewsTwitter/";
	// http://198.100.106.212/Admin/login.aspx
	// public static final String SERVER$URL = "http://198.100.106.212/" ;
	// public static final String SERVER$URL = "http://www.yamenart.com:8800/";
	public static final String NEWS_BIZ = SERVER$URL
			+ "Client/NewsDoClient.aspx";
	public static final String COMMENT_BIZ = SERVER$URL
			+ "Client/CommentClientDo.aspx";
	public static final String POST_TYPE = "type";
	public static final String PST_COMMENT = "comment";
	public static final String PST_EMAIL = "email";
	public static final String PST_SUID = "uid";
	/***
	 * ������� 1��news 2��ͼƬ 3�����۵�����
	 */
	public static final String PST_CTYPE = "c_type";

	public static final String COUNT = "3";

	public static final String TYPE_COMMENT = "comment";
	public static final String TYPE_CLICKED = "clicked";

	public static final String NEWS_ID = "newsid";
	public static final String NEWS_DETAIL = "newsdetail";

	public static final String TWITTER_ID = "twitterid";
	public static final String TWITTER_DETAIL = "twitterdetail";

	public static final String PAGE_COUNT = "count";
	public static final String PAGE_IDX = "page";

	public static boolean connection = false;
	public static boolean usewifi = true;

	public static float battery_remain = 0.0f;
	public static boolean pluged = false;
}
