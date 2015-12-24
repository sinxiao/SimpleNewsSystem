package cn.com.dc.app.client.bean;

import java.util.Date;

import android.os.Parcel;
import android.os.Parcelable;

public class NewsComment implements Parcelable {
	
	public NewsComment()
	{
		
	}
	public int getIdnews_comment() {
		return idnews_comment;
	}
	public void setIdnews_comment(int idnews_comment) {
		this.idnews_comment = idnews_comment;
	}
	public String getComment_name() {
		return comment_name;
	}
	public void setComment_name(String comment_name) {
		this.comment_name = comment_name;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public int getUser_id() {
		return user_id;
	}
	public void setUser_id(int user_id) {
		this.user_id = user_id;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public Date getGen_time() {
		return gen_time;
	}
	public void setGen_time(Date gen_time) {
		this.gen_time = gen_time;
	}
	public int getNews_id() {
		return news_id;
	}
	public void setNews_id(int news_id) {
		this.news_id = news_id;
	}
	
	public int describeContents() {
		// TODO
		
		return 0;
	}
	private int idnews_comment;
	private String comment_name;
	private String email;
	private int user_id;
	private String content;
	private Date gen_time;
	private int news_id;	
	public void writeToParcel(Parcel dest, int flags) {
		// TODO

		dest.writeString(comment_name);
		dest.writeString(email);
		dest.writeInt(idnews_comment);
		dest.writeInt(user_id);
		dest.writeString(content);
		dest.writeInt(news_id);
		dest.writeValue(gen_time);
	}
	public static final Parcelable.Creator<NewsComment> CREATOR = new Parcelable.Creator<NewsComment>() {
		public NewsComment createFromParcel(Parcel in) {
			return new NewsComment(in);
		}

		public NewsComment[] newArray(int size) {
			return new NewsComment[size];
		}
	};
	public NewsComment(Parcel in)
	{
		comment_name = in.readString();
		email = in.readString();
		idnews_comment = in.readInt();
		user_id = in.readInt();
		content = in.readString();
		news_id = in.readInt();
		gen_time = (Date) in.readValue(Date.class.getClassLoader());
	}
}
