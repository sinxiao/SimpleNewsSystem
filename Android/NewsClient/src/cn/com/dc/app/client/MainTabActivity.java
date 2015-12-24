package cn.com.dc.app.client;

import java.lang.reflect.Field;
import java.util.Map;

import android.app.ActivityGroup;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.method.LinkMovementMethod;
import android.text.style.BackgroundColorSpan;
import android.text.style.URLSpan;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.FrameLayout;
import android.widget.RadioButton;
import android.widget.TabHost;
import android.widget.TabHost.TabSpec;
import android.widget.TabWidget;
import android.widget.TextView;
import cn.com.dc.app.client.util.Utils;

@SuppressWarnings("deprecation")
public class MainTabActivity extends ActivityGroup {
	public static TabHost tab_host;
	public static TabWidget tab_widget;

	public static boolean flag = true;
	public static TextView textView;
	private static int DELAYD_TIME = 2;

	private RadioButton fbNews;
	private RadioButton fbQuestion;
	private RadioButton fbTweet;
	private RadioButton fbactive;

	private Map<String, String> bottomAdMap = null;
	public static Handler handler = null;
	private boolean tab = false;
	private View newsView;
	// private View snsView;
	private View picView;
	private FrameLayout mainFrame;
	private Button btnNews, btnSns, btnPic;

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		if (tab) {
			setContentView(R.layout.activity_start_main);
			initTab();
		} else {
			setContentView(R.layout.activity_main_screan);

			mainFrame = (FrameLayout) findViewById(R.id.mainFrame);

			// btnNews = (Button) findViewById(R.id.btnNews);

			Intent intent = new Intent(this, TabNewsItemActivity.class);
			intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

			Window subActivity = getLocalActivityManager().startActivity(
					"news", intent);
			View contentView = subActivity.getDecorView();
			contentView.dispatchWindowFocusChanged(true);
			newsView = contentView;
			mainFrame.removeAllViews();
			mainFrame.addView(contentView);

			fbNews = (RadioButton) findViewById(R.id.main_footbar_news);
			fbQuestion = (RadioButton) findViewById(R.id.main_footbar_question);
			fbTweet = (RadioButton) findViewById(R.id.main_footbar_tweet);
			fbactive = (RadioButton) findViewById(R.id.main_footbar_active);

			fbNews.setChecked(true);

			fbNews.setOnCheckedChangeListener(rdoListener);
			fbQuestion.setOnCheckedChangeListener(rdoListener);
			fbTweet.setOnCheckedChangeListener(rdoListener);
			fbactive.setOnCheckedChangeListener(rdoListener);

			// btnNews.setOnClickListener(click);
			// btnSns.setOnClickListener(click);
			// btnPic.setOnClickListener(click);
		}
	}

	private CompoundButton.OnCheckedChangeListener rdoListener = new CompoundButton.OnCheckedChangeListener() {

		public void onCheckedChanged(CompoundButton buttonView,
				boolean isChecked) {
			if (isChecked) {
				switch (buttonView.getId()) {
				case R.id.main_footbar_news:
					if (newsView == null) {
						Intent intent = new Intent(MainTabActivity.this,
								TabNewsItemActivity.class);
						intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

						Window subActivity = MainTabActivity.this
								.getLocalActivityManager().startActivity(
										"news", intent);
						newsView = subActivity.getDecorView();
						newsView.dispatchWindowFocusChanged(true);
					}
					if (newsView != null) {
						mainFrame.removeAllViews();
						mainFrame.addView(newsView);
					}
					break;
				case R.id.main_footbar_active:
					break;
				case R.id.main_footbar_question:
					if (picView == null) {
						Intent intent = new Intent(MainTabActivity.this,
								TabSettingActivity.class);
						intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

						Window subActivity = MainTabActivity.this
								.getLocalActivityManager().startActivity("set",
										intent);
						picView = subActivity.getDecorView();
						picView.dispatchWindowFocusChanged(true);
					}
					if (picView != null) {
						mainFrame.removeAllViews();
						mainFrame.addView(picView);
					}

					break;
				case R.id.main_footbar_setting:
					break;
				case R.id.main_footbar_tweet:
					break;
				default:
					break;
				}
			}
		}
	};

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// TODO
		menu.add(0, 0, 1, "刷新");
		menu.add(0, 1, 2, "退出");
		return super.onCreateOptionsMenu(menu);
	}

	public DCApplication getDCApplication() {
		return (DCApplication) getApplication();
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// TODO
		switch (item.getItemId()) {
		case 0:
			getDCApplication().getNowActivity().fresh();
			break;
		case 1:

			break;
		default:
			break;
		}
		return super.onOptionsItemSelected(item);
	}

	public void showFinish() {
		AlertDialog mDialog = new AlertDialog.Builder(this).setTitle("infor")
				.setMessage("Are you sure exit now ?")
				.setPositiveButton("", new DialogInterface.OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {
						// TODO
						dialog.dismiss();
						finish();
					}
				}).setNegativeButton("", new DialogInterface.OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {
						// TODO
						dialog.dismiss();
					}
				}).create();
		mDialog.show();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		// TODO
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			showFinish();
			return false;
		}
		return super.onKeyDown(keyCode, event);
	}

	private void restBtn() {
		// btnNews.setBackgroundColor(Color.TRANSPARENT);
		// btnSns.setBackgroundColor(Color.TRANSPARENT);
		// btnPic.setBackgroundColor(Color.TRANSPARENT);
		// btnNews.setEnabled(true);
		// btnSns.setEnabled(true);
		// btnPic.setEnabled(true);
	}

	private void setCheck(Button btn) {
		restBtn();
		// btn.setBackgroundResource(R.drawable.tab_front_bg);
		btn.setEnabled(false);
	}

	OnClickListener click = new View.OnClickListener() {

		public void onClick(View v) {
			// TODO
			switch (v.getId()) {
			case R.id.btnNews:
				setCheck(btnNews);
				if (newsView == null) {
					Intent intent = new Intent(MainTabActivity.this,
							TabNewsItemActivity.class);
					intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

					Window subActivity = MainTabActivity.this
							.getLocalActivityManager().startActivity("news",
									intent);
					newsView = subActivity.getDecorView();
					newsView.dispatchWindowFocusChanged(true);
				}
				if (newsView != null) {
					mainFrame.removeAllViews();
					mainFrame.addView(newsView);
				}
				break;
			// case R.id.btnSns :
			// setCheck(btnSns);
			// if (snsView == null) {
			// Intent intent = new Intent(MainTabActivity.this,
			// TabCommentActivity.class);
			// intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			//
			// Window subActivity = MainTabActivity.this
			// .getLocalActivityManager().startActivity(
			// "news", intent);
			// snsView = subActivity.getDecorView();
			// snsView.dispatchWindowFocusChanged(true);
			// }
			// if (snsView != null) {
			// mainFrame.removeAllViews();
			// mainFrame.addView(snsView);
			// }
			// break;
			// case R.id.btnPic :
			// setCheck(btnPic);
			// if (picView == null) {
			// Intent intent = new Intent(MainTabActivity.this,
			// TabSettingActivity.class);
			// intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
			//
			// Window subActivity = MainTabActivity.this
			// .getLocalActivityManager().startActivity(
			// "news", intent);
			// picView = subActivity.getDecorView();
			// picView.dispatchWindowFocusChanged(true);
			// }
			// if (picView != null) {
			// mainFrame.removeAllViews();
			// mainFrame.addView(picView);
			// }
			// break;
			default:
				break;
			}
		}
	};

	private void initTab() {
		// 处理文字广告
		textView = (TextView) this.findViewById(R.id.ad_textView);
		textView.setBackgroundColor(Color.WHITE);
		handler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				if (bottomAdMap != null) {
					textView.setVisibility(View.VISIBLE);
					String key = (String) bottomAdMap.keySet().toArray()[msg.what];
					String value = bottomAdMap.get(key);
					SpannableString sp = new SpannableString(key);
					sp.setSpan(new URLSpan(value), 0, key.length(),
							Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
					sp.setSpan(new BackgroundColorSpan(Color.WHITE), 0,
							key.length(), Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
					textView.setText(sp);
					textView.setMovementMethod(LinkMovementMethod.getInstance());
				} else {
					textView.setVisibility(View.GONE);
				}
			}
		};

		tab_host = (TabHost) findViewById(R.id.main_tab_host);
		tab_widget = (TabWidget) findViewById(android.R.id.tabs);
		// ActivityManager manager = (ActivityManager)
		// getSystemService(ACTIVITY_SERVICE);
		tab_host.setup(getLocalActivityManager());

		TabSpec ts1 = tab_host.newTabSpec("TAB_ITEM");
		ts1.setIndicator("");
		// Intent itt = new Intent(this, CommenNewsActivity.class);
		// itt.putExtra("view_type", "100");
		// itt.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		// ts1.setContent(itt);
		ts1.setContent(new Intent(this, TabNewsItemActivity.class));

		tab_host.addTab(ts1);

		TabSpec ts2 = tab_host.newTabSpec("TAB_COMMENT");
		ts2.setIndicator("");
		ts2.setContent(new Intent(this, TabCommentActivity.class));
		tab_host.addTab(ts2);

		TabSpec ts3 = tab_host.newTabSpec("TAB_SETTING");
		ts3.setIndicator("");
		ts3.setContent(new Intent(this, TabSettingActivity.class));
		tab_host.addTab(ts3);

		Field mBottomLeftStrip;
		Field mBottomRightStrip;
		if (Integer.valueOf(Build.VERSION.SDK) <= 7) {
			try {
				mBottomLeftStrip = tab_widget.getClass().getDeclaredField(
						"mBottomLeftStrip");
				mBottomRightStrip = tab_widget.getClass().getDeclaredField(
						"mBottomRightStrip");
				if (!mBottomLeftStrip.isAccessible()) {
					mBottomLeftStrip.setAccessible(true);
				}
				if (!mBottomRightStrip.isAccessible()) {
					mBottomRightStrip.setAccessible(true);
				}
				mBottomLeftStrip.set(tab_widget,
						getResources().getDrawable(R.drawable.line));
				mBottomRightStrip.set(tab_widget,
						getResources().getDrawable(R.drawable.line));
			} catch (Exception e) {
				e.printStackTrace();
			}
		} else {
			try {
				mBottomLeftStrip = tab_widget.getClass().getDeclaredField(
						"mLeftStrip");
				mBottomRightStrip = tab_widget.getClass().getDeclaredField(
						"mRightStrip");
				if (!mBottomLeftStrip.isAccessible()) {
					mBottomLeftStrip.setAccessible(true);
				}
				if (!mBottomRightStrip.isAccessible()) {
					mBottomRightStrip.setAccessible(true);
				}
				mBottomLeftStrip.set(tab_widget,
						getResources().getDrawable(R.drawable.line));
				mBottomRightStrip.set(tab_widget,
						getResources().getDrawable(R.drawable.line));
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		for (int i = 0; i < tab_widget.getChildCount(); i++) {
			View vvv = tab_widget.getChildAt(i);
			vvv.getLayoutParams().height = Utils.dip2px(this, 50);
			vvv.setBackgroundResource(GetTabResId(i));
		}

		tab_host.setCurrentTab(0);
	}

	int GetTabResId(int id) {
		int resId = R.drawable.tab_bg_about;
		if (id == 0) {
			resId = R.drawable.tab_bg_token;
		} else if (id == 1) {
			resId = R.drawable.tab_bg_set;
		} else {
			resId = R.drawable.tab_bg_about;
		}
		return resId;
	}

}
