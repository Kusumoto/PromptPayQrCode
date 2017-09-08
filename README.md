# PromptPayQrCode
[![Build Status](https://travis-ci.org/Kusumoto/PromptPayQrCode.svg)](https://travis-ci.org/Kusumoto/PromptPayQrCode)

C# library for generate PromptPay QR Code payload

## How to use

- Get a PromptPay Payload
```C#
var identifyNumber = "0123456789012" // Identify ID or Phone Number;
var amount = 4.22; // not require

var payload = new PromptPayQrCode(identifyNumber, amount);
var payloadResult = payload.PromptPayPayload; // Return PromptPay Payload for using in other QRCode Library
```
- Generate QRCode from build-in library (We choose ZXing.Net)
```C#
var identifyNumber = "0123456789012" // Identify ID or Phone Number;
var amount = 4.22; // not require
var path = "C:/Test/";
var filename = "Test";
var width = 200; // not require default 200
var height = 200; // not require default 200
var margin = 200; // not require default 5

var payload = new PromptPayQrCode(identifyNumber, amount);
payload.GeneratePromptPayQrCode(path,filename,width,height,margin);
```

## References

- https://www.blognone.com/node/95133
- https://github.com/kittinan/php-promptpay-qr
- https://github.com/dtinth/promptpay-qr
- https://github.com/diewland/promptpay-qr-plus/
- http://introcs.cs.princeton.edu/java/61data/CRC16CCITT.java
