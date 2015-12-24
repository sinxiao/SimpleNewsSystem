package cn.com.dc.app.client.util;

public class ToolHelper {
	public static String formatData(long data)
	{
		float d = ((float)data)/100/3600;
		return d+"h" ;
	}

}
