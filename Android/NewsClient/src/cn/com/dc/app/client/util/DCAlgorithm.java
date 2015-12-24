package cn.com.dc.app.client.util;


/**
 *
 * @author Camus
 */
public class DCAlgorithm
{
    private SHA1HMac hmac;
    private XXTEA xxtea;
    private MD5Digest md5;
    private SHA1Digest sha1;
    public static final byte[] ocraSuite = {
        -123,  46, -63, -38, -122,  33, -9, -121, 115,  58,
         -82, -74,  40, -46,  -73, 103,  9,  -71,   7, -96,
         -79, -79,  71, -27,  -22, -69,  2,   34
    };
    private static final int[] DIGITS_POWER = {
        1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000
    };
    private static final byte b = 5;
    private static final byte t = 64/b + 1;			
    private static final byte n = 16;       	
    //n numbers vandermonde matrix
    private static final byte[][] VandermondeBox = {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {3, 5, 7, 9, 11, 13, 17, 19, 21, 23, 25, 27, 29, 8, 18, 28},
        {5, 17, 21, 11, 15, 27, 12, 8, 28, 24, 6, 2, 22, 10, 9, 23},
        {15, 31, 4, 25, 6, 30, 18, 12, 16, 27, 28, 19, 7, 26, 22, 13},
        {17, 12, 28, 15, 31, 2, 26, 10, 23, 7, 20, 4, 25, 14, 11, 24},
        {22, 25, 30, 24, 7, 26, 6, 15, 19, 10, 2, 3, 13, 31, 23, 8},
        {31, 18, 16, 6, 20, 19, 9, 26, 13, 2, 23, 8, 21, 3, 25, 27},
        {4, 16, 31, 19, 8, 25, 13, 23, 18, 11, 12, 6, 5, 24, 30, 9},
        {12, 26, 23, 31, 18, 4, 3, 14, 24, 21, 29, 16, 6, 30, 15, 7},
        {20, 29, 10, 28, 23, 17, 22, 9, 14, 19, 13, 12, 4, 11, 21, 30},
        {25, 6, 19, 7, 21, 3, 20, 31, 8, 14, 4, 5, 27, 18, 24, 10},
        {14, 30, 22, 26, 3, 23, 19, 2, 25, 20, 11, 24, 18, 4, 12, 6},
        {18, 9, 13, 20, 29, 8, 11, 3, 27, 4, 24, 10, 28, 5, 6, 2}
    };
    private static final char[] digitCap = {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
        'a', 'b', 'c', 'd', 'e', 'f'
    };
    
    public DCAlgorithm()
    {
        hmac = new SHA1HMac();
        xxtea = new XXTEA();
        md5 = new MD5Digest();
        sha1 = new SHA1Digest();
    }

    public String generateOTP(String secret, int movingFactor, int codeDigits) 
    {
        String result = null;
        int digits = codeDigits;

        byte[] text = new byte[8];
        /*for(int i = 4; i < text.length; i++)
        {
            text[i] = (byte)(movingFactor & 0xff);
            movingFactor >>= 8;
        }*/

        for(int i = text.length - 1; i >= 4; i--)
        {
            text[i] = (byte)(movingFactor & 0xff);
            movingFactor >>= 8;
        }

        String stext = null;
        try
        {
            stext = new String(text, "ISO-8859-1");
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }

        //System.out.println("stext: " + stext + "!!!");
        
        byte[] hash = hmac.hmac_sha1(secret, stext);

        System.out.println("hash: " + byte2Hex(hash));

        int offset = hash[hash.length - 1] & 0xf;
        int binary = ((hash[offset] & 0x7f) << 24) | ((hash[offset + 1] & 0xff) << 16)
                     | ((hash[offset + 2] & 0xff) << 8) | (hash[offset + 3] & 0xff);

        int otp = binary % DIGITS_POWER[codeDigits];
        result = Integer.toString(otp);
        /*char[] otp = new char[codeDigits];
        for(int i = 0; i < codeDigits / 2; i++)
        {
            int b;
            if((hash[offset + i] >> 4 & 0xf) >= 0xa)
                b = (hash[offset + i] >> 4 & 0xf) - 0xa;
            else
                b = hash[offset + i] >> 4 & 0xf;
            otp[i * 2] = (char)(b + 0x30);
            if((hash[offset + i] & 0xf) >= 0xa)
                b = (hash[offset + i] & 0xf) - 0xa;
            else
                b = hash[offset + i] & 0xf;
            otp[i * 2 + 1] = (char)(b + 0x30);
        }*/
        
        /*char[] otp = new char[codeDigits];
        int tokencode = 0;
        for(int i = 0; i < codeDigits; i++)
        {
            if((i + offset) > 19)
            {
                tokencode = hash[i + offset - 20] & 0x000000ff;
                tokencode = tokencode % 10;
            }
            else
            {
                tokencode = hash[i + offset] & 0x000000ff;
                tokencode = tokencode % 10;
            }
            otp[i] = (char)(tokencode + 0x30);
        }

        result = new String(otp);*/
        while (result.length() < digits)
        {
            result = "0" + result;
        }
        return result;
    }
    
