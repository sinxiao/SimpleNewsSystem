package cn.com.dc.app.client;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.ref.SoftReference;
import java.util.HashMap;
import java.util.List;

import android.content.Context;
import android.database.DataSetObserver;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import cn.com.dc.app.client.bean.News;
import cn.com.dc.app.client.bean.Twitter;
import cn.com.dc.app.client.util.DownLoadImageTool;
import cn.com.dc.app.client.util.Utils;

public class TwitterAdapter extends BaseAdapter {
	private final static int preview_size = 46;
	private HashMap<String, SoftReference<Bitmap>> bitmapcatch = new HashMap<String, SoftReference<Bitmap>>();
	// public SoftReference<List<News>> dataSource;
	Context mContext ;
	private LayoutInflater mInflater ;
	public List<Twitter> dataSource;
	int count;
	public TwitterAdapter(SoftReference<List<Twitter>> source , Context context) {
		dataSource = source.get();
		mContext = context ;
		mInflater = LayoutInflater.from(mContext);
	}
	private Handler mHandler ;
	public static final int UPDATEIMAGE = 110; 
	public TwitterAdapter(List<Twitter> source,Context context,Handler mHandler) {
		dataSource = source;
		mContext = context ;
		mInflater = LayoutInflater.from(mContext);
		this.mHandler = mHandler;
	}
	@Override
	public int getCount() {
		// TODO
		return dataSource.size();
//		return  newsList.get().size();
	}
	public void setDataSource(List<Twitter> news)
	{
		this.dataSource = news ;
	}
	@Override
	public Object getItem(int position) {
		// TODO
		return dataSource.get(position);
//		return newsList.get().get(position);
	}

	@Override
	public long getItemId(int position) {
		// TODO
		return dataSource.get(position).getTwitterid();
	}

	@Override
	public int getItemViewType(int position) {
		// TODO
		return 0;
	}
	private int divider = 12;
	private int idx = -1;
	@Override
	public View getView(final int position, View convertView, ViewGroup parent) {
		// TODO
		Utils.showLog(" position is the ==> ", String.valueOf(position));
		int p = position / divider;
		if (p != idx) {

		}
		if (convertView == null) {
			convertView = mInflater.inflate(R.layout.news_item, null);
			NewsView nv = new NewsView();

			nv.igvPreview = (ImageView) convertView
					.findViewById(R.id.igvPreview);
			nv.tv_news_comment = (TextView) convertView
					.findViewById(R.id.tv_news_comment);
			nv.tv_news_content = (TextView) convertView
					.findViewById(R.id.tv_news_content);
			nv.tv_news_title = (TextView) convertView
					.findViewById(R.id.tv_news_title);
			convertView.setTag(nv);
		}

		final NewsView nv = (NewsView) convertView.getTag();

		News ns = (News) getItem(position);
//		News ns = (News) getItem(position);
		nv.tv_news_comment.setText(String.valueOf(ns.getCommentsum()));
		nv.pos = position ;
		String intro = ns.getIntro();
		if (intro != null && !intro.trim().equals("")) {
			if(intro.length()>=preview_size){
				intro = intro.substring(0, preview_size);
			}
			nv.tv_news_content.setText(Html.fromHtml(intro));
		} else
			nv.tv_news_content.setText(Html.fromHtml(ns.getContent()
					.substring(
							0,
							ns.getContent().length() > preview_size
									? preview_size
									: ns.getContent().length() - 1)));

		nv.tv_news_title.setText(ns.getTitle());
		Utils.showLog(" ns.getTitle() is the ==> ", ns.getTitle());
		final String imageurl = ns.getImageurl();
		nv.igvPreview.setBackgroundDrawable(null);
		if (imageurl != null && !imageurl.trim().equals("")) {
			/** 异步加载新闻的预览图片 **/

			File f = Utils.getFileByURL(imageurl);
			if (f.exists()) {
				Utils.showLog(" imageurl is exits ... ", f.getAbsolutePath());
				SoftReference<Bitmap> bitmap = bitmapcatch.get(imageurl);
				if (bitmap == null) {
					BufferedInputStream inputstream = null ;
					try {
						inputstream = new BufferedInputStream(new FileInputStream(f),8000);
						bitmap = new SoftReference<Bitmap>(BitmapFactory.decodeStream(inputstream));
						inputstream.close();
						inputstream = null ;
						Utils.showLog("read from sd ok");
					} catch (FileNotFoundException e) {
						// TODO 
						e.printStackTrace();
					} catch (IOException e) {
						// TODO 
						e.printStackTrace();
					}
					bitmapcatch.put(imageurl, bitmap);
					Utils.showLog("put to the bitmapcatch");
				}

				nv.igvPreview.setImageBitmap(bitmap.get());
			} else {
				// DownLoadBiz<SoftReference<Bitmap>,String> dowload = new
				// DownLoadBiz<SoftReference<Bitmap>,String>(ns.getImageurl())
				// {};

				DownLoadImageTool downloadImage = new DownLoadImageTool(
						ns.getImageurl(),position) {
					public void onDowLoadOk(final SoftReference<Bitmap> m) {
						super.onDowLoadOk(m);
						if(position==pos)
						{
							Message msg = mHandler.obtainMessage();
							msg.what = UPDATEIMAGE;
							msg.obj =nv.igvPreview;
							Bundle bundle = new Bundle();// msg.peekData();
							bundle.putParcelable("bitmap", this.m.get());
							msg.setData(bundle);
							mHandler.sendMessageDelayed(msg, 200);
						}
						bitmapcatch.put(imageurl, m);
						notifyDataSetInvalidated();
						
					}
				};
				DownloadBackService.addDownLoadPool(downloadImage);
				nv.igvPreview.setImageResource(R.drawable.icon);
			}
		} else
			nv.igvPreview.setVisibility(View.GONE);

		return convertView;
	}

	@Override
	public int getViewTypeCount() {
		// TODO
		return 1;
	}

	@Override
	public boolean hasStableIds() {
		// TODO
		return false;
	}
	@Override
	public void notifyDataSetChanged() {
		// TODO
		super.notifyDataSetChanged();
	}
	@Override
	public boolean isEmpty() {
		// TODO
		return false;
	}

	@Override
	public void registerDataSetObserver(DataSetObserver observer) {
		// TODO

	}

	@Override
	public void unregisterDataSetObserver(DataSetObserver observer) {
		// TODO

	}

	@Override
	public boolean areAllItemsEnabled() {
		// TODO
		return true;
	}

	@Override
	public boolean isEnabled(int position) {
		// TODO
		return true;
	}
	private static class NewsView {
		int pos ;
		ImageView igvPreview;
		TextView tv_news_title, tv_news_comment, tv_news_content;
//		ListAda
	}
}
