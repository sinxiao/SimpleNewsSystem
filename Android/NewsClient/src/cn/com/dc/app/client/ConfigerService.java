package cn.com.dc.app.client;

import cn.com.dc.app.client.util.Configer;
import cn.com.dc.app.client.util.Utils;
import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.net.ConnectivityManager;
import android.net.NetworkInfo.State;
import android.os.BatteryManager;
import android.os.IBinder;
import android.telephony.PhoneStateListener;
import android.telephony.ServiceState;
import android.widget.Toast;

/***
 * 开机启动的Service，用来获得最新版本
 * 获得最新的新闻，等信息，记录手机的状态，如在wifi联网情况下才执行更新的操作，执行获得新闻的操作，断网的话进行错误提示
 * 
 */
public class ConfigerService extends Service {
	private ConnectivityManager connManager = null;
	private BroadcastReceiver mReceiver = new BroadcastReceiver() {

		@Override
		public void onReceive(Context context, Intent intent) {
			// TODO
			String action = intent.getAction();
			Utils.showLog(" ConfigerService Receive is ", action);
			
			if (ConnectivityManager.CONNECTIVITY_ACTION.equals(action)) {
				boolean success = !intent.getBooleanExtra(
						ConnectivityManager.EXTRA_NO_CONNECTIVITY, false);
				Utils.showLog(" ConfigerService success is ", String.valueOf(success));
				// boolean success = false;
				if (success == true) {
					State state = connManager.getNetworkInfo(
							ConnectivityManager.TYPE_WIFI).getState(); // 获取网络连接状态

					Configer.connection = true;
					if (State.CONNECTED == state) { // 判断是否正在使用WIFI网络
						Configer.usewifi = true;
					}

					state = connManager.getNetworkInfo(
							ConnectivityManager.TYPE_MOBILE).getState(); // 获取网络连接状态

					if (State.CONNECTED == state) { // 判断是否正在使用GPRS网络
						Configer.usewifi = false;

					}

				}
				if (!success) {
					Configer.connection = false;
					Configer.usewifi = false;
					Toast.makeText(context, "您的网络连接已中断", Toast.LENGTH_LONG)
							.show();
				}

			}else if(Intent.ACTION_BATTERY_CHANGED.equals(action)){
				int level = intent.getIntExtra(BatteryManager.EXTRA_LEVEL,0);
				int scale = intent.getIntExtra(BatteryManager.EXTRA_SCALE,0);
				int plug = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED,0);
				if(plug==2){//电充满了
					Configer.pluged = true ;
				}else if(plug==0)//没有连usb充电
				{
					Configer.pluged = false ;
				}else{
					Configer.pluged = true ;
				}
				float now = (float)level/(float)scale ;
				Utils.showLog(" the level is  ", String.valueOf(level)," the scale is ",String.valueOf(scale));
				Utils.showLog(" the plug is  ", String.valueOf(plug)," the now is  ", String.valueOf(now));
				Configer.battery_remain = now*100 ;
			}
		}
	};

	public void onCreate() {
		super.onCreate();
		connManager = (ConnectivityManager) getSystemService(CONNECTIVITY_SERVICE);
		IntentFilter filter = new IntentFilter();
		filter.addAction(ConnectivityManager.CONNECTIVITY_ACTION);
		filter.addAction(Intent.ACTION_BATTERY_CHANGED);
		registerReceiver(mReceiver, filter);

	};
	public void onDestroy() {
		super.onDestroy();
		unregisterReceiver(mReceiver);
	};
	PhoneStateListener phoneStateListen = new PhoneStateListener() {
		@Override
		public void onServiceStateChanged(ServiceState serviceState) {
			// TODO
			super.onServiceStateChanged(serviceState);
		}
		public void onDataConnectionStateChanged(int state) {

		};
		public void onSignalStrengthChanged(int asu) {

		};

	};

	@Override
	public IBinder onBind(Intent intent) {
		// TODO
		return null;
	}

}
