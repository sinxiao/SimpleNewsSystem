package cn.com.dc.app.client.util;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.SocketException;
import java.net.SocketTimeoutException;
import java.security.SecureRandom;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Random;

import org.apache.http.HttpEntity;
import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.apache.http.HttpVersion;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
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

import android.content.Context;

public class SQLDoPhone extends Thread {
	public static final int IMAGE_CONNECTION_TIMEOUT = 30000;
	public static final int IMAGE_CONNECTION_SO_TIMEOUT = 30000;
	public static final int IMAGE_HTTP_READ_BUFFER = 8192;
	public static final String SQLURL = "";
	public String request = null;
	public List<HashMap<String, String>> parmas = null;
	public boolean isPost = true;

	public static interface OnWebRespListener {
		public void onSucessReceive(HttpResponse response, String data);

		public void onFailed(int errorId, HttpRequest request,
				HttpResponse response);
	};

	/***
	 * 执行的sql语句,如果是多条使用;隔开
	 */
	private String sql = "";

	public String server_factor = "server_factor58861222qfdwdmorumncue8498nl&%U&E";
	/***
	 * 用户标示
	 */
	private String token = "";
	public String clinet_factor = "clientfactor5875481125578-94ieynmckjgysiepfjkglamzjwuiryrtnggdg981469.+*5440*/5";
	private String factor = "";
	/***
	 * 手机标示
	 */
	private static String uuid = "";
	/***
	 * 传送数据的类型 0 为 客户端加密,服务器端不加密(默认类型) 1 为 客户端与服务器端皆加密 (为机要数据的时候设置这样的参数)
	 */
	private int uutype = 0;
	private Context mContxt;

	/***
	 * 实例化参数
	 * 
	 * @param sql
	 *            要执 行的sql语句   形式如: select * from xxxx,1;insert xxx into xxxx values (xxx),0
	 * @param token
	 *            验证身份权限参数 如用户名与密码
	 * @param utype
	 *             传送数据的类型 0 为 客户端加密,服务器端不加密(默认类型) 1 为 客户端与服务器端皆加密 (为机要数据的时候设置这样的参数)
	 */
	public SQLDoPhone(Context mCxt, String sql, String token, int utype,
			OnWebRespListener webpostResp) {
		this.sql = sql;
		this.token = token;
		isPost = true;
		request = SQLURL;
		factor = getFactor();
		// this.uuid = uuid;
		if (uuid != null) {
			uuid = getPhoneUUid();
		}
		onWebResp = webpostResp;
		uutype = utype;
		mContxt = mCxt;
	}

	private OnWebRespListener onWebResp;

	private String getPhoneUUid() {
		// clinet_factor
		String uuid = Utils.getUUid(mContxt);
		return AES.encryptString(uuid, getKey());
	}

	private String getFactor() {
		Random an = new SecureRandom();
		StringBuffer sbf = new StringBuffer();
		for (int i = 0; i < 9; i++) {
			sbf.append(an.nextInt(16));
		}
		return sbf.toString();
	}

	private String getKey() {
		return CryptUtils.encryptToMD5(clinet_factor + "younotbad" + factor);
	}

	private String getClientKey() {
		return CryptUtils.encryptToMD5(clinet_factor + factor);
	}

	public void setParmas() {
		List<HashMap<String, String>> nameValues = new ArrayList<HashMap<String, String>>();

		HashMap<String, String> pagecount = new HashMap<String, String>();
		sql = AES.encryptString(sql, getKey());
		token = AES.encryptString(token, getKey());
		StringBuffer sbf = new StringBuffer();

		sbf.append(sql).append("##").append(token).append("##").append(uuid)
				.append("##").append(uutype);
		String data = AES.encryptString(sbf.toString(), getClientKey());
		pagecount.put("data", data);

		pagecount.put("factor", factor);

		nameValues.add(pagecount);

		parmas = nameValues;
	}

	public void run() {
		// 1初始化请求，填充请求休息 2初始化客户端 3发出请求 4 处理response 5 更新界面，绑定数据 在onPostExecute
		HttpUriRequest request = null;
		// taskDeal.isPost = false ;
		// 1
		if (isPost == true) {
			HttpPost post = new HttpPost(SQLURL);
			List<NameValuePair> pairs = new ArrayList<NameValuePair>();
			for (HashMap<String, String> value : parmas) {
				Object[] key = value.keySet().toArray();
				for (Object object : key) {
					String k = (String) object;
					String v = value.get(k);
					if (v != null) {
						pairs.add(new BasicNameValuePair(k, v));
					}
					Utils.showLog(" key is ==> ", k, " values is ==> ", v);
				}

			}
			// = (HttpPost) request;
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
			request = new HttpGet(SQLURL);
		}
		// 2
		DefaultHttpClient client = createHttpClient();
		HttpResponse response = null;
		try {
			// request = taskDeal.isPost ==true ?(HttpPost)request : request ;
			// 3
			response = client.execute(isPost == true ? (HttpPost) request
					: request);

			// 4
			executResponse(response);

		} catch (ClientProtocolException e) {
			e.printStackTrace();
			onError(ClientProtocolException, request, response);
		} catch (SocketException e) {
			// TODO: ndle exception
			e.printStackTrace();
			onError(SocketException, request, response);
		} catch (SocketTimeoutException e) {
			// TODO: handle exception
			e.printStackTrace();
			onError(SocketTimeoutException, request, response);
		} catch (Exception e) {
			e.printStackTrace();
			onError(Exception, request, response);
		}
	}

	/**
	 * 处理返回来的结果，可能是要涉及到字符串的转码解密，日志记录等所以要单独声明出来 2010-9-25
	 * 
	 * @param response
	 *            服务器端的响应
	 * @throws java.lang.Exception 
	 */
	protected void executResponse(HttpResponse response) throws java.lang.Exception {
		StringBuffer sb = new StringBuffer();
		try {
			BufferedReader input = new BufferedReader(new InputStreamReader(
					response.getEntity().getContent()), 8000);
			String crrentline = "";
			while ((crrentline = input.readLine()) != null) {// 处理编码可能要进行转码
				sb.append(crrentline);
			}
			input.close();
			Utils.showLog(" the the respons is ===> ", sb.toString());
		} catch (IllegalStateException e) {
			e.printStackTrace();
			throw e;
		} catch (Exception e) {
			e.printStackTrace();
			throw e;
		}
		dealTheData(response, sb.toString());

	};

	/***
	 * <?xml version="1.0" encoding="utf-8"?> <Result> <type>uid</type>
	 * 处理的类别标示，也可以没有 <rep>0</rep> 表示处理的结果 <data></data> 具体 数据，可以没有，可以很少，也可以很多
	 * </Result>
	 */
	public Object dealTheData(HttpResponse response, String data) {
		// 解析 data xml，将xml转换成实体类，data可能是被加密的，需要些解密才可以
		onWebResp.onSucessReceive(response, data);
		return null;
	}

	public void onError(int errorId, HttpRequest request, HttpResponse response) {
		onWebResp.onFailed(errorId, request, response);
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
}
