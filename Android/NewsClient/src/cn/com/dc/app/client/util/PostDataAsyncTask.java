package cn.com.dc.app.client.util;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.SocketException;
import java.net.SocketTimeoutException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpVersion;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.scheme.PlainSocketFactory;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.scheme.SocketFactory;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.client.DefaultHttpRequestRetryHandler;
import org.apache.http.impl.conn.tsccm.ThreadSafeClientConnManager;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.params.HttpProtocolParams;

/**
 * 2010-9-25 Administrator
 */
public class PostDataAsyncTask
		extends
			android.os.AsyncTask<TaskDeal, Integer, Object> {
	public static final int IMAGE_CONNECTION_TIMEOUT = 30000;
	public static final int IMAGE_CONNECTION_SO_TIMEOUT = 30000;
	public static final int IMAGE_HTTP_READ_BUFFER = 8192;
	private TaskDeal taskDeal;
	/*
	 * (non-Javadoc)
	 * 
	 * @see android.os.AsyncTask#onPreExecute()
	 */
	@Override
	protected void onPreExecute() {
		super.onPreExecute();
		publishProgress(2);
	}
	@Override
	protected void onProgressUpdate(Integer... values) {
		super.onProgressUpdate(values);
		Utils.showLog("the values is===> ",
				String.valueOf(values[0].intValue()));
	}
	/*
	 * (non-Javadoc)
	 * 
	 * @see android.os.AsyncTask#doInBackground(Params[])
	 */
	@Override
	protected Object doInBackground(TaskDeal... params) {// 在后台运行提交，消息的请求
		taskDeal = params[0];
		// 1初始化请求，填充请求休息 2初始化客户端 3发出请求 4 处理response 5 更新界面，绑定数据 在onPostExecute
		HttpUriRequest request = null;
		// taskDeal.isPost = false ;
		Utils.showLog("the http Is ", taskDeal.request);
		// 1
		if (taskDeal.isPost == true) {
			HttpPost post = new HttpPost(taskDeal.request);
			Utils.showLog("the http Is ", taskDeal.request);
			List<NameValuePair> pairs = new ArrayList<NameValuePair>();
			for (HashMap<String, String> value : taskDeal.parmas) {
				Object[] key = value.keySet().toArray();
				for (Object object : key) {
					String k = (String) object;
					String v = value.get(k);
					if(v!=null)
					{
						pairs.add(new BasicNameValuePair(k, v));	
					}
					Utils.showLog(" key is ==> ", k, " values is ==> ", v);
				}

			}
			// = (HttpPost) request;
			publishProgress(10);
			HttpEntity entity = null;
			try {
				entity = new UrlEncodedFormEntity(pairs, "utf-8");
				post.setEntity(entity);
				// post.addHeader("User-Agent",
				// "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)");
				// post.addHeader("(Request-Line)", "POST HTTP/1.1");
				// post.addHeader("Cookie",
				// "saeut=122.225.200.211.1290245774382339");
				request = post;
			} catch (UnsupportedEncodingException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		} else {
			request = new HttpGet(taskDeal.request);
		}
		publishProgress(20);
		// 2
		DefaultHttpClient client = createHttpClient();
		HttpResponse response = null;
		try {
			// request = taskDeal.isPost ==true ?(HttpPost)request : request ;
			// 3
			response = client.execute(taskDeal.isPost == true
					? (HttpPost) request
					: request);
			publishProgress(60);
			
			// 4
			return taskDeal.executResponse(response);

		} catch (ClientProtocolException e) {
			e.printStackTrace();
			taskDeal.onError(ClientProtocolException, request, response);
			return null;
		} catch (SocketException e) {
			// TODO: ndle exception
			e.printStackTrace();
			taskDeal.onError(SocketException, request, response);
			return null;
		} catch (SocketTimeoutException e) {
			// TODO: handle exception
			e.printStackTrace();
			taskDeal.onError(SocketTimeoutException, request, response);
			return null;
		} catch (Exception e) {
			e.printStackTrace();
			taskDeal.onError(Exception, request, response);
			return null;
		}
		// return null;
	}
	public final static int ClientProtocolException = 1;
	public final static int SocketException = 2;
	public final static int SocketTimeoutException = 3;
	public final static int Exception = 4;
	private static DefaultHttpClient createHttpClient() {
		// create client
		SchemeRegistry schemeRegistry = new SchemeRegistry();
		SocketFactory sf = PlainSocketFactory.getSocketFactory();
		schemeRegistry.register(new Scheme("http", sf, 80));
		HttpParams params = new BasicHttpParams();
		HttpProtocolParams.setVersion(params, HttpVersion.HTTP_1_1);
		HttpProtocolParams.setContentCharset(params, "UTF-8");
		HttpProtocolParams.setUseExpectContinue(params, false);
		HttpConnectionParams.setConnectionTimeout(params,
				IMAGE_CONNECTION_TIMEOUT);
		HttpConnectionParams.setSoTimeout(params, IMAGE_CONNECTION_SO_TIMEOUT);
		ClientConnectionManager ccm = new ThreadSafeClientConnManager(params,
				schemeRegistry);
		DefaultHttpClient client = new DefaultHttpClient(ccm, params);
		client.setHttpRequestRetryHandler(new DefaultHttpRequestRetryHandler(3,
				false));
		return client;
	}
	/*
	 * (non-Javadoc)
	 * 
	 * @see android.os.AsyncTask#onPostExecute(java.lang.Object)
	 */
	protected void onPostExecute(Object result) { // 处理获得的信息结果
		super.onPostExecute(result);
		publishProgress(80);
		taskDeal.updateView(result);
		publishProgress(100);
	}
	public static void main(String[] args) {
		HttpClient client = createHttpClient();
		HttpUriRequest request = null;
		request = new HttpPost(
				"http://chepiao.sinaapp.com/api.php?action=remain");
		List<NameValuePair> pairs = new ArrayList<NameValuePair>();

		// String v = value.get(key[0]);
		pairs.add(new BasicNameValuePair("date", "20101120"));
		pairs.add(new BasicNameValuePair("startStation", "北京"));
		pairs.add(new BasicNameValuePair("arriveStation", "西安"));

		HttpPost post = (HttpPost) request;
		HttpEntity entity = null;
		try {
			entity = new UrlEncodedFormEntity(pairs, "utf-8");
			post.setEntity(entity);

		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		HttpResponse response = null;
		try {
			response = client.execute(post);

		} catch (ClientProtocolException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
