using PromptPayQrCode.Core;
using PromptPayQrCode.Exception;
using ZXing;
using ZXing.Common;
using System.Runtime.InteropServices;
using ImageSharp;
using System.IO;

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
            using (var fileStream = new FileStream(path + filename + ".jpg", FileMode.CreateNew))
			using (var image = Image.LoadPixelData<Rgba32>(pixelData.Pixels, width, height))
			{
                image.SaveAsJpeg(fileStream);
                fileStream.Flush();
			}
        }
    }
}
