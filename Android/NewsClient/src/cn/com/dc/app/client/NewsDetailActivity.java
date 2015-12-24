package cn.com.dc.app.client;

import java.io.UnsupportedEncodingException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import org.apache.http.HttpRequest;
import org.apache.http.HttpResponse;
import org.json.JSONException;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.text.Html;
import android.text.InputType;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;
import android.widget.PopupWindow;
import android.widget.ProgressBar;
import android.widget.TextView;
import cn.com.dc.app.client.CustomListView.OnRefreshListener;
import cn.com.dc.app.client.bean.News;
import cn.com.dc.app.client.bean.NewsComment;
import cn.com.dc.app.client.util.Configer;
import cn.com.dc.app.client.util.Json2Object;
import cn.com.dc.app.client.util.PostDataAsyncTask;
import cn.com.dc.app.client.util.TaskDeal;
import cn.com.dc.app.client.util.Utils;

public class NewsDetailActivity extends DCActivity {
	private static final int HANDLER_SHOWERROR = 0;
	private static final int HANDLER_NOMORE = 1;
	private static final int HANDLER_END = 2;
	// private long newsId;
	private News news;
	private LayoutInflater mInflater;
	private View newsView, commentsViews;
	private Button btnBack, btnComment, btnShare, btnLove, btnSendComment;
	private Button edtComment;
	private TextView txtItem, txtTitle, txtTime, txtSouce, txtContent;
	private LinearLayout mainFrame;
	private ImageButton btnShowComment;
	private CustomListView lstComments;
	private int commentPage;
	private View layoutBottom;
	private EditText edtInputComment;
	private View bottomBarr;

