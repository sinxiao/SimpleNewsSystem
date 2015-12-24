package cn.com.dc.app.client;

import java.io.UnsupportedEncodingException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.json.JSONException;

import android.app.ProgressDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.Button;
import android.widget.Gallery;
import android.widget.ImageView;
import android.widget.PopupWindow;
import android.widget.ProgressBar;
import android.widget.Toast;
import cn.com.dc.app.client.CustomListView.OnRefreshListener;
import cn.com.dc.app.client.bean.Twitter;
import cn.com.dc.app.client.util.Configer;
import cn.com.dc.app.client.util.Json2Object;
import cn.com.dc.app.client.util.PostDataAsyncTask;
import cn.com.dc.app.client.util.TaskDeal;
import cn.com.dc.app.client.util.Utils;

public class CommenTwiterActivity extends DCActivity {
	private static final int VIEW_NEWS = 0; // itemId = 5 ;
	private static final int VIEW_AIR = 1; // 14
	private static final int VIEW_OLDS = 2; // 15
	private static final int VIEW_FNEWS = 3; // 16
	private int PAGE_COUNT = 3;
	private CustomListView lsVNews;
	private Gallery galyNews;
	private int news_type;
	private TwitterAdapter newsAdapter;
	private List<Twitter> listTwitter;
	private ProgressDialog progWait;
	// private CustomListView custLstView ;
	private void showWait(String msg) {
		if (progWait == null) {
			progWait = new ProgressDialog(getParent());
			if (msg != null) {
				progWait.setMessage(msg);
			} else
				progWait.setMessage(getResources().getString(R.string.tip_wait));

		}
		progWait.show();
	}
	private LayoutInflater mInflater;
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.mixed_news);
		mInflater = LayoutInflater.from(this);

		lsVNews = (CustomListView) findViewById(R.id.lstNews);

		lsVNews.setOnRefreshListener(new OnRefreshListener() {
			public void onRefresh() {
				// TODO
				getNewsDataByType(news_type);
			}
		});

		galyNews = (Gallery) findViewById(R.id.galleryHot);
		news_type = getIntent().getIntExtra("view_type", 0);
		IntentFilter filter = new IntentFilter(PAGE_CHANGE);
		registerReceiver(mReceiver, filter);
		Utils.showLog("onCreate " + news_type);
		getNewsDataByType(news_type);

	}
	
	protected void onDestroy() {
		// TODO
		super.onDestroy();
		unregisterReceiver(mReceiver);
		Utils.showLog("onDestroy ", String.valueOf(news_type));
	}
	
	protected void onPause() {
		// TODO
		super.onPause();
		Utils.showLog("onPause ", String.valueOf(news_type));
	}
	public static final String PAGE_CHANGE = "cn.com.dc.app.client.pagechange";
	private int nowpage = VIEW_NEWS;
	
	public static String NOW_PAGE = "nowpage";
	private BroadcastReceiver mReceiver = new BroadcastReceiver() {

		@Override
		public void onReceive(Context context, Intent intent) {
			// TODO
			String action = intent.getAction();
			if (action.equals(PAGE_CHANGE)) {
				nowpage = intent.getIntExtra(NOW_PAGE, VIEW_NEWS);
			} else {

			}
		}
	};
	@Override
	protected void onResume() {
		// TODO
		super.onResume();
		if (newsAdapter != null) {
			newsAdapter.notifyDataSetChanged();
		}
		Utils.showLog("onResume ", String.valueOf(news_type));
	}

	public void fresh() {
		super.fresh();
		first = true ;
		getNewsDataByType(news_type);

	}
	private void dismissWait() {

		runOnUiThread(new Runnable() {
			public void run() {
				// TODO
				if (progWait != null) {
					progWait.dismiss();
					if (!progWait.isShowing()) {
						progWait = null;
					}
				}
				// custLstView.onLoadComplete();
				lsVNews.onRefreshComplete();
			}
		});
	}
	/***
	 * 长按一条新闻显示出操作选项
	 */
	private OnItemLongClickListener newsLongClick = new OnItemLongClickListener() {

		public boolean onItemLongClick(AdapterView<?> views, View view,
				int idx, long itemId) {
			PopupWindow popup = Utils.getPopupWindow(CommenTwiterActivity.this,
					R.layout.popup_menu);
			// popup.showAtLocation(TabNewsItemActivity.this.getWindow().getDecorView(),Gravity.CENTER,0,0);
			popup.showAsDropDown(view);
			mpopup = popup;
			// click = true ;
			return true;
		}
	};
	private Button btnMore;
	private ProgressBar prgWait;
	private View getFootView(final int type) {
		// FootView fv = new FootView(this, type);
		// fv.setLayoutParams(new
		// ViewGroup.LayoutParams(ViewGroup.LayoutParams.FILL_PARENT,
		// ViewGroup.LayoutParams.WRAP_CONTENT));

		View vw = mInflater.inflate(R.layout.footview, null);
		btnMore = (Button) vw.findViewById(R.id.btnMore);
		prgWait = (ProgressBar) vw.findViewById(R.id.prgWait);

		// ViewGroup.LayoutParams layoutParam = new
		// ViewGroup.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT,
		// ViewGroup.LayoutParams.WRAP_CONTENT);
		// layoutParam.height = ViewGroup.LayoutParams.WRAP_CONTENT;
		// layoutParam.width = ViewGroup.LayoutParams.WRAP_CONTENT;
		// LayoutParams
		// btn.setLayoutParams(layoutParam);
		System.out.println(btnMore.getLayoutParams().getClass().toString());
		btnMore.setText(R.string.more);
		btnMore.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				prgWait.setVisibility(View.VISIBLE);
				v.setVisibility(View.GONE);
				getNewsDataByType(type);
			}
		});

		return vw;
	}
	/***
	 * 向控件上绑定数据
	 * 
	 * @param contentView
	 */
	private void bindNewsData() {
		if (lsVNews != null && galyNews != null) {
			if (newsAdapter == null) {

				lsVNews.addFooterView(getFootView(news_type));

				newsAdapter = new TwitterAdapter(listTwitter, this, mHandler);
				lsVNews.setAdapter(newsAdapter);

				lsVNews.setOnItemClickListener(newsClick);
				lsVNews.setOnItemLongClickListener(newsLongClick);
			} else {
				Utils.showLog("has changing ...");
//				runOnUiThread(new Runnable() {
//					@Override
//					public void run() {
//						// TODO
//						
//						
//					}
//				});
				if (btnMore != null) {
					btnMore.setVisibility(View.VISIBLE);
				}
				if (prgWait != null && prgWait.isShown()) {
					prgWait.setVisibility(View.GONE);
				}
//				ArrayAdapter<NewsBean> ader = new ArrayAdapter<NewsBean>(this, resource, textViewResourceId, objects);
				
				newsAdapter.notifyDataSetChanged();
				Utils.showLog("has changeed ...");

			}

		}
		lsVNews.onRefreshComplete();
		// custLstView.onLoadComplete();
	}

	private PopupWindow mpopup;
	private boolean click = false;
	private void dismissPop() {
		if (mpopup != null) {
			mpopup.dismiss();
			click = false;
			mpopup = null;
		}
	}
	/***
	 * 获取新闻的后台操作
	 */
	private void getNewsDataByType(int view) {
		// http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=102&arg=5
		StringBuffer url = new StringBuffer(Configer.NEWS_BIZ
				+ "?method=102&arg=");
		int itemId = 0;
		List<HashMap<String, String>> nameValues = new ArrayList<HashMap<String, String>>();

		HashMap<String, String> pagecount = new HashMap<String, String>();
		pagecount.put(Configer.PAGE_COUNT, String.valueOf(PAGE_COUNT));
		HashMap<String, String> page = new HashMap<String, String>();
		nameValues.add(pagecount);
		if (newsPage == -1) {
			mHandler.sendEmptyMessage(HANDLER_END);
			return;
		}
		switch (view) {
			case VIEW_NEWS :
				itemId = 5;
				page.put(Configer.PAGE_IDX, String.valueOf(newsPage));
				Utils.showLog("newsPage", String.valueOf(newsPage));
				break;
			case VIEW_AIR :

				itemId = 14;
				page.put(Configer.PAGE_IDX, String.valueOf(newsPage));
				break;
			case VIEW_OLDS :

				itemId = 15;
				page.put(Configer.PAGE_IDX, String.valueOf(newsPage));
				break;
			case VIEW_FNEWS :

				itemId = 16;
				page.put(Configer.PAGE_IDX, String.valueOf(newsPage));
				break;
			default :
				break;
		}
		url.append(itemId);
		nameValues.add(page);
		// 根据URL封装请求
		GetNewsTask getNewsThread = new GetNewsTask(url.toString());
		// 设置URL请求方式 GET or POST
		getNewsThread.isPost = true;
		// 绑定请求的POST 参数
		getNewsThread.parmas = nameValues;
		// 开始后台处理请求
		new PostDataAsyncTask().execute(getNewsThread);
		if (first) {
			// 显示等待界面
			showWait(null);
			first = false;
		}
	}
	private boolean first = true;

	private void showToast(String msg) {
		Toast.makeText(this, msg, Toast.LENGTH_SHORT).show();
	}
	/***
	 * 单击一个新闻，查看详细信息
	 */
	private OnItemClickListener newsClick = new OnItemClickListener() {

		@Override
		public void onItemClick(AdapterView<?> views, View view, int idx,
				long itemId) {
			Utils.showLog("onclick ...", "" + idx);
			if (!click) {
				click = true;
				Intent intent = new Intent(CommenTwiterActivity.this,
						NewsDetailActivity.class);
				intent.putExtra(Configer.TWITTER_ID, itemId);
//				intent.putExtra(Configer.TWITTER_DETAIL,
//						(Twitter) views.getItemAtPosition(idx));
				startActivity(intent);
				click = false;
			}
		}
	};
	private int newsPage = 1;
	class GetNewsTask extends TaskDeal {

		public GetNewsTask(String url) {
			super(url);
		}
		/***
		 * 提交 post 数据
		 */
		public void setParmas() {

		}
		/**
		 * 执行处理操作数据，把字符串转换成对象
		 */
		public Object dealTheData(HttpResponse response, String data) {
			Utils.showLog("the get msg is ", data);
			Object obj = null;
			try {
				if (data.length() < 3) {
					onError(nomore, null, response);
				} else
					obj = Json2Object.parserToNews(data);
			} catch (UnsupportedEncodingException e) {
				// TODO
				e.printStackTrace();
				onError(UnsupportedEncodingException, null, response);
			} catch (JSONException e) {
				// TODO
				e.printStackTrace();
				onError(JSONException, null, response);
			} catch (ParseException e) {
				// TODO
				e.printStackTrace();
				onError(ParseException, null, response);
			}
			return obj;
		}

		/**
		 * 执行更新操作
		 */
		public void updateView(Object obj) {
			if (obj != null) {
				List<Twitter> newslist = (List<Twitter>) obj;
				int size = newslist.size();
				Utils.showLog("the size is  ", String.valueOf(size));

				if (size > 0) {
					int tid = newslist.get(0).getTwitterid();
					Utils.showLog("the tid is  ", String.valueOf(tid));
					boolean nxt = newslist.size() == PAGE_COUNT;
					Utils.showLog("nxt is   " + nxt);
					{
						Utils.showLog("nxt is   " + nxt);
						Utils.showLog("newsPage ", String.valueOf(newsPage));
						if (nxt) {
							newsPage++;
						} else
							newsPage = -1;

						if (newsAdapter != null) {
							Utils.showLog("newsList.get()  ===> ", String
									.valueOf(newsAdapter.dataSource.size()));
						}
						if (listTwitter == null) {
							listTwitter = (newslist);
						} else {
							listTwitter.addAll(newslist);
							// newsbind.dataSource.remove(0);
							// newsbind.;
							// newsbind.dataSource.addAll(newslist);
						}
						Utils.showLog("newsPage2  ===> ",
								String.valueOf(newsPage));
						bindNewsData();
						if (newsAdapter != null) {
							Utils.showLog("newsList.get()  ===> ", String
									.valueOf(newsAdapter.dataSource.size()));
						}

						// bindNewsData();

					}
				} else
					mHandler.sendEmptyMessage(HANDLER_NOMORE);
				dismissWait();
			}

		}
		@Override
		public void onError(int errorId, HttpRequest request,
				HttpResponse response) {
			// TODO
			dismissWait();
			int resId = -1;
			switch (errorId) {
				case PostDataAsyncTask.ClientProtocolException :
					resId = R.string.clientprotocolexception;
					break;
				case PostDataAsyncTask.SocketException :
					resId = R.string.socketexception;
					break;
				case PostDataAsyncTask.SocketTimeoutException :
					resId = R.string.sockettimeoutexception;
					break;
				case PostDataAsyncTask.Exception :
					resId = R.string.exception;
					break;
				case UnsupportedEncodingException :
					resId = R.string.unsupportedencodingexception;
					break;
				case nomore :
					resId = R.string.nomore;
					break;
				case JSONException :
					resId = R.string.jsonexception;
					break;
				case ParseException :
					resId = R.string.parseexception;
					break;
				default :
					resId = R.string.exception;
					break;
			}
			Message msg = mHandler.obtainMessage();
			msg.what = HANDLER_SHOWERROR;
			msg.arg1 = resId;
			msg.arg2 = errorId;
			mHandler.sendMessageDelayed(msg, 500);
		}
	}
	private static final int HANDLER_SHOWERROR = 0;
	private static final int HANDLER_NOMORE = 1;
	private static final int HANDLER_END = 2;

	private Handler mHandler = new Handler() {
		public void handleMessage(android.os.Message msg) {
			switch (msg.what) {
				case HANDLER_SHOWERROR :
					if (prgWait != null && btnMore != null) {
						if (msg.arg2 != TaskDeal.nomore)
							btnMore.setVisibility(View.VISIBLE);
						prgWait.setVisibility(View.GONE);
					}
					// if (nowpage==news_type) {
					dismissWait();
					Toast.makeText(CommenTwiterActivity.this, msg.arg1,
							Toast.LENGTH_SHORT).show();
					// }
					break;
				case HANDLER_NOMORE :
					if (prgWait != null && btnMore != null) {
						btnMore.setVisibility(View.GONE);
						prgWait.setVisibility(View.GONE);
					}
					// if (nowpage==news_type) {
					dismissWait();
					Toast.makeText(CommenTwiterActivity.this, R.string.tip_error,
							Toast.LENGTH_SHORT).show();
					// }
					break;
				case HANDLER_END :
					if (prgWait != null && btnMore != null) {
						btnMore.setVisibility(View.GONE);
						prgWait.setVisibility(View.GONE);
					}
					// if (nowpage==news_type) {
					dismissWait();
					showToast(getText(R.string.end).toString());
					// }
					break;
				case NewsAdapter.UPDATEIMAGE :
					Bitmap bit = msg.getData().getParcelable("bitmpa");
					((ImageView) msg.obj).setImageBitmap(bit);
					newsAdapter.notifyDataSetChanged();
					break;
				default :
					break;
			}
		};
	};
}
