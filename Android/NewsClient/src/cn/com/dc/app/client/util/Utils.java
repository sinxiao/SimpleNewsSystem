package cn.com.dc.app.client.util;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.security.Key;
import java.security.MessageDigest;
import java.util.Date;
import java.util.List;

import javax.crypto.Cipher;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.DESedeKeySpec;

import android.content.Context;
import android.graphics.drawable.BitmapDrawable;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Environment;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.PopupWindow;
import android.widget.Toast;
import cn.com.dc.app.client.bean.Twitter;

public class Utils {
	public static final int True = 1;
	public static final int Flase = 0;
	public static final String APP_FIRST_INIT = "app_first_init";
	static final String SPC_NAME = "data";
	public static Context mContext;
	public static boolean debug = true;
	private final static String tag = "dcapp";
	private static FileWriter fw = null;
	
	public static File getFileByURL(String t)
	{
		if (Environment.getExternalStorageState().equals(
				android.os.Environment.MEDIA_MOUNTED)) {
			File dir = new File(Environment.getExternalStorageDirectory(),
					"nsbackup");
			if (!dir.exists()) {
				dir.mkdirs();
			}
			String url = t.toLowerCase();
			String[] spt = url.split("/");
			File file = new File(dir,spt[spt.length-1]);
			return file ;
		}
		return null ;	
	}
	
