package cn.com.dc.app.client;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.GestureDetector;
import android.view.GestureDetector.OnGestureListener;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ViewFlipper;
import cn.com.dc.app.client.util.Utils;


public class StartMainActivity extends Activity {

	private ViewFlipper pageFlipper;
	private GestureDetector detector;
	private int first;
	private Button btnStart;

	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.first_splash);
		first = Utils.readIntValueFromSpc(this, Utils.APP_FIRST_INIT, 0);
		Utils.showLog("the first is "+first);
		if (Utils.True == first)// 第一次启动App
		{// 第一次启动程序时 执行的操作 如出现帮助，显示提示
			// Utils.saveIntValueIntoSpc(this, Utils.APP_FIRST_INIT,
			// Utils.Flase);

			pageFlipper = (ViewFlipper) findViewById(R.id.pageFlipper);   
			pageFlipper.setVisibility(View.VISIBLE);
			detector = new GestureDetector(gestureListener);

			pageFlipper.addView(addStartView(R.drawable.start_1));
			pageFlipper.addView(addStartView(R.drawable.start_2));
			pageFlipper.addView(addStartView(R.drawable.start_3));
			
			btnStart = (Button) findViewById(R.id.btnStart);
			btnStart.setOnClickListener(startClick);

		}else{
			Message msg = mHandle.obtainMessage();
			mHandle.sendMessageDelayed(msg, 2500);
		}

	}
	private Handler mHandle = new Handler()
	{
		public void handleMessage(android.os.Message msg) {
			beginNewWorld();
		};
	};
//	@TargetApi(5)
	private void beginNewWorld()
	{
		startActivity(new Intent(StartMainActivity.this,MainTabActivity.class));
//		overridePendingTransition(R.anim.slide_right, R.anim.slide_left);
		finish();
	}
	private View.OnClickListener startClick = new View.OnClickListener() {

		public void onClick(View v) {
			beginNewWorld();
		}
	};

	@Override
	public boolean onTouchEvent(MotionEvent event) {
		// TODO Auto-generated method stub
		if (Utils.True == first)// 第一次启动App
		{
			return detector.onTouchEvent(event);
		}
		return super.onTouchEvent(event);
	}

	private View addStartView(int resId) {
		ImageView igv = new ImageView(this);
		igv.setBackgroundResource(resId);
		return igv;
	}

	OnGestureListener gestureListener = new OnGestureListener() {

		@Override
		public boolean onSingleTapUp(MotionEvent e) {
			// TODO Auto-generated method stub
			return false;
		}

		@Override
		public void onShowPress(MotionEvent e) {
			// TODO Auto-generated method stub

		}

		@Override
		public boolean onScroll(MotionEvent e1, MotionEvent e2,
				float distanceX, float distanceY) {
			// TODO Auto-generated method stub
			return false;
		}

		@Override
		public void onLongPress(MotionEvent e) {
			// TODO Auto-generated method stub

		}

		@Override
		public boolean onFling(MotionEvent e1, MotionEvent e2, float velocityX,
				float velocityY) {
			// TODO Auto-generated method stub
			int idx = pageFlipper.getDisplayedChild();
			Utils.showLog("the child idx is " ,String.valueOf(idx));
			if ((e1.getX() - e2.getX()) > 100) // next
			{
				pageFlipper.showNext();
				return true;
			} else if ((e1.getX() - e2.getX()) < -100) // preview
			{
				pageFlipper.showPrevious();
				pageFlipper.getDisplayedChild();
				return true;
			}
			idx = pageFlipper.getDisplayedChild();
			if (idx == 2) {
				btnStart.setVisibility(View.VISIBLE);
			}
			return false;
		}

		@Override
		public boolean onDown(MotionEvent e) {
			// TODO Auto-generated method stub
			return false;
		}
	};

}
