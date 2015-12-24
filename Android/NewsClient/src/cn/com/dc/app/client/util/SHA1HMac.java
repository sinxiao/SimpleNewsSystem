package cn.com.dc.app.client.util;

public class SHA1HMac
{
    String keystr;
    String text;

    public byte[] hmac_sha1(String secret, String text) 
    {
        keystr = secret;
        this.text = text;

        int ipad = 0x36;
        int opad = 0x5c;

        if (keystr.length() > 128) 
        {
            String key2char = "";
            int index0, keyhex0;
            for (index0 = 0; index0 < keystr.length(); index0 = index0 + 2) 
            {
                keyhex0 = Integer.parseInt(keystr.substring(index0, index0 + 2), 16);
                String keych = new Character((char) (keyhex0)).toString();
                key2char = key2char + keych;
            }

            SHA1Digest H = new SHA1Digest();
            H.init();
            H.updateASCII(key2char);
            H.finish();
            keystr = "" + H.digout();
        }

        if (keystr.length() - 128 != 0) 
        {
            while (keystr.length() < 128) 
            {
                keystr = keystr + "00";
            }
        }

        String keyipad = "";
        int index1, keyhex;
        for (index1 = 0; index1 < keystr.length(); index1 = index1 + 2) 
        {
            keyhex = Integer.parseInt(keystr.substring(index1, index1 + 2), 16);
            String keyXipadch = new Character((char) (keyhex ^ ipad)).toString();
            keyipad = keyipad + keyXipadch;
        }

        String keyopad = "";
        int index2;
        for (index2 = 0; index2 < keystr.length(); index2 = index2 + 2) 
        {
            keyhex = Integer.parseInt(keystr.substring(index2, index2 + 2), 16);
            String keyXopadch = new Character((char) (keyhex ^ opad)).toString();
            keyopad = keyopad + keyXopadch;
        }

        keyipad = keyipad + text;

        SHA1Digest shaipad = new SHA1Digest();
        shaipad.init();
        shaipad.updateASCII(keyipad);
        shaipad.finish();

        String shaipadout = shaipad.digout();

        int l, hexvalue;
        String hmacin = "";
        for (l = 0; l < shaipadout.length(); l = l + 2) 
        {
            hexvalue = Integer.parseInt(shaipadout.substring(l, l + 2), 16);
            String aChar3 = new Character((char) hexvalue).toString();
            hmacin = hmacin + aChar3;
        }

        hmacin = keyopad + hmacin;

        SHA1Digest hmacout = new SHA1Digest();
        hmacout.init();
        hmacout.updateASCII(hmacin);
        hmacout.finish();

        return hmacout.digestBits;
    }
    
}