	private Handler mHandler = new Handler() {
		public void handleMessage(android.os.Message msg) {

		};
	};
	private boolean showNews = true;
	private List<NewsComment> newscomments = null;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.news_detail);
		// newscomments = new ArrayList<NewsComment>();
		mInflater = LayoutInflater.from(this);
		// newsId = getIntent().getLongExtra(Configer.NEWS_ID,
		// Long.parseLong("-1"));
		news = getIntent().getParcelableExtra(Configer.NEWS_DETAIL);
		
		newsView = mInflater.inflate(R.layout.seenews, null);
		getWindow().setSoftInputMode(
				WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
		btnBack = (Button) findViewById(R.id.btnBack);
		btnBack = (Button) findViewById(R.id.btnBack);
		btnBack.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				if (showinput) {
					showinput = false;
					layoutBottom.setVisibility(View.GONE);
					((InputMethodManager) getSystemService(INPUT_METHOD_SERVICE))
					.hideSoftInputFromWindow(NewsDetailActivity.this
							.getCurrentFocus().getWindowToken(),
							InputMethodManager.HIDE_NOT_ALWAYS);
				} else {
					if (!showNews) {
						mainFrame.removeAllViews();
						mainFrame.addView(newsView);
						btnComment
								.setBackgroundResource(R.drawable.btn_comment);
						showNews = true;
					} else {
						finish();
					}
				}
			}
		});
		btnComment = (Button) findViewById(R.id.btnComment);
		// btnShare = (Button) findViewById(R.id.btnShare);
		// btnLove = (Button) findViewById(R.id.btnLove);

		btnComment.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO
				// addComment(edtComment.getText().toString());
				mainFrame.removeAllViews();
				if (showNews) {
					if (commentsViews == null) {
						getNewsComment();
						commentsViews = mInflater.inflate(R.layout.newslist,
								null);
						lstComments = (CustomListView) commentsViews
								.findViewById(R.id.lstNews);

					}
					mainFrame.addView(commentsViews);
					showNews = false;
					btnComment.setBackgroundResource(R.drawable.btn_content);
				} else {
					mainFrame.addView(newsView);
					btnComment.setBackgroundResource(R.drawable.btn_comment);
					showNews = true;
				}

			}

		});

		// edtComment = (Button) findViewById(R.id.edtComment);
		// edtComment.setInputType(InputType.TYPE_CLASS_TEXT);

		layoutBottom = findViewById(R.id.layoutBottom);
		btnShowComment = (ImageButton) findViewById(R.id.btnShowComment);
		edtInputComment = (EditText) findViewById(R.id.edtInputComment);
		btnSendComment = (Button) findViewById(R.id.btnSendComment);

		btnShowComment.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				// TODO Auto-generated method stub
				showComment();
				ctype = COMMENT_NEWS;
			}
		});
		edtInputComment.setInputType(InputType.TYPE_CLASS_TEXT);
		edtInputComment.setOnKeyListener(new View.OnKeyListener() {

			public boolean onKey(View v, int keyCode, KeyEvent event) {
				// TODO
				if (keyCode == KeyEvent.KEYCODE_ENTER
						&& event.getAction() == KeyEvent.ACTION_DOWN) {
					addComment(edtInputComment.getText().toString());
					((InputMethodManager) getSystemService(INPUT_METHOD_SERVICE))
							.hideSoftInputFromWindow(NewsDetailActivity.this
									.getCurrentFocus().getWindowToken(),
									InputMethodManager.HIDE_NOT_ALWAYS);
					layoutBottom.setVisibility(View.GONE);
					showinput = false;
					return true;
				}
				return false;
			}
		});
		// edtComment.setOnClickListener(new View.OnClickListener() {
		// public void onClick(View v) {
		// // TODO
		// OpenSoftKeyboard();
		// }
		// });
		btnSendComment.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				addComment(edtInputComment.getText().toString());
				((InputMethodManager) getSystemService(INPUT_METHOD_SERVICE))
						.hideSoftInputFromWindow(NewsDetailActivity.this
								.getCurrentFocus().getWindowToken(),
								InputMethodManager.HIDE_NOT_ALWAYS);
				layoutBottom.setVisibility(View.GONE);
				showinput = false;
			}
		});
		mainFrame = (LinearLayout) findViewById(R.id.mainFrame);

		newsView = mInflater.inflate(R.layout.seenews, null);

		txtTitle = (TextView) newsView.findViewById(R.id.txtTitle);
		txtTime = (TextView) newsView.findViewById(R.id.txtTime);
		txtSouce = (TextView) newsView.findViewById(R.id.txtSouce);
		txtContent = (TextView) newsView.findViewById(R.id.txtContent);

		txtTitle.setText(news.getTitle());
		txtTime.setText(news.getGentime().toLocaleString());
		txtSouce.setText(news.getNewsurl());
		txtContent.setText(Html.fromHtml(news.getContent()));
		mainFrame.addView(newsView);
		bottomBarr = findViewById(R.id.bottomBarr);
		new Thread(){
			public void run() {
				increamentRead();
			}
		}.start();
		
	}
	/***
	 * 显示输入评论的界面
	 */
	private void showComment() {
		showinput = true;

		layoutBottom.setVisibility(View.VISIBLE);
		edtInputComment.setFocusable(true);
		edtInputComment.requestFocusFromTouch();
		OpenSoftKeyboard();
	}
	private boolean showinput = false;
	private int page = 1;

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		// TODO Auto-generated method stub
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			if (showinput) {
				layoutBottom.setVisibility(View.GONE);
				showinput = false;
				bottomBarr.setVisibility(View.VISIBLE);
				return false;
			}
		}
		return super.onKeyDown(keyCode, event);
	}

	private void OpenSoftKeyboard() {
		Timer timer = new Timer();
		timer.schedule(new TimerTask() {
			public void run() {
				InputMethodManager m = (InputMethodManager) edtInputComment
						.getContext().getSystemService(
								Context.INPUT_METHOD_SERVICE);
				m.toggleSoftInput(0, InputMethodManager.HIDE_NOT_ALWAYS);
				runOnUiThread(new Runnable() {
					public void run() {
						edtInputComment.setText("");
						bottomBarr.setVisibility(View.INVISIBLE);
					}
				});

			}
		}, 500);
	}

	private void getNewsComment() {
		StringBuffer url = new StringBuffer(Configer.COMMENT_BIZ
				+ "?method=102&arg=");
		List<HashMap<String, String>> nameValues = new ArrayList<HashMap<String, String>>();

		HashMap<String, String> pagecount = new HashMap<String, String>();
		pagecount.put(Configer.PAGE_COUNT, Configer.COUNT);
		pagecount.put(Configer.PAGE_IDX, String.valueOf(page));
		pagecount.put(Configer.PST_SUID, "1");
		HashMap<String, String> page = new HashMap<String, String>();
		nameValues.add(pagecount);

		url.append(news.getIdnews());
		nameValues.add(page);
		// 根据URL封装请求
		GetNewsTask getNewsThread = new GetNewsTask(url.toString());
		// 设置URL请求方式 GET or POST
		getNewsThread.isPost = true;
		// 绑定请求的POST 参数
		getNewsThread.parmas = nameValues;
		// 开始后台处理请求
		new PostDataAsyncTask().execute(getNewsThread);

	}

	private class CommentsAdapter extends BaseAdapter {

		public int getCount() {
			// TODO
			return newscomments == null ? 0 : newscomments.size();
		}

		public Object getItem(int position) {
			// TODO
			return newscomments.get(position);
		}

		public long getItemId(int position) {
			// TODO
			return newscomments.get(position).getIdnews_comment();
		}

		public View getView(int position, View convertView, ViewGroup parent) {
			// TODO
			CommentView cv = null;
			if (convertView == null) {
				convertView = mInflater.inflate(R.layout.comments_item, null);
				cv = new CommentView();
				cv.txtContent = (TextView) convertView
						.findViewById(R.id.txtContent);
				cv.txtGenTime = (TextView) convertView
						.findViewById(R.id.txtGenTime);
				cv.txtUName = (TextView) convertView
						.findViewById(R.id.txtUName);
				convertView.setTag(cv);
			} else {
				cv = (CommentView) convertView.getTag();
			}
			NewsComment nc = (NewsComment) getItem(position);
			cv.txtContent.setText(nc.getContent());
			cv.txtGenTime.setText(nc.getGen_time().toLocaleString());
			cv.txtUName.setText(nc.getUser_id() + "");
			return convertView;
		}

	}

	private static class CommentView {
		public TextView txtUName, txtGenTime, txtContent;
	}

	protected void addComment(String string) {
		// TODO
		if (string.trim().equals("")) {
			return;
		}
		// http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=102&arg=5
		StringBuffer url = new StringBuffer(Configer.COMMENT_BIZ
				+ "?method=101&arg=");
		List<HashMap<String, String>> nameValues = new ArrayList<HashMap<String, String>>();

		HashMap<String, String> pagecount = new HashMap<String, String>();
		pagecount.put(Configer.PST_COMMENT, string);
		pagecount.put(Configer.PST_EMAIL, "test@test.com");
		pagecount.put(Configer.PST_SUID, "1");
		
		HashMap<String, String> page = new HashMap<String, String>();
		
		if(ctype==COMMENT_COMMENT){
			url.append(comment_id);
			pagecount.put(Configer.PST_CTYPE, "3");
		}else{
			url.append(news.getIdnews());
		}
		nameValues.add(pagecount);
		nameValues.add(page);
		// 根据URL封装请求
		GetNewsTask getNewsThread = new GetNewsTask(url.toString());
		// 设置URL请求方式 GET or POST
		getNewsThread.isPost = true;
		// 绑定请求的POST 参数
		getNewsThread.parmas = nameValues;
		// 开始后台处理请求
		new PostDataAsyncTask().execute(getNewsThread);

	}

	private Button btnMore;
	private ProgressBar prgWait;

	private View getFootView() {
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
		btnMore.setText(R.string.more);
		btnMore.setOnClickListener(new View.OnClickListener() {
			public void onClick(View v) {
				prgWait.setVisibility(View.VISIBLE);
				v.setVisibility(View.GONE);
				// getNewsDataByType(type);
				getNewsComment();
			}
		});

		return vw;
	}

	private void increamentRead() {
		// http://localhost:3449/NewsTwitter/Client/NewsDoClient.aspx?method=102&arg=5
		StringBuffer url = new StringBuffer(Configer.COMMENT_BIZ
				+ "?method=103&arg=");
		List<HashMap<String, String>> nameValues = new ArrayList<HashMap<String, String>>();

		HashMap<String, String> pagecount = new HashMap<String, String>();
		pagecount
				.put(Configer.POST_TYPE, String.valueOf(Configer.TYPE_CLICKED));
		HashMap<String, String> page = new HashMap<String, String>();
		nameValues.add(pagecount);
		if (commentPage == -1) {
			mHandler.sendEmptyMessage(HANDLER_END);
			return;
		}
		url.append(news.getIdnews());
		nameValues.add(page);
		// 根据URL封装请求
		GetNewsTask getNewsThread = new GetNewsTask(url.toString());
		// 设置URL请求方式 GET or POST
		getNewsThread.isPost = true;
		// 绑定请求的POST 参数
		getNewsThread.parmas = nameValues;
		// 开始后台处理请求
		new PostDataAsyncTask().execute(getNewsThread);

	}

	class GetNewsTask extends TaskDeal {
		public GetNewsTask(String url) {
			super(url);
		}

		@Override
		public void setParmas() {
			// TODO

		}

		@Override
		public Object dealTheData(HttpResponse response, String data) {
			// TODO
			if (this.request
					.contains("/Client/CommentClientDo.aspx?method=101&arg=")) // 判断是否是添加评论的操作
			{
				if (data.contains("ok")) {
					Utils.showLog("add comment ok");
					edtInputComment.setText("");
					runOnUiThread(new Runnable() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							Utils.showToast(getApplicationContext(),
									getString(android.R.string.ok));
						}
					});

				} else if (data.contains("fail")) {
					Utils.showLog("add comment fail ");
					runOnUiThread(new Runnable() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							Utils.showToast(getApplicationContext(),
									getString(android.R.string.no));
						}
					});

				}
			} else if (this.request
					.contains("/Client/CommentClientDo.aspx?method=103&arg="))// 判断是否是增加阅读次数的操作
			{
				if (data.contains("ok")) {
					Utils.showLog("incream read ok");
					runOnUiThread(new Runnable() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							Utils.showToast(getApplicationContext(),
									"incream read ok");
						}
					});

				} else if (data.contains("fail")) {
					Utils.showLog("incream read fail ");
					runOnUiThread(new Runnable() {

						@Override
						public void run() {
							// TODO Auto-generated method stub
							Utils.showToast(getApplicationContext(),
									"incream read fail");
						}
					});

				}
			} else if (this.request
					.contains("/Client/CommentClientDo.aspx?method=102&arg="))// 获得新闻的评论内容，然后进行解析
			{
				Object obj = null;
				try {
					if (data.length() < 3) {
						page = -1;
						onError(nomore, null, response);
					} else
						obj = Json2Object.parserToNewsComment(data);
					return obj;
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
			}

			return null;
		}

		@Override
		public void onError(int errorId, HttpRequest request,
				HttpResponse response) {
			// TODO
			runOnUiThread(new Runnable() {

				public void run() {
					lstComments.onRefreshComplete();
					prgWait.setVisibility(View.GONE);
					btnMore.setVisibility(View.VISIBLE);
				}
			});

			Utils.showLog(" on error ", String.valueOf(errorId));
		}

		@Override
		public void updateView(Object obj) {
			// TODO
			if (this.request
					.contains("/Client/CommentClientDo.aspx?method=102&arg="))// 获得新闻的评论内容，然后进行解析
			{
				List<NewsComment> newlst = null;
				if (obj != null) {
					newlst = (List<NewsComment>) obj;
					if (newlst.size() != Integer.valueOf(Configer.COUNT)) {
						page = -1;
					} else
						page++;

				} else {
					return;
				}

				if (newscomments == null) {
					newscomments = newlst;
					commsBind = new CommentsAdapter();
					lstComments.addFooterView(getFootView());
					lstComments.setOnRefreshListener(new OnRefreshListener() {
						public void onRefresh() {
							// TODO
							getNewsComment();
						}
					});
					lstComments.setAdapter(commsBind);
					lstComments.setOnItemClickListener(new AdapterView.OnItemClickListener() {

						@Override
						public void onItemClick(AdapterView<?> adatview, View view,
								int idx, long item) {
							// TODO Auto-generated method stub
							int fid =(int) commsBind.getItemId(idx-1);
							showPopView(view,fid);
						}
					});
				} else {
					if (!newscomments.containsAll(newlst)) {
						newscomments.addAll(newlst);
						commsBind.notifyDataSetChanged();
					}
					// ((BaseAdapter) lstComments.getAdapter())
					// .notifyDataSetChanged();

				}
				lstComments.onRefreshComplete();
				prgWait.setVisibility(View.GONE);
				btnMore.setVisibility(View.VISIBLE);
			}
		}
	}
	private int nid = -1 ;
	private int ctype = -1 ;
	private int comment_id = -1 ;
	private static final int COMMENT_NEWS = 1 ;
	private static final int COMMENT_COMMENT = 2 ;
	private static final int COMMENT_PIC = 3 ;
	private void showPopView(View parent,int id){
		View contentView =  LayoutInflater.from(this).inflate(R.layout.popup_menu, null);
		final PopupWindow popWindow = new PopupWindow(contentView,LayoutParams.FILL_PARENT,LayoutParams.WRAP_CONTENT,false);
		comment_id = id ;
		Button btnLove  = (Button) contentView.findViewById(R.id.btnLove);
		Button btnShare = (Button) contentView.findViewById(R.id.btnShare);
		Button btnComment = (Button) contentView.findViewById(R.id.btnNewComment);
		Button btnTop = (Button) contentView.findViewById(R.id.btnTop);
		Button btnDown = (Button) contentView.findViewById(R.id.btnDown);
		btnComment.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				//执行对评论的评论进行评论
				popWindow.dismiss();
				showComment();
				ctype = COMMENT_COMMENT;
				
			}
		});
		popWindow.setContentView(contentView);
		popWindow.setOutsideTouchable(true);
		popWindow.update();
//		popWindow.setTouchInterceptor(new View.OnTouchListener() {
//			
//			@Override
//			public boolean onTouch(View v, MotionEvent event) {
//				// TODO Auto-generated method stub
//				if(event.getAction()==MotionEvent.ACTION_OUTSIDE){
//					popWindow.dismiss();
//				}
//				
//				return false;	
//			}
//		});
		contentView.setOnTouchListener(new View.OnTouchListener() {
			
			@Override
			public boolean onTouch(View v, MotionEvent event) {
				// TODO Auto-generated method stub
				if(event.getAction()==MotionEvent.ACTION_OUTSIDE){
					popWindow.dismiss();
				}
				
				return false;	
			}
		});
		popWindow.showAsDropDown(parent, 0, -((int)(parent.getHeight()*(2.2f))));
//		popWindow.showAtLocation(parent,Gravity.CENTER , 0, 0);
		
	}
	private CommentsAdapter commsBind = null;

}
