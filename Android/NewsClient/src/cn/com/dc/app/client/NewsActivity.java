package cn.com.dc.app.client;

import android.os.Bundle;
import android.view.View;
import android.widget.ListView;

public class NewsActivity extends BaseActivity {

	private ListView listView;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.news);
		findView();
		initlistener();
		init();
	}

	private void initlistener() {
		// TODO Auto-generated method stub

	}

	private void findView() {
		// TODO Auto-generated method stub

	}

	private void init() {
		// TODO Auto-generated method stub

	}

	/**
	 * 点击新闻按钮
	 * 
	 * @param view
	 */
	public void clickNews(View view) {

	}

	/**
	 * 点击互动按钮
	 * 
	 * @param view
	 */
	public void clickInteraction(View view) {

	}

	/**
	 * 点击课程按钮
	 * 
	 * @param view
	 */
	public void clickCourse(View view) {

	}

	/**
	 * 点击广场按钮
	 * 
	 * @param view
	 */
	public void clickSquare(View view) {

	}
	
	/**
	 * 点击更多按钮
	 * 
	 * @param view
	 */
	public void clickMore(View view) {

	}

}
