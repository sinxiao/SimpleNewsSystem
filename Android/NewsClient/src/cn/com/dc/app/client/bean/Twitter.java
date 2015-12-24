package cn.com.dc.app.client.bean;

public class Twitter {
	private String uid;
	public String getUid() {
		return uid;
	}
	public void setUid(String uid) {
		this.uid = uid;
	}
	public String getDatetime() {
		return datetime;
	}
	public void setDatetime(String datetime) {
		this.datetime = datetime;
	}
	public int getPinglun() {
		return pinglun;
	}
	public void setPinglun(int pinglun) {
		this.pinglun = pinglun;
	}
	public int getZhuanfa() {
		return zhuanfa;
	}
	public void setZhuanfa(int zhuanfa) {
		this.zhuanfa = zhuanfa;
	}
	public String getTopic() {
		return topic;
	}
	public void setTopic(String topic) {
		this.topic = topic;
	}
	public int getTwitterid() {
		return twitterid;
	}
	public void setTwitterid(int twitterid) {
		this.twitterid = twitterid;
	}
	public String getDetail() {
		return detail;
	}
	public void setDetail(String detail) {
		this.detail = detail;
	}
	private String datetime;
	private int pinglun;
	private int zhuanfa;
	private String topic;
	private int twitterid;
	private String detail;
}