    public String generateOCRA(byte[] _ocraSuite, String key, String question) 
    {
        int codeDigits = 0;
        String result = null;
        String secret = key;
        String ocraSuite = new String(_ocraSuite);
        System.out.println("ocraSuite: " + ocraSuite);
        int ocraSuiteLength = ocraSuite.length();
        int questionLength = 0;

        String oS = ocraSuite.substring(ocraSuite.indexOf(":"), ocraSuite.indexOf(":", ocraSuite.indexOf(":") + 1));

        codeDigits = Integer.parseInt(oS.substring(oS.lastIndexOf('-')+1, oS.length()));

        if ((ocraSuite.toLowerCase().indexOf(":q") > 1) || (ocraSuite.toLowerCase().indexOf("-q") > 1)) 
        {
            questionLength = 128;
        }

        byte[] msg = new byte[ocraSuiteLength + questionLength + 1];

        byte[] bArray = ocraSuite.getBytes();
        for (int i = 0; i < bArray.length; i++) 
        {
            msg[i] = bArray[i];
        }

        if (question.length() > 0) 
        {
            bArray = question.getBytes();
            for (int i = 0; i < 128 && i < bArray.length; i++) 
            {
                msg[i + ocraSuiteLength + 1] = bArray[i];
            }
        }

        System.out.println("msg: " + byte2Hex(msg));
        
        byte[] hash;
        String text = null;
        try
        {
            text = new String(msg, "ISO-8859-1");
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }

        /*byte[] mm = new byte[8];
        mm[0] = 49;
        mm[1] = 49;
        mm[2] = 49;
        mm[3] = 49;
        mm[4] = 49;
        mm[5] = 49;
        mm[6] = 49;
        mm[7] = 49;*/

        //String text = "463846";
        //String text = new String(mm);
        //System.out.println("text: " + text);
        
        hash = hmac.hmac_sha1(secret, text);

        System.out.println("ocra hash: " + byte2Hex(hash));

        int offset = hash[hash.length - 1] & 0xf;
        int binary = ((hash[offset] & 0x7f) << 24) | ((hash[offset + 1] & 0xff) << 16)
                     | ((hash[offset + 2] & 0xff) << 8) | (hash[offset + 3] & 0xff);

        int ocra = binary % DIGITS_POWER[codeDigits];
        System.out.println("ocra: " + ocra);
        result = Integer.toString(ocra);
        /*char[] otp = new char[codeDigits];
        for(int i = 0; i < codeDigits / 2; i++)
        {
            int b;
            if((hash[offset + i] >> 4 & 0xf) >= 0xa)
                b = (hash[offset + i] >> 4 & 0xf) - 0xa;
            else
                b = hash[offset + i] >> 4 & 0xf;
            otp[i * 2] = (char)(b + 0x30);
            if((hash[offset + i] & 0xf) >= 0xa)
                b = (hash[offset + i] & 0xf) - 0xa;
            else
                b = hash[offset + i] & 0xf;
            otp[i * 2 + 1] = (char)(b + 0x30);
        }

        result = new String(otp);*/
        while (result.length() < codeDigits) 
        {
            result = "0" + result;
        }
        
        return result;
    }

