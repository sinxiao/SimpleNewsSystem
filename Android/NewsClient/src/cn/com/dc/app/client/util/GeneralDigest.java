package cn.com.dc.app.client.util;

public abstract class GeneralDigest
{
    private byte[] xBuf;
    private int xBufOff;
    private long byteCount;
    
    public GeneralDigest()
    {
        xBuf = new byte[4];
        xBufOff = 0;
    }
        
    public abstract void processWord(byte[] in, int inOff);

    public abstract void processLength(long bitLength);

    public abstract void processBlock();
    
    public void reset()
    {
        byteCount = 0L;
        xBufOff = 0;
        for(int i = 0; i < xBuf.length; i++)
            xBuf[i] = 0;
    }
    
    public void update(byte in)
    {
        xBuf[xBufOff++] = in;
        if(xBufOff == xBuf.length)
        {
            processWord(xBuf, 0);
            xBufOff = 0;
        }
        byteCount++;
    }

    public void update(byte[] in, int inOff, int len)
    {
        for(; xBufOff != 0 && len > 0; len--)
        {
            update(in[inOff]);
            inOff++;
        }

        while(len > xBuf.length) 
        {
            processWord(in, inOff);
            inOff += xBuf.length;
            len -= xBuf.length;
            byteCount += xBuf.length;
        }
        for(; len > 0; len--)
        {
            update(in[inOff]);
            inOff++;
        }
    }

    public void finish()
    {
        long bitLength = byteCount << 3;
        update((byte)128);
        while(xBufOff != 0) 
            update((byte)0);
        processLength(bitLength);
        processBlock();
    }

}