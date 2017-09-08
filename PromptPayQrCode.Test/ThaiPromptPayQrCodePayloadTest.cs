using PromptPayQrCode.Core;
using Xunit;

namespace PromptPayQrCode.Test
{
    public class ThaiPromptPayQRCodePayloadTest
    {
        [Fact]
        public void Generate_PromptPay_Payload_With_Local_Phone_Number_No_Amount_Test()
        {
            var phoneNumber = "0801234567";
            var payloadResult = "00020101021129370016A000000677010111011300668012345675802TH530376463046197";
            var payload = new PromptPayQrCode(phoneNumber)
                              .PromptPayPayload;
            
            Assert.Equal(payloadResult, payload);
        }
		[Fact]
		public void Generate_PromptPay_Payload_With_Dashed_Local_Phone_Number_No_Amount_Test()
		{
			var phoneNumber = "080-123-4567";
			var payloadResult = "00020101021129370016A000000677010111011300668012345675802TH530376463046197";
			var payload = new PromptPayQrCode(phoneNumber)
                             .PromptPayPayload;
            
			Assert.Equal(payloadResult, payload);
		}
		[Fact]
		public void Generate_PromptPay_Payload_With_Dashed_Phone_Number_No_Amount_Test()
		{
			var phoneNumber = "+66-89-123-4567";
			var payloadResult = "00020101021129370016A000000677010111011300668912345675802TH5303764630429C1";
			var payload = new PromptPayQrCode(phoneNumber)
                              .PromptPayPayload;
            
			Assert.Equal(payloadResult, payload);
		}
		[Fact]
        public void Generate_PromptPay_Payload_With_National_ID_Number_No_Amount_Test()
		{
			var identifyNumber = "1111111111111";
			var payloadResult = "00020101021129370016A000000677010111021311111111111115802TH530376463047B5A";
			var payload = new PromptPayQrCode(identifyNumber)
                              .PromptPayPayload;
            
			Assert.Equal(payloadResult, payload);
		}
		[Fact]
		public void Generate_PromptPay_Payload_With_Dashed_National_ID_Number_No_Amount_Test()
		{
			var identifyNumber = "1-1111-11111-11-1";
			var payloadResult = "00020101021129370016A000000677010111021311111111111115802TH530376463047B5A";
            var payload = new PromptPayQrCode(identifyNumber)
                              .PromptPayPayload;
            
			Assert.Equal(payloadResult, payload);
		}
		[Fact]
        public void Generate_PromptPay_Payload_With_Tax_ID_Number_No_Amount_Test()
		{
			var identifyNumber = "0123456789012";
			var payloadResult = "00020101021129370016A000000677010111021301234567890125802TH530376463040CBD";
			var payload = new PromptPayQrCode(identifyNumber)
                              .PromptPayPayload; 
            
			Assert.Equal(payloadResult, payload);
		}
		[Fact]
		public void Generate_PromptPay_Payload_Amount_Test()
		{
			var identifyNumber = "000-000-0000";
            var amount = 4.22;
			var payloadResult = "00020101021229370016A000000677010111011300660000000005802TH530376454044.226304E469";
            var payload = new PromptPayQrCode(identifyNumber,amount)
                          .PromptPayPayload;
            
			Assert.Equal(payloadResult, payload);
		}
    }
}
