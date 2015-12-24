package com.netpoint.app.util;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.ConcurrentModificationException;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.Random;
import java.util.concurrent.TimeoutException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.util.EntityUtils;

import android.Manifest;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.StatFs;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.widget.Toast;

public class Utils {

	public static final int IO_BUFFER_SIZE = 8 * 1024;

	/**
	 * dialog 对话框
	 * 
	 * @param context
	 *            上下文
	 * @param msg
	 *            信息.
	 */
	public static void showMsg(Context context, String msg) {
		// Toast.makeText(context, msg, Toast.LENGTH_SHORT).show();
		AlertDialog.Builder tap = new AlertDialog.Builder(context);
		// tap.setTitle("提示");
		tap.setMessage(msg);
		tap.setPositiveButton("确定", new OnClickListener() {
			public void onClick(DialogInterface dialog, int which) {
				dialog.dismiss();
			}
		});
		tap.show();
	}

	/**
	 * 验证是否是正确的手机号码
	 * 
	 * @param mobiles
	 * @return true表示是正确的手机号码.false则相反.
	 */
	public static boolean isMobile(String mobiles) {
		Pattern p = Pattern
				.compile("^((13[0-9])|(15[^4,\\D])|(18[0-9]))\\d{8}$");
		Matcher m = p.matcher(mobiles);
		return m.matches();
	}

	/**
	 * 将bitmap转化为byte[]
	 * 
	 * @param quality
	 *            quality为0~100, 可以压缩图片质量
	 * */
	public static byte[] generateByteArray(Bitmap bm, int quality) {
		byte[] imgByteArray = null;
		ByteArrayOutputStream bos = new ByteArrayOutputStream();
		bm.compress(CompressFormat.PNG, quality, bos);
		imgByteArray = bos.toByteArray();
		if (bos != null) {
			try {
				bos.close();
			} catch (IOException e) {
			}
		}
		return imgByteArray;
	}

	/**
	 * 验证密码是否相同
	 * 
	 * @param pwd1
	 *            密码1
	 * @param pwd2
	 *            密码2
	 * @return true相同 false不同
	 */
	public static boolean checkPwd(String pwd1, String pwd2) {
		if (pwd1.equals(pwd2)) {
			return true;
		}
		return false;
	}

	/**
	 * 生成18位随机字符串
	 * 
	 * @return 所生成的随机字符串
	 */
	public static String getNonce() {
		String base = "abcdefghijklmnopqrstuvwxyz0123456789";
		Random random = new Random();
		StringBuffer sb = new StringBuffer();
		for (int i = 0; i < 18; i++) {
			int number = random.nextInt(base.length());
			sb.append(base.charAt(number));
		}
		return sb.toString();
	}

	/**
	 * 生成四位随机数
	 * 
	 * @return 所生成的随机数字符串
	 */

	public static String getCheckCode() {
		String strInt = " ";
		Integer i = new Integer((int) (Math.random() * 10000));
		strInt = String.valueOf(i);
		if (strInt.length() != 4) {
			return getCheckCode();
		} else {
			return strInt;
		}
	}

	/**
	 * 生成时间戳
	 * 
	 * @return 生成的时间戳
	 */
	public static String getTimestamp() {
		Date date = new Date();
		long time = date.getTime();
		return (time + "").substring(0, 10);
	}

