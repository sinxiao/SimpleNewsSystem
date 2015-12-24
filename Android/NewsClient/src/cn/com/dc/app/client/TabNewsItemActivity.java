package cn.com.dc.app.client;

import java.lang.ref.SoftReference;
import java.util.HashMap;

import android.app.ActivityGroup;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.GestureDetector;
import android.view.GestureDetector.OnGestureListener;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.PopupWindow;
import android.widget.RadioButton;
import android.widget.TabHost;
import android.widget.TabHost.TabSpec;
import android.widget.TabWidget;
import android.widget.ViewFlipper;
import cn.com.dc.app.client.util.Utils;

/**
 * 显示各种新闻列表
 * 
 * @author Administrator
 * 
 */
public class TabNewsItemActivity extends ActivityGroup {
	private HashMap<String, SoftReference<Bitmap>> bitmapcatch = new HashMap<String, SoftReference<Bitmap>>();
	private static final int VIEW_NEWS = 0; // itemId = 5 ;
	private static final int VIEW_AIR = 1; // 14
	private static final int VIEW_OLDS = 2; // 15
	private static final int VIEW_FNEWS = 3; // 16
	
	
	
	
	private ImageView fbSetting;
	private Button btnNews, btnAir, btnOlds, btnFNews;
	private ViewFlipper pageFlipper;
	private GestureDetector detector;
	private LayoutInflater mInflater;
	private View mainAll;
	private boolean tab = true;
	private TabHost tab_host;
	private TabWidget tab_widget;   
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		mInflater = LayoutInflater.from(this);
		if (tab) {
			setContentView(R.layout.news_itemstab);
			tab_host = (TabHost) findViewById(R.id.main_tab_host);
			tab_widget = (TabWidget) findViewById(android.R.id.tabs);

			tab_host.setup(getLocalActivityManager());    
			tab_host.setup();

			TabSpec ts1 = tab_host.newTabSpec("VIEW_NEWS");
			ts1.setIndicator("1");
//			Intent itt = new Intent(this, CommenNewsActivity.class);
			Intent itt = new Intent(getParent(), CommenNewsActivity.class);
			itt.putExtra("view_type", VIEW_NEWS);
			itt.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			ts1.setContent(itt);

			TabSpec ts2 = tab_host.newTabSpec("VIEW_AIR");
			ts2.setIndicator("2");
			Intent itt2 = new Intent(getParent(), CommenNewsActivity.class);
			itt2.putExtra("view_type", VIEW_AIR);
			itt2.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			ts2.setContent(itt2);

			TabSpec ts3 = tab_host.newTabSpec("VIEW_OLDS");
			ts3.setIndicator("3");
			Intent itt3 = new Intent(getParent(), CommenNewsActivity.class);
			itt3.putExtra("view_type", VIEW_OLDS);
			itt3.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			ts3.setContent(itt3);

			TabSpec ts4 = tab_host.newTabSpec("VIEW_FNEWS");
			ts4.setIndicator("4");
			Intent itt4 = new Intent(getParent(), CommenNewsActivity.class);
			itt4.putExtra("view_type", VIEW_FNEWS);
			itt4.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			ts4.setContent(itt4);

			tab_host.addTab(ts1);
			tab_host.addTab(ts2);
			tab_host.addTab(ts3);
			tab_host.addTab(ts4);
			
			btnNews = (Button) findViewById(R.id.btnNews);
			btnAir = (Button) findViewById(R.id.btnAir);
			btnOlds = (Button) findViewById(R.id.btnOlds);
			btnFNews = (Button) findViewById(R.id.btnFNews);
			
			btnNews.setOnClickListener(onclick);
			btnAir.setOnClickListener(onclick);
			btnOlds.setOnClickListener(onclick);
			btnFNews.setOnClickListener(onclick);

	    	
		} else {
			setContentView(R.layout.news_items);
			btnNews = (Button) findViewById(R.id.btnNews);
			btnAir = (Button) findViewById(R.id.btnAir);
			btnOlds = (Button) findViewById(R.id.btnOlds);
			btnFNews = (Button) findViewById(R.id.btnFNews);
			mainAll = findViewById(R.id.mainAll);

			btnNews.setOnClickListener(onclick);
			btnAir.setOnClickListener(onclick);
			btnOlds.setOnClickListener(onclick);
			btnFNews.setOnClickListener(onclick);

			pageFlipper = (ViewFlipper) findViewById(R.id.pageFlipper);
			// detector = new GestureDetector(listener);

			pageFlipper.addView(getPageById(VIEW_NEWS));
			pageFlipper.addView(getPageById(VIEW_AIR));
			pageFlipper.addView(getPageById(VIEW_OLDS));
			pageFlipper.addView(getPageById(VIEW_FNEWS));
		}

