using System;
using System.IO;
using Xunit;

namespace PromptPayQrCode.Test
{
    public class ThaiPromptPayQrCodeImageTest
    {
        [Fact]
        public void Generate_PromptPay_Qr_With_Local_Phone_Number_No_Amount_Test()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var filename = "test_qr";
			var phoneNumber = "0801234567";
            new PromptPayQrCode(phoneNumber).GeneratePromptPayQrCode(path, filename);
            Assert.True(File.Exists(string.Concat(path, filename, ".jpg")));
        }
    }
}