	/**
	 * 将时间戳转换为时间,暂时不需要 年份和秒数
	 * 
	 * @return 生成的时间字符串 "yyyy/MM/dd/hh:mm"
	 */
	public static String convertToTime(long mill) {
		Date date = new Date(mill);
		String timeStrs = "";
		try {
			SimpleDateFormat sdf = new SimpleDateFormat("MM/dd/hh:mm",
					Locale.CHINA);
			timeStrs = sdf.format(date);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return timeStrs;
	}

	/**
	 * 根据两点经纬度计算出两点路面距离
	 * 
	 * @return 距离 单位为： km
	 */
	public static String getDistance(double lon1, double lon2, double lat1,
			double lat2) {
		DecimalFormat df1 = new DecimalFormat("###0.00");
		String dist = "";
		double R = 6378137.0;// 地球的半径，单位为米
		double dLat = (lat2 - lat1) * Math.PI / 180; // 弧度
		double dLon = (lon2 - lon1) * Math.PI / 180;
		double a = Math.sin(dLat / 2) * Math.sin(dLat / 2)
				+ Math.cos(lat1 * Math.PI / 180)
				* Math.cos(lat2 * Math.PI / 180) * Math.sin(dLon / 2)
				* Math.sin(dLon / 2);
		double distance = (2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a))) * R;
		distance = Math.round(distance * 10000) / 10000;
		dist = df1.format(distance / 1000) + "km";// 保证为km单位,两位小数
		return dist;
	}

	/**
	 * 验证email格式
	 * 
	 * @param email
	 * @return true or false
	 */
	public static boolean checkEmail(String email) {
		// String regex =
		// "^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";
		// String regex = "^\\w+@([^@]+\\.)[a-zA-Z]{2,3}$";
		// String regex = "^\\w+@\\w+\\.(com\\.cn)|\\w+@\\w+\\.(com|cn)$";
		String regex = "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
		Pattern pattern = Pattern.compile(regex);
		Matcher matcher = pattern.matcher(email);
		return matcher.find();
	}

	/**
	 * 验证昵称内是否有特殊字符.
	 * 
	 * @param nickName
	 *            昵称
	 * @return
	 */
	public static boolean checkNickName(String nickName) {
		String regex = "^[0-9a-zA-Z\u4e00-\u9fa5_-]*$";
		Pattern pattern = Pattern.compile(regex);
		Matcher m = pattern.matcher(nickName);
		return m.find();
	}

	/**
	 * 验证一个字符串中的中文字节数.
	 * 
	 * @param str
	 *            需要验证的字符串
	 * @return 字符串中的中文"字节"长度
	 */
	public static int checkChineseNums(String str) {
		int nums = 0;
		String chinese = "[\u4e00-\u9fa5]{1}";
		Pattern pattern = Pattern.compile(chinese);
		Matcher m = pattern.matcher(str);
		while (m.find()) {
			nums++;
		}
		return nums * 2;
	}

	/**
	 * 验证一个字符串中的英文下划线字节数.
	 * 
	 * @param str
	 *            需要验证的字符串
	 * @return 字符串中的英文下划线"字节"长度
	 */
	public static int checkUserNums(String str) {
		int nums = 0;
		String chinese = "[0-9a-zA-Z_-]{1}";
		Pattern pattern = Pattern.compile(chinese);
		Matcher m = pattern.matcher(str);
		while (m.find()) {
			nums++;
		}
		return nums;
	}

	/**
	 * 网络是否连接
	 * 
	 * @param context
	 * @return true or false
	 */
	public static boolean netIsAvailable(Context context) {
		ConnectivityManager cwjManager = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		NetworkInfo info = cwjManager.getActiveNetworkInfo();
		if (info != null && info.isAvailable() && info.isConnected()) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 从server端获取数据的方法...
	 * 
	 * @param url
	 *            请求地址
	 * @param params
	 *            参数以集合形式传入
	 * @return 获取到的数据
	 * @throws Exception
	 *             需要外层捕获该异常
	 */
	public static String getData(String url, List<NameValuePair> params)
			throws Exception, TimeoutException {
		String data = "";
		try {
			HttpParams httpParams = new BasicHttpParams();
			HttpConnectionParams.setConnectionTimeout(httpParams, 15000);
			HttpConnectionParams.setSoTimeout(httpParams, 30000);
			// 新建HttpClient对象
			HttpClient httpClient = new DefaultHttpClient(httpParams);
			HttpPost post = new HttpPost(url);
			HttpEntity httpentity = new UrlEncodedFormEntity(params, "utf-8");
			post.setEntity(httpentity);
			HttpResponse response = httpClient.execute(post);
			int code = response.getStatusLine().getStatusCode();
			// byte[] bResultXml =
			// EntityUtils.toByteArray(response.getEntity());
			// if (bResultXml != null) {
			// data = new String(bResultXml);
			// System.out.println("data====" + data);
			// Log.v("gtrgtr", "response.getEntity().getContentLength()="
			// + response.getEntity().getContentLength());
			// }
			Log.v("gtrgtr", "code==" + code);
			if (code == 200) {
				/**
				 * 因为直接调用toString可能会导致某些中文字符出现乱码的情况。所以此处使用toByteArray
				 * 如果需要转成String对象，可以先调用EntityUtils.toByteArray()方法将消息实体转成byte数组，
				 * 在由new String(byte[] bArray)转换成字符串。
				 */
				byte[] bResultXml = EntityUtils.toByteArray(response
						.getEntity());
				if (bResultXml != null) {
					data = new String(bResultXml);

					// Log.v("gtrgtr",
					// "response.getEntity().getContentLength()="
					// + response.getEntity().getContentLength());

					Log.i("data", data);
					// System.out.println("data====" + data);
					// Log.v("gtrgtr",
					// "response.getEntity().getContentLength()="
					// + response.getEntity().getContentLength());

				}
			}
		} catch (ConcurrentModificationException e) {
			// System.out.println("data====" + data);
			e.printStackTrace();
		}
		return data;
	}

	public static String getData(String url, ArrayList<NameValuePair> params)
			throws Exception {
		// Log.v("gtrgtr", "url===" + url);
		String data = "";
		try {
			HttpParams httpParams = new BasicHttpParams();
			HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
			HttpConnectionParams.setSoTimeout(httpParams, 30000);
			// 新建HttpClient对象
			HttpClient httpClient = new DefaultHttpClient(httpParams);
			HttpPost post = new HttpPost(url);
			HttpEntity httpentity = new UrlEncodedFormEntity(params, "utf-8");
			post.setEntity(httpentity);
			HttpResponse response = httpClient.execute(post);
			int code = response.getStatusLine().getStatusCode();
			// byte[] bResultXml =
			// EntityUtils.toByteArray(response.getEntity());
			// if (bResultXml != null) {
			// data = new String(bResultXml);
			// System.out.println("data====" + data);
			// Log.v("gtrgtr", "response.getEntity().getContentLength()="
			// + response.getEntity().getContentLength());
			// }
			Log.v("gtrgtr", "code==" + code);
			if (code == 200) {
				/**
				 * 因为直接调用toString可能会导致某些中文字符出现乱码的情况。所以此处使用toByteArray
				 * 如果需要转成String对象，可以先调用EntityUtils.toByteArray()方法将消息实体转成byte数组，
				 * 在由new String(byte[] bArray)转换成字符串。
				 */
				byte[] bResultXml = EntityUtils.toByteArray(response
						.getEntity());
				if (bResultXml != null) {
					data = new String(bResultXml);
					System.out.println("data====" + data);
					// Log.v("gtrgtr",
					// "response.getEntity().getContentLength()="
					// + response.getEntity().getContentLength());
				}
			}
		} catch (ConcurrentModificationException e) {
			// System.out.println("data====" + data);
			e.printStackTrace();
		}
		return data;
	}

	public static String getData1(String url, ArrayList<NameValuePair> params)
			throws Exception {
		// Log.v("gtrgtr", "url===" + url);
		String data = "";
		try {
			HttpParams httpParams = new BasicHttpParams();
			HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
			HttpConnectionParams.setSoTimeout(httpParams, 30000);
			// 新建HttpClient对象
			HttpClient httpClient = new DefaultHttpClient(httpParams);
			HttpPost post = new HttpPost(url);
			HttpEntity httpentity = new UrlEncodedFormEntity(params, "utf-8");
			post.setEntity(httpentity);
			HttpResponse response = httpClient.execute(post);
			int code = response.getStatusLine().getStatusCode();
			// byte[] bResultXml =
			// EntityUtils.toByteArray(response.getEntity());
			// if (bResultXml != null) {
			// data = new String(bResultXml);
			// System.out.println("data====" + data);
			// }
			Log.v("gtrgtr", "code==" + code);
			if (code == 200) {
				/**
				 * 因为直接调用toString可能会导致某些中文字符出现乱码的情况。所以此处使用toByteArray
				 * 如果需要转成String对象，可以先调用EntityUtils.toByteArray()方法将消息实体转成byte数组，
				 * 在由new String(byte[] bArray)转换成字符串。
				 */

				// data =
				// convertStreamToString(response.getEntity().getContent());
				data = EntityUtils.toString(response.getEntity());
				System.out.println("data====" + data);
				// byte[] bResultXml = EntityUtils.toByteArray(response
				// .getEntity());
				// if (bResultXml != null) {
				// data = new String(bResultXml);
				// System.out.println("data====" + data);
				// // Log.v("gtrgtr",
				// // "response.getEntity().getContentLength()="
				// // + response.getEntity().getContentLength());
				// }
			}
		} catch (ConcurrentModificationException e) {
			// System.out.println("data====" + data);
			e.printStackTrace();
		}
		return data;
	}
	/**
	 * 实际使用中必须修改
	 * @param apiPath
	 * @param strXML
	 * @return
	 */
	public String postRequestXMLForSearchItem(String apiPath, String strXML) {
		int code = 0;
		String sk = "";
		try {
			URL url = new URL(apiPath);
			HttpURLConnection httpURLConnection;
			httpURLConnection = (HttpURLConnection) url.openConnection();
			httpURLConnection.setRequestMethod("POST");
			httpURLConnection.setDoOutput(true);
			httpURLConnection.setUseCaches(false);
			httpURLConnection.setRequestProperty("Charset", "UTF-8");
			httpURLConnection.setRequestProperty("Content-Type",
					"application/xml");
			OutputStream os = httpURLConnection.getOutputStream();
			os.write(strXML.toString().getBytes());
			os.flush();
			code = httpURLConnection.getResponseCode();
			os.close();
			Log.v("gtrgtr", "code=" + code);

			if (code == 200) {
				sk = convertStreamToString(httpURLConnection.getInputStream());
				Log.v("gtrgtr", "sk=" + sk);
				sk = sk.substring(sk.indexOf("<count>") + 7,
						sk.lastIndexOf("</count>"));
				sk = sk.substring(sk.indexOf("<count>") + 7,
						sk.lastIndexOf("</count>"));
			}
			httpURLConnection.disconnect();
		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			Log.v("gtrgtr", "postRequestXMLForSearchItemError");
			e.printStackTrace();
		}
		return sk;
	}

	private static String convertStreamToString(InputStream is) {

		BufferedReader reader = new BufferedReader(new InputStreamReader(is),
				10240);
		StringBuilder sb = new StringBuilder();

		String line = null;
		try {
			while ((line = reader.readLine()) != null) {
				sb.append(line + "\n");
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				is.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
		System.out.println(sb.toString());
		return sb.toString();
	}

	/**
	 * GET方式获得数据
	 * 
	 * @param url
	 * @return
	 * @throws Exception
	 */
	public static String getData(String url) throws Exception {
		// Log.v("gtrgtr", "url==="+url);
		HttpParams httpParams = new BasicHttpParams();
		HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
		HttpConnectionParams.setSoTimeout(httpParams, 30000);
		// 新建HttpClient对象
		HttpClient httpClient = new DefaultHttpClient(httpParams);
		HttpGet get = new HttpGet(url);
		HttpResponse response = httpClient.execute(get);
		int code = response.getStatusLine().getStatusCode();
		Log.v("gtrgtr", "code=========" + code);
		byte[] bResultXml = null;
		String data = "";
		if (code == 200) {
			/**
			 * 因为直接调用toString可能会导致某些中文字符出现乱码的情况。所以此处使用toByteArray
			 * 如果需要转成String对象，可以先调用EntityUtils.toByteArray()方法将消息实体转成byte数组，
			 * 在由new String(byte[] bArray)转换成字符串。
			 */
			bResultXml = EntityUtils.toByteArray(response.getEntity());
			if (bResultXml != null) {
				data = new String(bResultXml);
				System.out.println("data====" + data);
				// Log.v("gtrgtr", "response.getEntity().getContentLength()="
				// + response.getEntity().getContentLength());
			}

		}
		return data;
	}

	/**
	 * POST方式
	 * 
	 * @param url
	 * @param params
	 * @return
	 * @throws Exception
	 */
	public static byte[] getByteData(String url, List<NameValuePair> params)
			throws Exception {
		HttpParams httpParams = new BasicHttpParams();
		HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
		HttpConnectionParams.setSoTimeout(httpParams, 30000);
		// 新建HttpClient对象
		HttpClient httpClient = new DefaultHttpClient(httpParams);
		HttpPost post = new HttpPost(url);
		HttpEntity httpentity = new UrlEncodedFormEntity(params, "utf-8");
		post.setEntity(httpentity);
		HttpResponse response = httpClient.execute(post);
		int code = response.getStatusLine().getStatusCode();
		// Log.v("gtrgtr", "code=========" + code);
		byte[] bResultXml = null;
		if (code == 200) {
			bResultXml = EntityUtils.toByteArray(response.getEntity());
		}
		return bResultXml;
	}

	/**
	 * get方式获取
	 * 
	 * @param url
	 * @return
	 * @throws Exception
	 */
	public static byte[] getByteData(String url) throws Exception {
		HttpParams httpParams = new BasicHttpParams();
		HttpConnectionParams.setConnectionTimeout(httpParams, 30000);
		HttpConnectionParams.setSoTimeout(httpParams, 30000);
		// 新建HttpClient对象
		HttpClient httpClient = new DefaultHttpClient(httpParams);
		HttpGet get = new HttpGet(url);
		HttpResponse response = httpClient.execute(get);
		int code = response.getStatusLine().getStatusCode();
		// Log.v("gtrgtr", "code=========" + code);
		byte[] bResultXml = null;
		if (code == 200) {
			/**
			 * 因为直接调用toString可能会导致某些中文字符出现乱码的情况。所以此处使用toByteArray
			 * 如果需要转成String对象，可以先调用EntityUtils.toByteArray()方法将消息实体转成byte数组，
			 * 在由new String(byte[] bArray)转换成字符串。
			 */
			bResultXml = EntityUtils.toByteArray(response.getEntity());
		}
		return bResultXml;
	}

	/**
	 * 获得阿拉伯数字对应的中文 最大只支持到9千9百九十九亿9千9百九十九万9千9百九十九
	 * 
	 * @param number
	 *            要转换的数字
	 * @param depth
	 *            递归深度,使用时候直接给0即可
	 * @return String 数字的中文描述
	 */

	public static String getChinese(String number, int depth) {
		if (depth < 0) {
			depth = 0;
		}
		String chs = "";
		String src = number;

		if (src.length() > 4) {
			chs = getChinese(src.substring(0, src.length() - 4), depth + 1)
					+ getChinese(src.substring(src.length() - 4, src.length()),
							depth - 1);
		} else {
			for (int i = 0; i < src.length(); i++) {
				switch (src.charAt(i)) {
				case '0':
					chs = chs + "零";
					break;
				case '1':
					chs = chs + "一";
					break;
				case '2':
					chs = chs + "二";
					break;
				case '3':
					chs = chs + "三";
					break;
				case '4':
					chs = chs + "四";
					break;
				case '5':
					chs = chs + "五";
					break;
				case '6':
					chs = chs + "六";
					break;
				case '7':
					chs = chs + "七";
					break;
				case '8':
					chs = chs + "八";
					break;
				case '9':
					chs = chs + "九";
					break;
				}

				switch (src.length() - 1 - i) {
				case 0: // 元
					break;
				case 1: // 十
					chs = chs + "十";
					break;
				case 2: // 百
					chs = chs + "百";
					break;
				case 3: // 千
					chs = chs + "千";
					break;
				}
			}
		}

		if (chs.length() > 0 && chs.lastIndexOf("零") == chs.length() - 1) {
			chs = chs.substring(0, chs.length() - 1);
		}

		if (depth == 1) {
			chs += "万";
		}
		if (depth == 2) {
			chs += "亿";
		}

		return chs;
	}

	/**
	 * 弹出消息提醒
	 * 
	 * @param msg
	 *            要弹出的消息
	 * @param context
	 *            上下文对象
	 */
	public static void showMessage(String msg, Context context) {
		Toast.makeText(context, msg, Toast.LENGTH_LONG).show();
	}


	/**
	 * 时间补零.
	 * 
	 * @param c小于10的分钟
	 * @return
	 */
	public static String pad(int c) {
		if (c >= 10)
			return String.valueOf(c);
		else
			return "0" + String.valueOf(c);
	}

	/**
	 * 替换字符串内的所以的换行符号..等符号
	 * 
	 * @param str
	 * @return 替换后的字符串.
	 */
	public static String replaceBlank(String str) {
		Pattern p = Pattern.compile("\\s*|\t|\r|\n");
		Matcher m = p.matcher(str);
		return m.replaceAll("");
	}

	/**
	 * Check how much usable space is available at a given path.
	 * 
	 * @param path
	 *            The path to check
	 * @return The space available in bytes
	 */
	// @SuppressLint("NewApi")
	// public static long getUsableSpace(File path) {
	// // if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.GINGERBREAD) {
	// // return path.getUsableSpace();
	// // }
	// final StatFs stats = new StatFs(path.getPath());
	// return (long) stats.getBlockSize() * (long) stats.getAvailableBlocks();
	// }

	/**
	 * Check how much usable space is available at a given path.
	 * 
	 * @param path
	 *            The path to check
	 * @return The space available in bytes
	 */
	// @SuppressLint("NewApi")
	public static long getUsableSpace(File path) {
		// if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.GINGERBREAD) {
		// return path.getUsableSpace();
		// }
		final StatFs stats = new StatFs(path.getPath());
		return (long) stats.getBlockSize() * (long) stats.getAvailableBlocks();
	}


	/**
	 * 获得当前手机的imei
	 * 
	 * @param Context
	 *            上下文对象
	 * @return String类型的imei值(16位不重复的数字)
	 */
	public static String getPhoneImei(Context context) {
		TelephonyManager manager = (TelephonyManager) context
				.getSystemService(Activity.TELEPHONY_SERVICE);
		if (PackageManager.PERMISSION_GRANTED == context.getPackageManager()
				.checkPermission(Manifest.permission.READ_PHONE_STATE,
						context.getPackageName())) {
			return manager.getDeviceId();
		} else {
			return null;
		}
	}

	/**
	 * 获取手机号码
	 * 
	 * @param context
	 *            上下文对象
	 * @return null 或者号码
	 */
	public static String getPhoneNumber(Context context) {
		TelephonyManager manager = (TelephonyManager) context
				.getSystemService(Activity.TELEPHONY_SERVICE);
		if (PackageManager.PERMISSION_GRANTED == context.getPackageManager()
				.checkPermission(Manifest.permission.READ_PHONE_STATE,
						context.getPackageName())) {
			Log.v("gtrgtr",
					"manager.getSimSerialNumber()==="
							+ manager.getSimSerialNumber());
			Log.v("gtrgtr",
					"manager.getLine1Number()===" + manager.getLine1Number());
			return manager.getLine1Number();
		} else {
			return null;
		}
	}

	/**
	 * 转换字符串为Unicode代码
	 * 
	 * @param s 
	 * @return 字符类型的Unicode代码
	 */
	public static String stringToUnicode(String s) {

		String str = "";
		for (int i = 0; i < s.length(); i++) {
			int ch = (int) s.charAt(i);
			if (ch > 255)
				str += "\\u" + Integer.toHexString(ch);
			else
				str += "\\" + Integer.toHexString(ch);
		}
		return str;

	}

}
