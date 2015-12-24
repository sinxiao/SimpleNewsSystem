package cn.com.dc.app.client.util;

import java.security.NoSuchAlgorithmException;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;

import android.util.Base64;

public class AES {
	public static final String VIPARA = "0102030405060708"; // iv参数设置
															// （ios、android、wp7、java
															// 统一）
	public static final String ENCODING = "UTF-8";
	/**
	 * 加密
	 * 
	 * @param content
	 *            需要加密的内容
	 * @param password
	 *            加密密码
	 * @return
	 */
	public static byte[] encrypt(String content, String password) {
		try {
			SecretKeySpec skeySpec = getKey(password);
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			IvParameterSpec iv = new IvParameterSpec(VIPARA.getBytes());
			cipher.init(Cipher.ENCRYPT_MODE, skeySpec, iv);
			byte[] encrypted = cipher.doFinal(content.getBytes());
			return encrypted;

		} catch (NoSuchAlgorithmException e) {
			e.printStackTrace();
		} catch (IllegalBlockSizeException e) {
			e.printStackTrace();
		} catch (BadPaddingException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;

	}

	/**
	 * 解密
	 * 
	 * @param content
	 *            待解密内容
	 * @param password
	 *            解密密钥
	 * @return
	 */
	public static byte[] decrypt(byte[] content, String password) {
		try {
			SecretKeySpec skeySpec = getKey(password);
			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
			IvParameterSpec iv = new IvParameterSpec(VIPARA.getBytes());
			cipher.init(Cipher.DECRYPT_MODE, skeySpec, iv);
			byte[] original = cipher.doFinal(content);
			return original;
		} catch (NoSuchAlgorithmException e) {
			e.printStackTrace();
		} catch (IllegalBlockSizeException e) {
			e.printStackTrace();
		} catch (BadPaddingException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * 字节数组转化为16进制字符串
	 * 
	 * @param src
	 * @return
	 * 
	 */
	public static String bytesToHexString(byte[] src) {
		StringBuilder stringBuilder = new StringBuilder("");
		if (src == null || src.length <= 0) {
			return null;
		}
		for (int i = 0; i < src.length; i++) {
			int v = src[i] & 0xFF;
			String hv = Integer.toHexString(v);
			if (hv.length() < 2) {
				stringBuilder.append(0);
			}
			stringBuilder.append(hv);
		}
		return stringBuilder.toString();
	}

	/**
	 * 
	 * 16进制字符串转化成字节数组
	 * 
	 * @param hexString
	 * @return
	 * 
	 */
	public static byte[] hexStringToBytes(String hexString) {
		if (hexString == null || hexString.equals("")) {
			return null;
		}
		hexString = hexString.toUpperCase();
		int length = hexString.length() / 2;
		char[] hexChars = hexString.toCharArray();
		byte[] d = new byte[length];
		for (int i = 0; i < length; i++) {
			int pos = i * 2;
			d[i] = (byte) (charToByte(hexChars[pos]) << 4 | charToByte(hexChars[pos + 1]));
		}
		return d;
	}
	private static byte charToByte(char c) {
		return (byte) "0123456789ABCDEF".indexOf(c);
	}

	/**
	 * 加密 后 将字节数组转化成16进制字符串
	 * 
	 * @param srcStr
	 *            需要加密的内容
	 * @param password
	 *            加密的key
	 * @return
	 */
	public static String encryptString(String srcStr, String password) {
		String resultStr = "";
		byte[] result = encrypt(srcStr, password);
//		resultStr = Base64.encodeToString(result, Base64.DEFAULT);
		
		resultStr = bytesToHexString(result);
		if (Utils.debug) {
			System.out.println("####加密时#########srcStr:" + srcStr
					+ "##########password:" + password);
			System.out.println("####加密后#########result:" + resultStr);
		}
		return resultStr;

	}

	/**
	 * 解密 先将16进制字符串 转化成字节数组
	 * 
	 * @param destStr
	 *            需要解密的内容
	 * @param password
	 *            解密的key
	 * @return
	 */
	public static String decryptString(String destStr, String password) {
		String resultStr = "";
		byte[] result = hexStringToBytes(destStr);
		result = decrypt(result, password);
		resultStr = new String(result);
		if (Utils.debug) {
			System.out.println("####解密时#########destStr:" + destStr
					+ "##########password:" + password);
			System.out.println("####解密后#########result:" + resultStr);
		}
		return resultStr;

	}

	private static SecretKeySpec getKey(String strKey) {
		byte[] arrBTmp = strKey.getBytes();
		byte[] arrB = new byte[16]; // 创建一个空的16位字节数组（默认值为0）

		for (int i = 0; i < arrBTmp.length && i < arrB.length; i++) {
			arrB[i] = arrBTmp[i];
		}

		SecretKeySpec skeySpec = new SecretKeySpec(arrB, "AES");

		return skeySpec;
	}

	public static void main(String[] args) throws Exception {

		String content = "y2akK3OQXks7FWBD";
		String password = "abcd5678901234567890";
		String result = "4cfef40e3ba266b643f0bfa5aa0f788786559134e9714888335c63cd837e82e9";

		// 加密
		System.out.println("加密前 ：" + content);
		result = encryptString(content, password);
		// 解密
		result = decryptString(result, password);
		System.out.println("解密后：" + result);
		// CryptUtils.encryptToMD5(
	}

}
