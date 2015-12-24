package cn.com.dc.app.client;

import android.app.Activity;
import android.os.Bundle;

public class DCActivity extends Activity {

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		getDCApplication().addChild(this);
	}
	protected DCApplication getDCApplication() {
		return (DCApplication) getApplication();
	}

	protected void onResume() {
		super.onResume();
		synchronized (this) {
			getDCApplication().setNowDcActivity(this);
		}
	}

	protected void onPause() {
		super.onPause();
	}

	protected void onDestroy() {
		super.onDestroy();
		getDCApplication().remove(this);
	}
	/**
	 * 实现刷新界面的功能
	 */
	public void fresh() {

	}
}
