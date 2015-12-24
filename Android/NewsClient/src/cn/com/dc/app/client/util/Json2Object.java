package cn.com.dc.app.client.util;

import java.io.UnsupportedEncodingException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import cn.com.dc.app.client.bean.News;
import cn.com.dc.app.client.bean.NewsComment;

public class Json2Object {
	/***
	 * 
	 * @param infor
	 * @return
	 * @throws JSONException
	 * @throws UnsupportedEncodingException
	 * @throws ParseException
	 */
	public static List<NewsComment> parserToNewsComment(String infor)
			throws JSONException, UnsupportedEncodingException, ParseException {
		if (infor == null || infor.equals("")) {
			return null;
		}
		JSONArray json = new JSONArray(infor);
		int length = json.length();
		if (length > 0) {
			JSONObject jsonObject;
			java.text.DateFormat sdf =new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			List<NewsComment> newslist = new ArrayList<NewsComment>();
			for (int i = 0; i < length; i++) {
				NewsComment news = new NewsComment();
				jsonObject = json.getJSONObject(i);

				String title = new String(jsonObject.getString("email")
						.getBytes(), "utf-8");
				news.setEmail(title);
				news.setContent(new String(jsonObject.getString("content")
						.getBytes(), "utf-8"));
				
				String dt = jsonObject.getString("gen_time").trim();
				Utils.showLog("length is " + dt.length());
				if (dt.length() >= 20) {
					dt = dt.substring(0, 19).trim();
				}
				
				Date gdate = sdf.parse(dt);
				news.setGen_time(gdate);

				// news.setIntro(jsonObject.getString("intro"));
				// news.setImageurl(jsonObject.getString("image_url"));

				news.setIdnews_comment(jsonObject.getInt("idnews_comment"));
				news.setUser_id(jsonObject.getInt("user_id"));
				news.setNews_id(jsonObject.getInt("news_id"));
				newslist.add(news);
			}
			return newslist;
		}

		// } catch (JSONException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }catch (UnsupportedEncodingException e) {
		// // TODO: handle exception
		// e.printStackTrace();
		// } catch (ParseException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }

		return null;
	}

	public static List<News> parserToNews(String infor) throws JSONException,
			UnsupportedEncodingException, ParseException {
		// try {
		if (infor == null || infor.equals("")) {
			return null;
		}
		JSONArray json = new JSONArray(infor);
		Utils.showLog("111111");
		int length = json.length();
		Utils.showLog("length is ==> ", "" + length);
		if (length > 0) {
			JSONObject jsonObject;
//			java.text.DateFormat sdf = SimpleDateFormat.;
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
			List<News> newslist = new ArrayList<News>();
			for (int i = 0; i < length; i++) {
				Utils.showLog("atat" + i);
				News news = new News();
				jsonObject = json.getJSONObject(i);
				Utils.showLog("aaa" + i);
				String title = new String(jsonObject.getString("title")
						.getBytes(), "utf-8");
				Utils.showLog("bbb" + i);
				news.setTitle(title);
				Utils.showLog("ccc" + i);
				news.setContent(new String(jsonObject.getString("content")
						.getBytes(), "utf-8"));
				Utils.showLog("ddd" + i);
				String dt = jsonObject.getString("gen_time").trim();
				Utils.showLog("length is " + dt.length());
				if (dt.length() >= 20) {
					dt = dt.substring(0, 19).trim();
				}
				Utils.showLog("length is " + dt.length());
				Utils.showLog("dt is ====>", dt);
				Date gdate = sdf.parse(dt);
				Utils.showLog("eeee" + i);
				news.setGentime(gdate);
				Utils.showLog("ffff" + i);
				news.setIntro(jsonObject.getString("intro"));
				Utils.showLog("gggg" + i);
				news.setImageurl(jsonObject.getString("image_url"));
				Utils.showLog("hhhh" + i);
				news.setIdnews(jsonObject.getInt("idnews"));
				news.setItemid(jsonObject.getInt("itemid"));
				newslist.add(news);
			}
			return newslist;
		}

		// } catch (JSONException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }catch (UnsupportedEncodingException e) {
		// // TODO: handle exception
		// e.printStackTrace();
		// } catch (ParseException e) {
		// // TODO Auto-generated catch block
		// e.printStackTrace();
		// }

		return null;
	}

}