	public static void showLog(String msg,String...strings) {
		StringBuffer sbf = new StringBuffer();
		if (debug) {
			sbf.append(msg);
			for (int i = 0; i < strings.length; i++) {
				sbf.append(strings[i]);
			}
			Log.d(tag, sbf.toString());
		} else {
			if (fw == null) {
				String path = mContext.getCacheDir().getAbsolutePath()
						+ "/log.txt";
				try {
					fw = new FileWriter(new File(path));
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			
			Date d = new Date();

			sbf.append(d.toGMTString()).append(" === ").append(msg);
			try {

				fw.append(sbf.toString());
				fw.flush();
				fw.close();
				fw = null;
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

	}
	public static void showToast(Context mContext ,String infor){
		Toast.makeText(mContext, infor, Toast.LENGTH_SHORT).show();
	}
	/**
	 * 根据key获取保存的int值
	 * 
	 * @param cxt
	 * @param key
	 * @param def
	 * @return
	 */
	public static int readIntValueFromSpc(Context cxt, String key, int def) {
		if (null == cxt) {
			cxt = mContext;
		}
		return cxt.getSharedPreferences(SPC_NAME, 0).getInt(key, def);
	}

	/***
	 * add by lynchxu ,fix the bug above the android4.0 show error
	 * 
	 * @param layoutId
	 * @return the show Popupwindow
	 */
	public static PopupWindow getPopupWindow(Context cxt,int layoutId) {
		LayoutInflater mLayoutInfalter = LayoutInflater.from(cxt);
		View menuView = mLayoutInfalter.inflate(layoutId, null);
		PopupWindow popupWindow = new PopupWindow(cxt); 
		popupWindow = new PopupWindow(menuView,LayoutParams.MATCH_PARENT,LayoutParams.MATCH_PARENT,false);
		popupWindow.setBackgroundDrawable(new BitmapDrawable()); 
		popupWindow.setOutsideTouchable(true);
		return popupWindow;
	}
	/***
	 * 根据个人Id获得twitter
	 * @param uid 用户标示
	 * @return
	 */
	public static List<Twitter> getTwitterListByUid(String uid)
	{
		
		return null ;
	}
	/***
	 * 获得热门推荐的消息
	 * @param type 类别 默认是默认类别
	 * @return
	 */
	public static List<Twitter> getTwitterHotList(String type)
	{
		return null ;
	}
	/**
	 * 获得新的消息信息
	 * @param type  默认为新的
	 * @return
	 */
	public static List<Twitter> getTwitterNewList(String type)
	{
		return null ;
	}
	/***
	 * 根据key获取保存的String值
	 * 
	 * @param cxt
	 * @param key
	 * @param def
	 * @return
	 */
	public static String readStringValueFormSpc(Context cxt, String key,
			String def) {
		if (null == cxt) {
			cxt = mContext;
		}
		return cxt.getSharedPreferences(SPC_NAME, 0).getString(key, def);
	}

	/***
	 * 根据key保存int值
	 * 
	 * @param cxt
	 * @param key
	 * @param value
	 * @return
	 */
	public static boolean saveIntValueIntoSpc(Context cxt, String key, int value) {
		if (null == cxt) {
			cxt = mContext;
		}

		return cxt.getSharedPreferences(SPC_NAME, 0).edit().putInt(key, value)
				.commit();
	}

	/***
	 * 保存String值
	 * 
	 * @param cxt
	 * @param key
	 * @param value
	 * @return
	 */
	public static boolean saveStringValueIntoSpc(Context cxt, String key,
			String value) {
		if (null == cxt) {
			cxt = mContext;
		}
		return cxt.getSharedPreferences(SPC_NAME, 0).edit()
				.putString(key, value).commit();
	}

	/***
	 * 把dip转换成px
	 * 
	 * @param context
	 * @param nValue
	 * @return
	 */
	public static int dip2px(Context context, int nValue) {
		final float scale = context.getResources().getDisplayMetrics().density;
		return (int) (nValue * scale + 0.5f);
	}

	// 加密 解密 认证的算法

	//
	/* Hash "SHA-1" */
	/**
	 * 获得SHA-1 得到的是 byte[]
	 * 
	 * @param inBuffer
	 *            获得hash value 的数据
	 * @return hash value byte[]
	 */
	public static byte[] GetHashValue(byte[] inBuffer) {
		byte[] hashValue = null;

		try {
			MessageDigest digest = MessageDigest.getInstance("SHA-1");
			digest.reset();
			digest.update(inBuffer);
			hashValue = digest.digest();
		} catch (Exception e) {
			System.out.println("Hash SHA-1 error:" + e.getMessage());
			return "0000000000".getBytes();
		}

		return hashValue;
	}

	/***
	 * 获得数据的摘要，以字符串形式显示
	 * 
	 * @param input
	 *            数据
	 * @return 数据摘要
	 */
	public static String getSha1(byte[] input) {
		MessageDigest md = null;
		try {
			md = MessageDigest.getInstance("SHA1");
		} catch (Exception e) {
			return "error in encrypting";
		}
		md.reset();
		md.update(input);
		byte[] encodedPassword = md.digest();
		StringBuffer buf = new StringBuffer();
		for (int i = 0; i < encodedPassword.length; i++) {
			if ((encodedPassword[i] & 0xff) < 0x10) {
				buf.append("0");
			}
			buf.append(Long.toString(encodedPassword[i] & 0xff, 16));
		}
		return buf.toString();
	}

	/***
	 * 
	 * @param secret
	 * @param text
	 * @return
	 */
	public static byte[] hmac_sha1(byte[] secret, byte[] text) {
		byte[] hmacValue = null;
		byte ipad = 0x36;
		byte opad = 0x5c;

		try {
			int secretlen = secret.length;
			byte[] tmpkeybyte = null;
			if (secretlen > 64) {
				MessageDigest H = MessageDigest.getInstance("SHA-1");
				tmpkeybyte = H.digest(secret);
			} else {
				tmpkeybyte = new byte[secretlen];
				for (int i = 0; i < secretlen; i++) {
					tmpkeybyte[i] = secret[i];
				}
			}

			int keylen = tmpkeybyte.length;
			byte[] keybyte = new byte[64];
			for (int i = 0; i < 64; i++) {
				if (i < keylen)
					keybyte[i] = tmpkeybyte[i];
				else
					keybyte[i] = 0;
			}

			byte[] tmpkeyipad = new byte[64];
			for (int i = 0; i < 64; i++) {
				tmpkeyipad[i] = (byte) (keybyte[i] ^ ipad);
			}

			byte[] keyopad = new byte[64];
			for (int i = 0; i < 64; i++) {
				keyopad[i] = (byte) (keybyte[i] ^ opad);
			}

			byte[] keyipad = new byte[64 + text.length];
			for (int i = 0; i < 64 + text.length; i++) {
				if (i < 64)
					keyipad[i] = tmpkeyipad[i];
				else
					keyipad[i] = text[i - 64];
			}

			MessageDigest shaipad = MessageDigest.getInstance("SHA-1");
			byte[] shaipadout = shaipad.digest(keyipad);

			byte[] hmacin = new byte[64 + shaipadout.length];
			for (int i = 0; i < 64 + shaipadout.length; i++) {
				if (i < 64)
					hmacin[i] = keyopad[i];
				else
					hmacin[i] = shaipadout[i - 64];
			}

			MessageDigest hmacout = MessageDigest.getInstance("SHA-1");
			hmacValue = hmacout.digest(hmacin);

		} catch (Exception e) {
			System.out.println("hmac_sha1 error:" + e.getMessage());
			return "0000000000".getBytes();
		}
		return hmacValue;
	}

	/**
	 * Hex 转换成 string
	 * 
	 * @param b
	 * @return
	 */
	public static String getHexString(byte[] b) {
		String result = "";
		if (b == null) {
			System.out.println("error: getHexString is null");
			return result;
		}
		for (int i = 0; i < b.length; i++) {
			String tstr = Integer.toString((b[i] & 0xff) + 0x100, 16);
			if (tstr != null)
				result += tstr.substring(1);
		}
		return result;
	}

	/***
	 * 字符串 获得 字节数据
	 * 
	 * @param s
	 * @return
	 */
	public static byte[] getHexBytes(String s) {
		byte[] result = new byte[s.length() / 2];
		char[] enc = s.toCharArray();
		for (int i = 0; i < result.length; i++) {
			StringBuilder curr = new StringBuilder(2);
			curr.append(enc[i * 2]).append(enc[i * 2 + 1]);
			result[i] = (byte) Integer.parseInt(curr.toString(), 16);
		}
		return result;
	}

	/* 3DES ECB */
	/***
	 * Des 加密
	 * 
	 * @param key
	 * @param data
	 * @return
	 */
	public static byte[] Des3EncodeECB(byte[] key, byte[] data) {
		Key deskey = null;
		byte[] bOut = null;

		byte[] k = new byte[24];
		if (key.length == 16) {
			System.arraycopy(key, 0, k, 0, 16);
			System.arraycopy(key, 0, k, 16, 8);
		} else {
			System.arraycopy(key, 0, k, 0, 24);
		}

		try {
			DESedeKeySpec spec = new DESedeKeySpec(k);
			SecretKeyFactory keyfactory = SecretKeyFactory
					.getInstance("desede");
			deskey = keyfactory.generateSecret(spec);

			Cipher cipher = Cipher.getInstance("desede" + "/ECB/NoPadding");
			cipher.init(Cipher.ENCRYPT_MODE, deskey);
			bOut = cipher.doFinal(data);
		} catch (Exception e) {
			System.out.println("Des3 Encode ECB error:" + e.getMessage());
		}

		return bOut;
	}

	/***
	 * Des 解密
	 * 
	 * @param key
	 * @param data
	 * @return
	 */
	public static byte[] Des3DecodeECB(byte[] key, byte[] data) {
		Key deskey = null;
		byte[] bOut = null;

		byte[] k = new byte[24];
		if (key.length == 16) {
			System.arraycopy(key, 0, k, 0, 16);
			System.arraycopy(key, 0, k, 16, 8);
		} else {
			System.arraycopy(key, 0, k, 0, 24);
		}

		try {
			DESedeKeySpec spec = new DESedeKeySpec(k);
			SecretKeyFactory keyfactory = SecretKeyFactory
					.getInstance("desede");
			deskey = keyfactory.generateSecret(spec);

			Cipher cipher = Cipher.getInstance("desede" + "/ECB/NoPadding");
			cipher.init(Cipher.DECRYPT_MODE, deskey);
			bOut = cipher.doFinal(data);
		} catch (Exception e) {
			System.out.println("Des3 Decode ECB error:" + e.getMessage());
		}

		return bOut;
	}

	// private static byte[] MAIN_KEY =
	// {0x45,0x72,0x74,0x29,(byte)0xa8,(byte)0xbe,(byte)0xa1,0x34,(byte)0xe5,0x5d,(byte)0xaa,0x06,(byte)0xff,0x4d,(byte)0xa5,(byte)0xac};
	// factor key: 8bytes
	public static void main(String[] args) {
		// byte[] b = new String("ssssssssssss").toString().getBytes();
		// String hex = getHexString(b);
		// System.out.println("hex is "+hex);
		//
		// String hex1 = getHexString(b);
		// System.out.println("hex1 is "+hex1);
	}

	private DCAlgorithm dcAlgorithm = new DCAlgorithm();

	public int showPassword(byte[] data) {
		String numberString = "";
		System.out.println("data: " + dcAlgorithm.byte2Hex(data));
		int errorCode = 0;// checkCorrectPIN("", "Check PIN", data);
		if (errorCode == 0) {
			String password;
			byte[] bSN = new byte[10];
			byte[] bAcode = new byte[16];
			System.arraycopy(data, 1, bSN, 0, bSN.length);
			System.arraycopy(data, 11, bAcode, 0, bAcode.length);
			String SN = new String(bSN);
			numberString = new String(dcAlgorithm.decrypt(bAcode));
			System.out.println("numberString: " + numberString);
			String sSecret = generateSeed(SN + numberString);

			System.out.println("Seed: " + sSecret);

			byte[] bCounter = new byte[4];
			System.arraycopy(data, 59, bCounter, 0, bCounter.length);
			int counter = dcAlgorithm.byte2Int(bCounter) + 1;

			// int counter = 1;
			System.out.println("counter: " + counter);
			password = dcAlgorithm.generateOTP(sSecret, counter, 6);

			byte[] bNewCounter = dcAlgorithm.int2Byte(counter);
			System.arraycopy(bNewCounter, 0, data, 59, bNewCounter.length);

			// showCanvas("密码：", password, cmdDone, AlertType.CONFIRMATION, 8);
		}
		System.gc();
		return errorCode;
	}

	/***
	 * 激活認證
	 * 
	 * @param data
	 *            密鈅
	 * @param sn_acode
	 *            序列號
	 * @param pin
	 *            激活pin碼
	 * @return 認證結果
	 */
	public int activate(byte[] data, String sn_acode, String pin) {
		int errorCode;

		errorCode = dcAlgorithm.checkActiveCode(sn_acode);
		System.out.println("activate: " + errorCode);
		if (errorCode == 0) {
			data[0] = 1;
			byte[] bSN = sn_acode.substring(0, 10).getBytes();
			byte[] bAcode = dcAlgorithm.encrypt(sn_acode.substring(10)
					.getBytes());
			System.out.println("bAcode: " + dcAlgorithm.byte2Hex(bAcode));
			byte[] bPIN = dcAlgorithm.hash(pin.getBytes());
			System.arraycopy(bSN, 0, data, 1, bSN.length);
			System.arraycopy(bAcode, 0, data, 11, bAcode.length);
			System.arraycopy(bPIN, 0, data, 43, bPIN.length);
		}
		return errorCode;
	}

	public String generateSeed(String sn_acode) {
		String sn = sn_acode.substring(0, 10);
		String activeCode = sn_acode.substring(10, 16);
		String checkCode = sn_acode.substring(16, 22);
		String seed = dcAlgorithm
				.sha1((checkCode + sn + activeCode).getBytes());
		return seed;
	}

	public String getActiveCode(byte[] data) {
		String activeCode;
		byte[] bActiveCode = new byte[16];
		System.arraycopy(data, 11, bActiveCode, 0, bActiveCode.length);
		activeCode = new String(dcAlgorithm.decrypt(bActiveCode));
		return activeCode;
	}
	
	/***
	 * 获得序列号
	 * @param data 获取序列号
	 * @return 
	 */
    public String getSerial(byte[] data)
    {
        String serial;
        byte[] bSerial = new byte[10];
        System.arraycopy(data, 1, bSerial, 0, bSerial.length);
        serial = new String(bSerial);
        
        return serial;
    }
    
    /***
     * 重新激活
     * @param data
     * @param acode
     * @param pin
     * @return
     */
	public int reActivate(byte[] data, String acode, String pin) {
		int errorCode;
		// 从数据库里获得保存的 标示
		byte[] record = "test".getBytes();// getRecord(1, "rsDynamiCode");
		String activeCode = getActiveCode(record);
		System.out.println("activeCode: " + activeCode);
		if (acode.compareTo(activeCode) != 0) {
			byte[] bCount = new byte[4];
			String sn = getSerial(record);
			String sn_acode = sn + acode;
			errorCode = dcAlgorithm.checkActiveCode(sn_acode);
			System.out.println("reActivate: " + errorCode);
			if (errorCode == 0) {
				byte[] bAcode = dcAlgorithm.encrypt(acode.getBytes());
				byte[] bPIN = dcAlgorithm.hash(pin.getBytes());
				System.arraycopy(bAcode, 0, data, 11, bAcode.length);
				System.arraycopy(bPIN, 0, data, 43, bPIN.length);
				System.arraycopy(bCount, 0, data, 59, bCount.length);
			}
		} else
			errorCode = -3;
		return errorCode;
	}
	/***
	 * 
	 * @param mCtx
	 * @return 返回的是一组数据 IMEI + androidId+ mac + IMSI + SimSerialNumber
	 */
	public static String getUUid(Context mCtx)
	{
		//IMEI就是DeviceID(只有带有通信设备的机器才有,手机与pad) 和 androidid (重置或刷机的时候会变),构成
		TelephonyManager telmanger = ((TelephonyManager) mCtx.getSystemService(Context.TELEPHONY_SERVICE));
//		String imei = telmanger.
		String imsi = telmanger.getSubscriberId();//与SIM有关
//		String imei = telmanger.getDeviceId(); 
		
		String tmDevice = telmanger.getDeviceId();
		String tmSerial = telmanger.getSimSerialNumber();
		String androidId = ""
                 + android.provider.Settings.Secure.getString(
                		 mCtx.getContentResolver(),
                                 android.provider.Settings.Secure.ANDROID_ID);
//		 UUID deviceUuid = new UUID(androidId.hashCode(), //如果采用这样的方式来判断,可能会引起同一手机有不同的uuid,因为会变
//                 ((long) tmDevice.hashCode() << 32) | tmSerial.hashCode());
		
		WifiManager wifi = (WifiManager) mCtx.getSystemService(Context.WIFI_SERVICE);
		WifiInfo info = wifi.getConnectionInfo();
		String mac = info.getMacAddress();
		String uuid = tmDevice+";"+androidId+";"+mac+";"+imsi+";"+tmSerial;
		return uuid ;
	}
}
