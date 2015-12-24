package cn.com.dc.app.client.bean;

import java.util.Date;

import android.os.Parcel;
import android.os.Parcelable;

public class News implements Parcelable {
	public News()
	{
		
	}
	public int getIdnews() {
		return idnews;
	}
	public void setIdnews(int idnews) {
		this.idnews = idnews;
	}
	public String getIntro() {
		return intro;
	}
	public void setIntro(String intro) {
		this.intro = intro;
	}
	public Date getGentime() {
		return gentime;
	}
	public void setGentime(Date gentime) {
		this.gentime = gentime;
	}
	public int getWriter() {
		return writer;
	}
	public void setWriter(int writer) {
		this.writer = writer;
	}
	public int getVerifyid() {
		return verifyid;
	}
	public void setVerifyid(int verifyid) {
		this.verifyid = verifyid;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getUserid() {
		return userid;
	}
	public void setUserid(String userid) {
		this.userid = userid;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public int getItemid() {
		return itemid;
	}
	public void setItemid(int itemid) {
		this.itemid = itemid;
	}
	public int getPasscheked() {
		return passcheked;
	}
	public void setPasscheked(int passcheked) {
		this.passcheked = passcheked;
	}
	public String getKeyword() {
		return keyword;
	}
	public void setKeyword(String keyword) {
		this.keyword = keyword;
	}
	public int getDefaultnews() {
		return defaultnews;
	}
	public void setDefaultnews(int defaultnews) {
		this.defaultnews = defaultnews;
	}
	public int getClicked() {
		return clicked;
	}
	public void setClicked(int clicked) {
		this.clicked = clicked;
	}
	public String getNewsurl() {
		return newsurl;
	}
	public void setNewsurl(String newsurl) {
		this.newsurl = newsurl;
	}
	public String getImageurl() {
		return imageurl;
	}
	public void setImageurl(String imageurl) {
		this.imageurl = imageurl;
	}
	public int getCommentsum() {
		return commentsum;
	}
	public void setCommentsum(int commentsum) {
		this.commentsum = commentsum;
	}
	private String newsurl;
	private String imageurl;
	private int commentsum = 0;
	@Override
	public int describeContents() {
		// TODO
		return 0;
	}
	@Override
	public void writeToParcel(Parcel dest, int flags) {
		// TODO
		dest.writeString(newsurl);
		dest.writeString(imageurl);
		dest.writeInt(commentsum);
		
		dest.writeInt(idnews);
		dest.writeInt(writer);
		dest.writeInt(verifyid);
		dest.writeInt(itemid);
		
		dest.writeInt(defaultnews);
		dest.writeInt(clicked);
		dest.writeString(keyword);
		dest.writeString(content);
		
		dest.writeString(title);
		dest.writeString(userid);
		dest.writeString(username);
		
		dest.writeValue(gentime);
	}
	private int idnews;
	private String intro;
	private Date gentime;
	private int writer;

	private int verifyid;
	private String username;
	private String userid;

	private String title;
	private String content;
	private int itemid;

	private int passcheked;
	private String keyword;
	private int defaultnews;
	private int clicked;
	public static final Parcelable.Creator<News> CREATOR = new Parcelable.Creator<News>() {
		public News createFromParcel(Parcel in) {
			return new News(in);
		}

		public News[] newArray(int size) {
			return new News[size];
		}
	};

	private News(Parcel in) {
		newsurl = in.readString();
		imageurl= in.readString();
		commentsum= in.readInt();
		
		idnews= in.readInt();
		writer= in.readInt();
		verifyid= in.readInt();
		itemid= in.readInt();
		
		defaultnews= in.readInt();
		clicked= in.readInt();
		keyword= in.readString();
		content= in.readString();
		
		title= in.readString();
		userid= in.readString();
		username= in.readString();
		
		gentime = (Date) in.readValue(Date.class.getClassLoader());
	}
	
	
}
