package cn.com.dc.app.client;

import java.io.IOException;
import java.lang.ref.SoftReference;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.List;

import android.app.Service;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.IBinder;
import cn.com.dc.app.client.util.DownLoadBiz;
import cn.com.dc.app.client.util.Utils;
/***
 * 用于下载用的Service
 * @author lynchxu
 *
 */
public class DownloadBackService extends Service {
	private static List<DownLoadBiz<SoftReference<Bitmap>,String>> downloadPool = null;
	private static Object mLock = new Object();
	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}
	
	@Override
	public void onCreate() {
		super.onCreate();
		Thread.currentThread().setPriority(Thread.MIN_PRIORITY);
		downloadThread.start();
		downloadThread.setPriority(Thread.MIN_PRIORITY);
		downloadPool = new ArrayList<DownLoadBiz<SoftReference<Bitmap>,String>>() ;
	}
	
	public synchronized static void addDownLoadPool(DownLoadBiz<SoftReference<Bitmap>,String> downlaod)
	{
		Utils.showLog("add the task to service");
		if(downloadPool!=null) //服务启动才可以下载，否则不能下载
		{
			Utils.showLog("downloadPool not null ");
			if(downlaod.t!=null&&!downlaod.t.equals("null")){
				downloadPool.add(downlaod);	
			}
			if(downloadPool.size()==1)//如果下载队列为空则需要唤醒，下载线程，如果不为空说明下载线程已经唤醒无需再唤醒
			{
				synchronized (mLock) {
					Utils.showLog("notifyAll.... ");
					mLock.notifyAll();
				}
			}	
		}
		
	}
	Thread downloadThread = new Thread(){
		@Override
		public  void run() {
			// TODO
			while (true) {
				synchronized (mLock) {
					if(downloadPool==null)
					{
						downloadPool = new ArrayList<DownLoadBiz<SoftReference<Bitmap>,String>>();
					}
					Utils.showLog("downloadThread  size is", String.valueOf(downloadPool.size()));
					if(downloadPool.size()==0){
						try {
							Utils.showLog("begin wait ... ");
							mLock.wait();
						} catch (InterruptedException e) {
							// TODO 
							e.printStackTrace();
						}
					}else{
						DownLoadBiz<SoftReference<Bitmap>,String> task = downloadPool.remove(0);
						//执行预处理
						task.preDownLoadBegin(task.t);
						//针对 URL 开始下载
						try {
							Utils.showLog("download url is ===>  ", task.t);
							URL url = new URL(task.t);
							URLConnection conn = url.openConnection();
							conn.connect();
							if(task.downloading(conn.getInputStream()))
							{
								task.onDowLoadOk(task.m);
							}else{
								task.downloadError("error");
							}
							
						} catch (MalformedURLException e) {
							// TODO 
							e.printStackTrace();
							task.downloadError("MalformedURLException");
						} catch (IOException e) {
							// TODO 
							e.printStackTrace();
							task.downloadError("IOException");
						}
					}
				}
			}
		}
	
	};
	
}