		// getNewsDataByType(VIEW_NEWS);

		// pageFlipper.startFlipping();
	}
	private void restBtn(){    
//		btnNews.setTextColor(Color.parseColor("#ffff00"));
//		btnAir.setTextColor(Color.parseColor("#ffff00"));
//		btnOlds.setTextColor(Color.parseColor("#ffff00"));
//		btnFNews.setTextColor(Color.parseColor("#ffff00"));
//		
//		btnNews.setBackgroundColor(Color.TRANSPARENT);
//		btnFNews.setBackgroundColor(Color.TRANSPARENT);
//		btnAir.setBackgroundColor(Color.TRANSPARENT);
//		btnOlds.setBackgroundColor(Color.TRANSPARENT);
		
		btnNews.setEnabled(true);
		btnFNews.setEnabled(true);
		btnAir.setEnabled(true);
		btnOlds.setEnabled(true);
	}
	private void setChecked(Button btn)
	{
		restBtn();
//		btn.setBackgroundResource(R.drawable.top_channel_bg_selected);
//		btn.setTextColor(Color.WHITE);
		btn.setEnabled(false);
	}
	private void restRdBtn()
	{
		
	}
	private View.OnClickListener onclick = new View.OnClickListener() {

		@Override
		public void onClick(View v) {
			// TODO
			Intent intent = new Intent(CommenNewsActivity.PAGE_CHANGE);
			switch (v.getId()) {
				case R.id.btnAir :
					if (tab) {
						setChecked(btnAir);
						tab_host.setCurrentTab(1);
					} else {
						intent.putExtra(CommenNewsActivity.NOW_PAGE, VIEW_AIR);
						TabNewsItemActivity.this.sendBroadcast(intent);
						pageFlipper.setDisplayedChild(1);
					}
					break;
				case R.id.btnFNews :
					// getNewsDataByType(VIEW_FNEWS);
					if (tab) {
						setChecked(btnFNews);
						tab_host.setCurrentTab(3);
					} else {

						intent.putExtra(CommenNewsActivity.NOW_PAGE, VIEW_FNEWS);
						TabNewsItemActivity.this.sendBroadcast(intent);
						pageFlipper.setDisplayedChild(3);
					}
					break;
				case R.id.btnNews :
					if (tab) {
						setChecked(btnNews);
						tab_host.setCurrentTab(0);
					} else {
						intent.putExtra(CommenNewsActivity.NOW_PAGE, VIEW_NEWS);
						TabNewsItemActivity.this.sendBroadcast(intent);
						pageFlipper.setDisplayedChild(0);
					}
					break;
				case R.id.btnOlds :
					if (tab) {
						setChecked(btnOlds);
						tab_host.setCurrentTab(2);
					} else {
						intent.putExtra(CommenNewsActivity.NOW_PAGE, VIEW_OLDS);
						pageFlipper.setDisplayedChild(2);
					}
					break;
				// case R.id.btnLeft :
				//
				// break;
				// case R.id.btnRight :
				// break;
				default :
					break;
			}
		}
	};

	private ProgressDialog progWait;

	private boolean click = false;

	private void dismissPop() {
		if (mpopup != null) {
			mpopup.dismiss();
			click = false;
			mpopup = null;
		}
	}
	public boolean onKeyDown(int keyCode, android.view.KeyEvent event) {
		Utils.showLog(" the keycode is ===== " + event.getKeyCode(),
				String.valueOf(keyCode));
		dismissPop();
		return super.onKeyDown(keyCode, event);
	};
	private PopupWindow mpopup;

	/**
	 * 通过layoutId获得视图
	 * 
	 * @param resId
	 *            layout Id 
	 * @return 视图对象
	 */
	private View getViewByLayoutId(int resId) {
		return mInflater.inflate(resId, null);
	}

	/**
	 * 通过Id获得视图对象
	 * 
	 * @param viewId
	 *            视图对象标示
	 * @return 用来显示新闻的对象
	 */
	private View getPageById(int viewId) {
		View contentView = null;
		switch (viewId) {
			case VIEW_NEWS :
				contentView = bindNewsViews(VIEW_NEWS);
				// bindNewsData();
				break;
			case VIEW_AIR :
				contentView = bindNewsViews(VIEW_AIR);
				break;
			case VIEW_OLDS :
				contentView = bindNewsViews(VIEW_OLDS);
				break;
			case VIEW_FNEWS :
				contentView = bindNewsViews(VIEW_FNEWS);
				break;
			default :
				break;
		}
		return contentView;
	}

	// public boolean onTouchEvent(MotionEvent event) {
	// // TODO
	// Utils.showLog("onTouch ...");
	// // return detector.onTouchEvent(event);
	// return super.onTouchEvent(event);
	// }

	/**
	 * 获得显示信息的控件
	 * 
	 * @return
	 */
	private View bindNewsViews(int type) {
		// getL
		Intent intent = new Intent(getParent(), CommenNewsActivity.class);
		intent.putExtra("view_type", type);
		intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

		Window subActivity = ((ActivityGroup) getParent())
				.getLocalActivityManager().startActivity("newsact" + type,
						intent);	
		View contentView = subActivity.getDecorView();
		contentView.dispatchWindowFocusChanged(true);        
		// startActivity(intent);
		// return null ;   
		// View contentView = getViewByLayoutId(R.layout.mixed_news);
		// lsVNews = (ListView) contentView.findViewById(R.id.lstNews);
		// galyNews = (Gallery) contentView.findViewById(R.id.galleryHot);
		// lsVNews.setOnTouchListener(new View.OnTouchListener() {
		//
		// @Override
		// public boolean onTouch(View v, MotionEvent event) {
		// // TODO
		// Utils.showLog("lsVNews on touch ");
		// // dismissPop();
		// return detector.onTouchEvent(event);
		// }
		// });
		return contentView;
	}

	/**
	 * 左右滑动切换界面
	 */
	OnGestureListener listener = new OnGestureListener() {

		public boolean onSingleTapUp(MotionEvent e) {
			return false;
		}

		public void onShowPress(MotionEvent e) {

		}

		public boolean onScroll(MotionEvent e1, MotionEvent e2,
				float distanceX, float distanceY) {
			return false;
		}

		public void onLongPress(MotionEvent e) {

		}

		public boolean onFling(MotionEvent e1, MotionEvent e2, float velocityX,
				float velocityY) {
			int idx = pageFlipper.getDisplayedChild();
			Utils.showLog("the child idx is ", String.valueOf(idx));
			int count = pageFlipper.getChildCount();
			if ((e1.getX() - e2.getX()) > 100) // next
			{

				if (count == idx + 1)
					pageFlipper.setDisplayedChild(0);
				else
					pageFlipper.showNext();
				return true;
			} else if ((e1.getX() - e2.getX()) < -100) // preview
			{
				pageFlipper.showPrevious();
				return true;
			}
			// idx = pageFlipper.getDisplayedChild();
			// if (idx == 2) {
			//
			// }

			return false;
		}

		public boolean onDown(MotionEvent e) {
			return false;
		}
	};

}
