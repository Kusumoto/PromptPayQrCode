using PromptPayQrCode.Core;
using PromptPayQrCode.Exception;
using System.Drawing;
using ZXing;
using ZXing.Common;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PromptPayQrCode
{
    public class PromptPayQrCode
    {
        private readonly string _promptPayPayload = string.Empty;

        public string PromptPayPayload { 
            get {
                if (string.IsNullOrEmpty(_promptPayPayload))
                {
                    throw new PromptPayQrCodeException("PromptPay Payload not generated!", null);
                }
                return _promptPayPayload;
            } 
        }

		public PromptPayQrCode(string promptPayId, double? amount = null)
        {
            IPrompPayQrCodeManager promptPayManager = new PromptPayQrCodeManager(promptPayId, amount);
            _promptPayPayload = promptPayManager.GeneratePromptPayPayload();
        }

        public void GeneratePromptPayQrCode(string path, string filename, int width = 200, int height = 200, int margin = 5)
        {
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };
			var pixelData = barcodeWriter.Write(PromptPayPayload);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height))
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                try
                {
                    Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
				}
				finally
				{
					bitmap.UnlockBits(bitmapData);
				}
                bitmap.Save(string.Concat(path, filename, ".png"), ImageFormat.Png);
			}
        }
    }
}
