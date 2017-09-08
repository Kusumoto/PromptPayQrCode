using System.Text;

namespace PromptPayQrCode.Extension
{
    
    public static class PromptPayExtensions
    {
		/*
        * Convert string to CRC16
        * 
        * Reference
        * http://introcs.cs.princeton.edu/java/61data/CRC16CCITT.java
        * https://www.blognone.com/node/95133
        * https://github.com/diewland/promptpay-qr-plus/blob/master/app/src/main/java/com/diewland/android/qr_pp_plus/CRC16.java
        * 
        */
		public static string ConvertToCRC16CCITT(this string data, int crc = 0xFFFF)
        {
            int polynomial = 0x1021;
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            foreach (var b in bytes)
            {
                for (int i = 0; i < 8; i++)
                {
                    bool bit = ((b >> (7 - i) & 1) == 1);
                    bool c15 = ((crc >> 15 & 1) == 1);
                    crc <<= 1;
                    if (c15 ^ bit) crc ^= polynomial;
                }
            }
            crc &= 0xffff;
            return string.Format("{0:X4}", crc).ToUpper();
        }
    }
}
