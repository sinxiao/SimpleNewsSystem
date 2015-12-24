
package cn.com.dc.app.client.util;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;

/**
 *  处理用的一个主体封装了各种常数与处理
 *  两个抽象方法:
 *  
 *  **把要提交的信息封装到request里**
 *  setParmas() 
 *  
 *  **处理发过来的信息，主要是将字节流或字符流转换成对象***
 *  dealTheData(HttpResponse response,String data);
 *  
 * 2010-9-25 Administrator
 */
public abstract class TaskDeal {
	public static final int UnsupportedEncodingException = 11 ;
	public static final int JSONException  = 12 ;
	public static final int ParseException = 13 ;
	public static final int nomore = 14 ;
	public String request = null;
	public List<HashMap<String, String>> parmas =null;
	public boolean isPost = true;
//	private HttpResponse response = null;
	public TaskDeal(){
		parmas = new ArrayList<HashMap<String,String>>();
	} 
	public TaskDeal(String requst){
		this();
		this.request =requst;
		if(isPost)
			setParmas();
	}
	/***
	 * 把要提交的信息封装到request里
	 */
	public abstract void setParmas();
	/**
	 * 处理返回来的结果，可能是要涉及到字符串的转码解密，日志记录等所以要单独声明出来
	 * 2010-9-25
	 * @param response 服务器端的响应
	 */
	protected Object executResponse(HttpResponse response){
		StringBuffer sb =new StringBuffer();
//		System.out.println("the code is "+response.getStatusLine().getStatusCode());
//		System.out.println(response.getEntity().getContentLength());
		
		try {
			BufferedReader input =new BufferedReader(new InputStreamReader(response.getEntity().getContent()),8000);
//			int len = 0 ;
//			byte[] value =new byte[2024];
			String crrentline ="";
			while ((crrentline=input.readLine())!=null) {//处理编码可能要进行转码
				sb.append(crrentline);
			}
//			sb.append(new String(value,"utf-8"));
//			input.read(buffer, offset, length)
			input.close();
			Utils.showLog(" the the respons is ===> ", sb.toString());
		} catch (IllegalStateException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		} 
		return dealTheData(response,sb.toString());
		
	};
	/***
	 * 处理发过来的信息，主要是将字节流或字符流转换成对象
	 * 在非UI线程，执行的解析数据操作
	 * @param response
	 * @param data
	 */
	public abstract Object dealTheData(HttpResponse response,String data);
	
	public abstract void onError(int errorId,HttpRequest request,HttpResponse response);
	
	/***
	 * 将处理后的对象更新到界面上，刷新view
	 * 在UI线程，执行更新界面操作View
	 */
	public abstract void updateView(Object obj);
}

