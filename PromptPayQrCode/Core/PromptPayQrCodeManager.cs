using System;
using System.Text.RegularExpressions;
using PromptPayQrCode.Extension;

namespace PromptPayQrCode.Core
{
    public class PromptPayQrCodeManager : IPrompPayQrCodeManager
    {
		private readonly string _promptPayId;
		private readonly double? _amount;

        public PromptPayQrCodeManager(string promptPayId, double? amount = null)
		{
            _promptPayId = promptPayId;
            _amount = amount;
		}

        public string GeneratePromptPayPayload()
        {
			var target = SanitizeTarget(_promptPayId);
			var targetType = target.Length >= 13 ? PromptPayQrCodeConstant.BOT_ID_MERCHANT_TAX_ID : PromptPayQrCodeConstant.BOT_ID_MERCHANT_PHONE_NUMBER;
			var data = new string[]
			{
				Format(PromptPayQrCodeConstant.ID_PAYLOAD_FORMAT, PromptPayQrCodeConstant.PAYLOAD_FORMAT_EMV_QRCPS_MERCHANT_PRESENTED_MODE),
				Format(PromptPayQrCodeConstant.ID_POI_METHOD, _amount.HasValue ? PromptPayQrCodeConstant.POI_METHOD_DYNAMIC : PromptPayQrCodeConstant.POI_METHOD_STATIC),
				Format(PromptPayQrCodeConstant.ID_MERCHANT_INFORMATION_BOT, Serialize(new string[] {
					Format(PromptPayQrCodeConstant.MERCHANT_INFORMATION_TEMPLATE_ID_GUID, PromptPayQrCodeConstant.GUID_PROMPTPAY),
					Format(targetType, FormatTarget(target))
				})),
				Format(PromptPayQrCodeConstant.ID_COUNTRY_CODE, PromptPayQrCodeConstant.COUNTRY_CODE_TH),
				Format(PromptPayQrCodeConstant.ID_TRANSACTION_CURRENCY, PromptPayQrCodeConstant.TRANSACTION_CURRENCY_THB),
                _amount.HasValue ? Format(PromptPayQrCodeConstant.ID_TRANSACTION_AMOUNT, FormatAmount(_amount.Value).ToString()): string.Empty,
			};
			var dataToCrc = string.Concat(Serialize(data), PromptPayQrCodeConstant.ID_CRC, "04");
			var crcResult = new string[]
			{
				Format(PromptPayQrCodeConstant.ID_CRC, dataToCrc.ConvertToCRC16CCITT())
			};

			var finalDataSet = new string[data.Length + crcResult.Length];
			data.CopyTo(finalDataSet, 0);
			crcResult.CopyTo(finalDataSet, data.Length);
			return Serialize(finalDataSet);
        }

		public string SanitizeTarget(string promptPayId)
		{
            return Regex.Replace(promptPayId, "[^0-9]", string.Empty);
		}

		public double FormatAmount(double amount)
		{
			return Math.Round(amount, 2);
		}

		public string Serialize(string[] payload)
		{
            return string.Join(string.Empty, payload);
		}

		public string Format(string id, string data)
		{
			var dataConcat = string.Concat("00", data.Length);
            return string.Join(string.Empty, id, dataConcat.Substring(dataConcat.Length - 2), data);
		}

		public string FormatTarget(string target)
		{
			var str = SanitizeTarget(target);
			if (str.Length >= 13) return str;
			var targetTemp = string.Concat("0000000000000", Regex.Replace(str, "^0", "66"));
			return targetTemp.Substring(targetTemp.Length - 13);
		}
    }
}
