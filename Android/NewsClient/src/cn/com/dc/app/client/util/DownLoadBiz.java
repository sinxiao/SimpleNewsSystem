package cn.com.dc.app.client.util;

import java.io.InputStream;


/***
 * 异步下载处理用的类，主要下载图片
 * 
 * 下载图片时需要声明：
 * 		new DownLoadBiz<SoftReference<Bitmap>>();
 * 
 * @author lynchxu
 *
 * @param <M> 下载的类型不同，需要提前声明下载类型,保存后的形式，可以最后获得的对象
 * @param <T> 下载的来源，一般是string 类型的URL地址
 */
public abstract class DownLoadBiz<M,T> {
	public T t ;
	public M m ;
	public int pos ;
	public DownLoadBiz(T t)
	{
		this.t = t ;
	}
	public abstract void onDowLoadOk(M m);
	public abstract void preDownLoadBegin(T t);
	public abstract void downloadError(String error);
	public abstract boolean downloading(InputStream input);
}
