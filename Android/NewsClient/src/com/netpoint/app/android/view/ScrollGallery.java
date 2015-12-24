package com.netpoint.app.android.view;

import android.content.Context;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.widget.Gallery;

/**
 * 自动滚动Gallery 并非顺序循环
 * 
 * @author tom
 * 
 */
public class ScrollGallery extends Gallery implements Runnable {

	private long newScroll = 1000;// 滚动时间
	private boolean flag = false;// 自动滚动标示
	private Thread thread = null; // 自动滚动线程
	private int postion = -1;// 当前选中item索引

	public ScrollGallery(Context context) {
		super(context);
		init();
	}

	public ScrollGallery(Context context, AttributeSet attrs) {
		super(context, attrs);
		init();
	}

	private void init() {
		thread = new Thread(this);
	}

	public void run() {
		while (flag) {
			try {
				Thread.sleep(newScroll);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			computerPostion();
		}
	}
	
	/**
	 * 并非循环计算..目前先这样...后期在改...
	 */
	private void computerPostion() {
		postion++;
		if (postion < getCount() - 1) {
			setSelection(postion);
		} else {
			setSelection(0);
			postion = 0;
		}
	}

	/**
	 * 启动滚动默认为1秒
	 */
	public void startScroll() {
		flag = true;
		thread.start();
	}

	/**
	 * 停止自动滚动
	 */
	public void stopScroll() {
		postion = -1;
		flag = false;
	}

	/**
	 * 获取当前自动滚动时间
	 * 
	 * @return 时间为毫秒
	 */
	public long getNewScroll() {
		return newScroll;
	}

	/**
	 * 设置滚动时间
	 * 
	 * @param newScroll
	 *            时间为毫秒
	 */
	public void setNewScroll(long newScroll) {
		this.newScroll = newScroll;
	}

	@Override
	public boolean onFling(MotionEvent e1, MotionEvent e2, float velocityX,
			float velocityY) {
		// TODO Auto-generated method stub
		return false;
	}

}
