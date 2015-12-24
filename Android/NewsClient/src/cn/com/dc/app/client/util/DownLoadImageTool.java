package cn.com.dc.app.client.util;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.lang.ref.SoftReference;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
/***
 * 继承实现下载的操作 通过 url string 来下载Bitmap，为了提高内存把Bitmap，通过SoftReference进行了封装。
 * 
 * @author lynchxu
 * 
 */
public class DownLoadImageTool
		extends
			DownLoadBiz<SoftReference<Bitmap>, String> {

	protected int pos;
	public DownLoadImageTool(String t, int pos) {
		super(t);
		this.pos = pos;
	}

	public void downloadError(String error) {
		// TODO download something wrong ...
		Utils.showLog(" download error ...");
	}

	@Override
	public void preDownLoadBegin(String t) {
		// TODO just begin download
		Utils.showLog("begin download ...");
	}

	public boolean downloading(InputStream input) {
		// TODO control the stream to bitmap or file or apk ....
		try {
			Bitmap bitmap = BitmapFactory.decodeStream(input);
			File file = Utils.getFileByURL(this.t);

			this.m = new SoftReference<Bitmap>(bitmap);
			if (file != null && !file.exists()) {//如果 file is null ，说明 sd卡不可用
				
				file.createNewFile();
				
				try {
					FileOutputStream fileOutputStream = new FileOutputStream(
							file.getAbsolutePath());

					BufferedOutputStream buffered = new BufferedOutputStream(
							fileOutputStream, 8000);
					if (this.t.endsWith("png")) {
						bitmap.compress(Bitmap.CompressFormat.PNG, 100,
								buffered);
					} else {
						bitmap.compress(Bitmap.CompressFormat.JPEG, 100,
								buffered);
					}
					buffered.flush();
					buffered.close();
					fileOutputStream.flush();
					fileOutputStream.close();
					Utils.showLog("saveBmp is ok here  ===> ",
							file.getAbsolutePath());
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
			return false;
		}
		return true;
	}
	@Override
	public void onDowLoadOk(SoftReference<Bitmap> m) {
		// TODO download complete ...
	}

}
