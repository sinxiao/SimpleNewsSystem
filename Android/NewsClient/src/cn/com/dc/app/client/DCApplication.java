package cn.com.dc.app.client;

import java.util.ArrayList;
import java.util.List;

import android.app.Application;
import android.content.Intent;
import android.os.Handler;
import cn.com.dc.app.client.bean.PhoneInfo;
import cn.com.dc.app.client.util.PhoneUtils;
import cn.com.dc.app.client.util.Utils;

/***
 * yi程序的配置或共享一些信息，执行全局的操作
 * 
 * @author Administrator
 * 
 */
public class DCApplication extends Application {

	private PhoneInfo phoneInfor;
	private Handler mHandle = new Handler() {
		public void handleMessage(android.os.Message msg) {
			Thread td = new Thread() {
				public void run() {
					// 获得手机网络状态

					// 获得手机属性
					int first = Utils.readIntValueFromSpc(DCApplication.this,
							Utils.APP_FIRST_INIT, 1);
					if (Utils.True == first)// 第一次启动App
					{// 第一次启动程序时 执行的操作 //如：获取手机信息

					}
					phoneInfor = PhoneInfo.getPhoneInfo(DCApplication.this);
					// mm每次启动程序都获取
					// PhoneUtils.fetch_process_info();
					// PhoneUtils.getMemoryInfo(DCApplication.this);
					// PhoneUtils.getRunningServicesInfo(DCApplication.this);
					// SN

					//
					// SD or
					// get ram phone name
					// 每次获取 的是SD大小，手机信号强弱，cpu使用率，ram使用情况

					// 获得最新的版本，与上传上一次的操作记录
					// 获得最新的广告，与更改配置信息

				};
			};
			td.start();
			// 启动后台下载图片的service
			startService(new Intent(DCApplication.this,
					DownloadBackService.class));
			startService(new Intent(DCApplication.this, ConfigerService.class));
		};

	};
	public void onCreate() {
		super.onCreate();
		Utils.showLog("applicaton init ...");
		mHandle.sendMessageDelayed(mHandle.obtainMessage(), 800);
	}

	public PhoneInfo getPhoneInfo() {
		return phoneInfor;
	}
	private List<DCActivity> child = new ArrayList<DCActivity>();
	private DCActivity now;
	public void setNowDcActivity(DCActivity dcactivity) {
		now = dcactivity;
	}
	public DCActivity getNowActivity() {
		return now;
	}
	public void addChild(DCActivity activity) {
		child.add(activity);
	}
	public DCActivity getActivityIdx(int idx) {
		return child.get(idx);
	}
	public void remove(DCActivity activity) {
		child.remove(activity);
	}
	public void remove(int idx) {
		child.remove(idx);
	}
}
