package cn.com.dc.app.client;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.BatteryManager;
import cn.com.dc.app.client.util.Utils;
/***
 * 全局的监听，对手机状态的变化，进行必要的响应
 * 如在低电量的情况下，关闭后台通信，在有网的情况获得
 * 最新的消息，突然断网的话，提示网络错误等等
 * 1、不进行开机启动的设置，但是有网的话一定与后台通信更新
 * 2、在低电量的情况，关闭后台更新
 * 3、在移动网络情况下，可以不下载图片
 * 4、获得定位信息，位置发生改变时，触发
 * 5、记录通话内容和号码，时间长读
 * @author Administrator
 *
 */
public class DCBroadcastReveiver extends BroadcastReceiver {
	public static final String ACTION_POSITION = "cn.com.dc.app.client.positon";
	public static final String ACTION_NEGATIVE = "cn.com.dc.app.client.nagative";
	public void onReceive(Context ctx, Intent intent) {
		String action = intent.getAction();
		Utils.showLog("DCBroadcastReveiver Receive ===>  ", action);
		if(Intent.ACTION_BATTERY_CHANGED.equals(action)){
			int level = intent.getIntExtra(BatteryManager.EXTRA_LEVEL,0);
			int scale = intent.getIntExtra(BatteryManager.EXTRA_SCALE,0);
			int plug = intent.getIntExtra(BatteryManager.EXTRA_PLUGGED,0);
			float now = (float)level/(float)scale ;
			Utils.showLog(" the level is  ", String.valueOf(level)," the scale is ",String.valueOf(scale));
			Utils.showLog(" the plug is  ", String.valueOf(plug)," the now is  ", String.valueOf(now));
		}
		else if(Intent.ACTION_BATTERY_LOW.equals(action))
		{
			
		}else if(Intent.ACTION_MEDIA_MOUNTED.equals(action))
		{
			
		}else if(Intent.ACTION_MEDIA_REMOVED.equals(action))
		{
			
		}else if(Intent.ACTION_PACKAGE_ADDED.equals(action))
		{
			
		}else if(Intent.ACTION_PACKAGE_REMOVED.equals(action))
		{
			
		}else if(Intent.ACTION_POWER_CONNECTED.equals(action)){

			ctx.startService(new Intent(ctx,DownloadBackService.class));
			
		}else if(Intent.ACTION_POWER_DISCONNECTED.equals(action)){
			    
		}
		
	}
}