    public String generateATM(byte[] _ocraSuite, String key, int movingFactor, String question)
    {
    	 int codeDigits = 0;
         String result = null;
         String secret = key;
         String ocraSuite = new String(_ocraSuite);
         System.out.println("ocraSuite: " + ocraSuite);
         int ocraSuiteLength = ocraSuite.length();
         int questionLength = 0;

         String oS = ocraSuite.substring(ocraSuite.indexOf(":"), ocraSuite.indexOf(":", ocraSuite.indexOf(":") + 1));

         codeDigits = Integer.parseInt(oS.substring(oS.lastIndexOf('-')+1, oS.length()));

         if ((ocraSuite.toLowerCase().indexOf(":q") > 1) || (ocraSuite.toLowerCase().indexOf("-q") > 1))
         {
             questionLength = 128;
         }

         byte[] msg = new byte[ocraSuiteLength + questionLength + 1];

         byte[] bArray = ocraSuite.getBytes();
         for (int i = 0; i < bArray.length; i++)
         {
             msg[i] = bArray[i];
         }

     	byte[] front8bytes = new byte[8];
    	dcshSAXORStringTo8Char(question.getBytes(), front8bytes);

    	for(int i = 0; i < front8bytes.length; i++)
    	{
            //System.out.println(front8bytes[i]);
    	}

    	byte[] last8bytes = new byte[8];
        for (int i = 0; i < 4; i++)
        {
            last8bytes[i] = last8bytes[i + 4] = (byte) (movingFactor & 0xff);
            movingFactor >>= 8;
        }

        //System.out.println();
        for(int i = 0; i < last8bytes.length; i++)
        {
            //System.out.println(last8bytes[i]);
        }

        byte[] text = new byte[8];
        for(int i = 0; i < text.length; i++)
        {
            text[i] = (byte) (front8bytes[i] ^ last8bytes[i]);
        }

        //System.out.println();
        for(int i = 0; i < text.length; i++)
        {
            //System.out.println(text[i]);
        }

         if (text.length > 0)
         {
             for (int i = 0; i < 128 && i < text.length; i++)
             {
                 msg[i + ocraSuiteLength + 1] = text[i];
             }
         }

         byte[] hash;
         String stext = null;
         try
         {
             stext = new String(msg, "ISO-8859-1");
         }
         catch(Exception e)
         {
             e.printStackTrace();
         }
         hash = hmac.hmac_sha1(secret, stext);

         int offset = hash[hash.length - 1] & 0xf;
         int binary = ((hash[offset] & 0x7f) << 24) | ((hash[offset + 1] & 0xff) << 16)
                      | ((hash[offset + 2] & 0xff) << 8) | (hash[offset + 3] & 0xff);

         int atm = binary % DIGITS_POWER[codeDigits];
         //System.out.println("atm: " + atm);
         result = Integer.toString(atm);

         while (result.length() < codeDigits)
         {
             result = "0" + result;
         }
         return result;
    }

    private int dcshSAXORStringTo8Char(byte[] buffer, byte[] ddwBuffer)
    {
    	int i, j, k, len;
        if ((buffer == null) || (ddwBuffer == null))
        {
            return 2;
        }
        len = buffer.length;
        if (len > 8)
        {
            //对大于8字节的字符串，进行8字节分割
            //每块8字节进行异或
            //最后剩余的几个字节单独异或
            k = len / 8;
            for (j = 0; j < k; j++)
            {
                for (i = 0; i < 8; i++)
        	{
                    ddwBuffer[i] = (byte) (ddwBuffer[i] ^ buffer[ j * 8 + i]);
        	}
            }
            k = len % 8;
            if ( k > 0)
            {
                for (i = 0; i < k; i++)
                {
                    ddwBuffer[i] = (byte) (ddwBuffer[i] ^ buffer[ j * 8 + i]);
        	}
            }
        }
        else
        {
            System.arraycopy(buffer, 0, ddwBuffer, 0, len);
        }
    	return 0;
    }

    public byte[] toBytes(String s)
    {
        byte[] bytes;
        bytes = new byte[s.length() / 2];
        for (int i = 0; i < bytes.length; i++)
        {
            bytes[i] = (byte) Integer.parseInt(s.substring(2 * i, 2 * i + 2), 16);
        }
        return bytes;
    }
    
    public int byte2Int(byte[] b, int index) 
    {
        int ch1 = b[index + 3] & 0xff;
        int ch2 = b[index + 2] & 0xff;
        int ch3 = b[index + 1] & 0xff;
        int ch4 = b[index + 0] & 0xff;
        return ((ch1 << 24) + (ch2 << 16) + (ch3 << 8) + (ch4 << 0));
    }
    
    public int byte2Int(byte[] b)
    {
        return byte2Int(b, 0);
    }
    
    public byte[] int2Byte(int n)
    {
        return int2Byte(n, 4);
    }

    public byte[] int2Byte(int n, int len) 
    {
        byte[] b = new byte[len];
        for (int i = len - 1; i >= 0; i --)
        {
            b[i] = (byte) ((n >>> i * 8) & 0xff);
        }
        return b;
    }
    
    public String byte2Hex(byte[] abyte0)
    {
        StringBuffer stringbuffer = new StringBuffer();
        for(int j = 0; j < abyte0.length; j++)
        {
            int i = abyte0[j] >>> 4 & 0xf;
            stringbuffer.append(digitCap[i]);
            i = abyte0[j] & 0xf;
            stringbuffer.append(digitCap[i]);
        }
        return stringbuffer.toString();
    }
    
    public long byte2Long(byte[] b) 
    {
        long ch1 = b[7] & 0xff;
        long ch2 = b[6] & 0xff;
        long ch3 = b[5] & 0xff;
        long ch4 = b[4] & 0xff;
        long ch5 = b[3] & 0xff;
        long ch6 = b[2] & 0xff;
        long ch7 = b[1] & 0xff;
        long ch8 = b[0] & 0xff;
        return ((ch1 << 56) + (ch2 << 48) + (ch3 << 40) + (ch4 << 32) + (ch5 << 24) + (ch6 << 16) + (ch7 << 8) + (ch8 << 0));
    }
	
