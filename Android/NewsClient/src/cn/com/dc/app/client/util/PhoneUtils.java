package cn.com.dc.app.client.util;

import java.io.IOException;
import java.util.Iterator;
import java.util.List;

import android.app.ActivityManager;
import android.app.ActivityManager.RunningServiceInfo;
import android.content.Context;
import android.telephony.TelephonyManager;
import android.util.DisplayMetrics;
import android.util.Log;
import cn.com.dc.app.client.bean.CMDExecute;
import cn.com.dc.app.client.bean.PhoneInfo;

public class PhoneUtils {
	
	/***
	 * 运营商信息
	 * 
	 * @param cx
	 * @return
	 */
	public  String fetch_tel_status(Context cx) {
		String result = null;
		TelephonyManager tm = (TelephonyManager) cx
				.getSystemService(Context.TELEPHONY_SERVICE);
		String str = " ";
		str += "DeviceId(IMEI) = " + tm.getDeviceId() + " ";
		str += "DeviceSoftwareVersion = " + tm.getDeviceSoftwareVersion() + " ";
		// TODO: Do something ...
		int mcc = cx.getResources().getConfiguration().mcc;
		int mnc = cx.getResources().getConfiguration().mnc;
		str += "IMSI MCC (Mobile Country Code): " + String.valueOf(mcc) + " ";
		str += "IMSI MNC (Mobile Network Code): " + String.valueOf(mnc) + " ";
		result = str;
		Log.i("fetch_tel_status", "result=" + result);
		return result;
	}

	/**
	 * cpu info
	 * 
	 * @return
	 */
	public  void fetch_cpu_info(PhoneInfo infor) {
		String result = null;
		CMDExecute cmdexe = new CMDExecute();
		try {
			String[] args = { "/system/bin/cat", "/proc/cpuinfo" };
			result = cmdexe.run(args, "/system/bin/");
			Log.i("result", "result=" + result);
			
		} catch (IOException ex) {
			ex.printStackTrace();
		}
	}

	/**
	 * 系统内存情况查看
	 */
	public static String getMemoryInfo(Context context) {
		StringBuffer memoryInfo = new StringBuffer();
		final ActivityManager activityManager = (ActivityManager) context
				.getSystemService(Context.ACTIVITY_SERVICE);
		ActivityManager.MemoryInfo outInfo = new ActivityManager.MemoryInfo();
		activityManager.getMemoryInfo(outInfo);
		memoryInfo.append(" Total Available Memory :")
				.append(outInfo.availMem >> 10).append("k");
		memoryInfo.append(" Total Available Memory :")
				.append(outInfo.availMem >> 20).append("k");
		memoryInfo.append(" In low memory situation:")
				.append(outInfo.lowMemory);
		String result = null;
		CMDExecute cmdexe = new CMDExecute();
		try {
			String[] args = { "/system/bin/cat", "/proc/meminfo" };
			result = cmdexe.run(args, "/system/bin/");
			Log.i("getMemoryInfo", "result=" + result);
		} catch (IOException ex) {
			Log.i("fetch_process_info", "ex=" + ex.toString());

		}
		return (memoryInfo.toString() + " " + result);
	}

	// 磁盘信息
	public  String fetch_disk_info() {
		String result = null;
		CMDExecute cmdexe = new CMDExecute();
		try {
			String[] args = { "/system/bin/df" };
			result = cmdexe.run(args, "/system/bin/");
			Log.i("fetch_disk_info", "result=" + result);
		} catch (IOException ex) {
			ex.printStackTrace();
		}
		return result;
	}

	// 网络信息
	public  String fetch_netcfg_info() {
		String result = null;
		CMDExecute cmdexe = new CMDExecute();
		try {
			String[] args = { "/system/bin/netcfg" };
			result = cmdexe.run(args, "/system/bin/");
			Log.i("fetch_netcfg_info", "ex=" + result);
		} catch (IOException ex) {
			Log.i("fetch_process_info", "ex=" + ex.toString());
		}
		return result;
	}

	// 获得显示屏信息
	public String getDisplayMetrics(Context cx) {
		String str = "";
		DisplayMetrics dm = new DisplayMetrics();
		dm = cx.getApplicationContext().getResources().getDisplayMetrics();
		int screenWidth = dm.widthPixels;
		int screenHeight = dm.heightPixels;
		float density = dm.density;
		float xdpi = dm.xdpi;
		float ydpi = dm.ydpi;
		str += "The absolute width: " + String.valueOf(screenWidth) + "pixels ";
		str += "The absolute heightin: " + String.valueOf(screenHeight)
				+ "pixels ";
		str += "The logical density of the display. : "
				+ String.valueOf(density) + " ";
		str += "X dimension : " + String.valueOf(xdpi) + "pixels per inch ";
		str += "Y dimension : " + String.valueOf(ydpi) + "pixels per inch ";
		Log.i("getDisplayMetrics", "ex=" + str);
		return str;

	}

	// 正在运行的服务列表
	public static String getRunningServicesInfo(Context context) {
		StringBuffer serviceInfo = new StringBuffer();
		final ActivityManager activityManager = (ActivityManager) context
				.getSystemService(Context.ACTIVITY_SERVICE);
		List<RunningServiceInfo> services = activityManager
				.getRunningServices(100);
		Iterator<RunningServiceInfo> l = services.iterator();
		while (l.hasNext()) {
			RunningServiceInfo si = (RunningServiceInfo) l.next();
			serviceInfo.append("pid: ").append(si.pid);
			serviceInfo.append(" process: ").append(si.process);
			serviceInfo.append(" service: ").append(si.service);
			serviceInfo.append(" crashCount: ").append(si.crashCount);
			serviceInfo.append(" clicentCount: ").append(si.clientCount);
			serviceInfo.append(" activeSince:").append(
					ToolHelper.formatData(si.activeSince));
			serviceInfo.append(" lastActivityTime: ").append(
					ToolHelper.formatData(si.lastActivityTime));
			serviceInfo.append(" ");
		}
		Log.i("getRunningServicesInfo", "start. . . . " +serviceInfo.toString());
		return serviceInfo.toString();
	}
	//获得进程信息
	public static  String fetch_process_info() {
		Log.i("fetch_process_info", "start. . . . ");
		String result = null;
		CMDExecute cmdexe = new CMDExecute();
		try {
			String[] args = { "/system/bin/top", "-n", "1" };
			result = cmdexe.run(args, "/system/bin/");
			Log.i("fetch_process_info", "result=" + result);
		} catch (IOException ex) {
			Log.i("fetch_process_info", "ex=" + ex.toString());
		}
		return result;
	}

}