    public byte[] long2Byte(long n)
    {
        byte[] b = new byte[8];
        for (int i = 7; i >=0; i --)
        {
            b[i] = (byte) ((n >>> i * 8) & 0xff);
        }
        return b;
    }
    
    public int decodeHalfSeed3bit(byte[] halfSeed, char[] numberString) 
    {
        long bigNumber;
        long B;
        int i;
        byte Sum;
        byte O;
        byte[] R;

        if ((halfSeed == null) || (numberString == null)) 
        {
            return -1;
        }
        bigNumber = 0;
        Sum = 0;
        O = 22;
        for (i = 1; i <= 21; i++) 
        {
            B = numberString[i - 1] - 0x31;
            bigNumber = bigNumber + (long) (B << (64 - i * 3));
            Sum = (byte) (Sum + (byte) B);
            if (B % 2 == 0)
            {
                O++;
            } 
            else 
            {
                O--;
            }
        }

        B = numberString[i - 1] - 0x31;
        bigNumber = bigNumber + (long) B;
        Sum = (byte) (Sum + (byte) B);
        if (B % 2 == 0) 
        {
            O++;
        }
        else
        {
            O--;
        }
        if (Sum >= 100)
        {
            Sum -= 100;
        }
        String sSum = (new Byte(Sum)).toString();
        if(sSum.length() < 2)
        {
            sSum = "0" + sSum;
        }
        String sO = (new Byte(O)).toString();
        if(sO.length() < 2)
        {
            sO = "0" + sO;
        }
        R = (sSum + sO).getBytes();
        for (int n = 0; n < numberString.length - i; n++) 
        {
            if (numberString[n + i] != R[n]) 
            {
                return -2;
            }
        }

        byte[] tmp = long2Byte(bigNumber);
        for (int m = 0; m < halfSeed.length; m++) 
        {
            halfSeed[m] = tmp[m];
        }
        return 0;
    }

    public int encodeHalfSeed5bit(byte[] halfSeed, byte[] Smob) 
    {
        long bigNumber;
        int i;

        if ((halfSeed == null) || (Smob == null))
        {
            return -1;
        }
        bigNumber = byte2Long(halfSeed);
        for (i = 1; i <= 12; i++) 
        {
            Smob[i - 1] = (byte) ((bigNumber >> (64 - i * 5)) & 0x000000000000001F);
        }
        Smob[i - 1] = (byte) (bigNumber & 0x000000000000000F);

        return 0;
    }

    public int matrixMulti(byte[] Smob, byte[] Cmob)
    {
        if ((Smob == null) || (Cmob == null))
        {
            return -1;
        }
        for (int j = 0; j < n; j++) 
        {
            for (int k = 0; k < t; k++) 
            {
                Cmob[j] += Smob[k] * VandermondeBox[k][j];
            }
        }
        return 0;
    }
    
    public void setKey(String key)
    {
        if(key == null || key.length() == 0)
            xxtea.setKey("dc");
    }
    
    public byte[] encrypt(byte[] plain)
    {
        byte[] abyte = xxtea.encrypt(plain);
        return abyte;
    }

    public byte[] decrypt(byte[] cipher)
    {
        byte[] abyte = xxtea.decrypt(cipher);
        return abyte;
    }
    
    public byte[] hash(byte[] pin)
    {
        byte[] digest = new byte[16];
        md5.update(pin, 0, pin.length);
        md5.doFinal(digest, 0);        
        return digest;
    }
    
    public String sha1(byte[] sn_acode)
    {
        sha1.init();
        sha1.update(sn_acode, 0, sn_acode.length);
        sha1.finish();
        return sha1.digout();
    }
    
    public int checkActiveCode(String sn_acode)
    {
        String sn = sn_acode.substring(0, 10);
        String activeCode = sn_acode.substring(10, 16);
        int tokenType = Integer.parseInt(activeCode) % 2;
  
        byte[] hash = hmac.hmac_sha1(byte2Hex(sn.getBytes()), activeCode);
	int offset = hash[hash.length - 1] & 0xf;
	int binary = ((hash[offset] & 0x7f) << 24) | ((hash[offset + 1] & 0xff) << 16)
	             | ((hash[offset + 2] & 0xff) << 8) | (hash[offset + 3] & 0xff);
	        
        String checkCode = sn_acode.substring(16, 22);

        String responseCode = Integer.toString(binary % DIGITS_POWER[checkCode.length()]);
	while (responseCode.length() < checkCode.length())
        {
            responseCode = "0" + responseCode;
	}
	System.out.println("responseCode: " + responseCode);
	if(!responseCode.equals(checkCode))
            return -2;
        else if(tokenType == 0)
            return -1;
        else
            return 0;
    }
    
}
