# PromptPayQrCode
[![Build Status](https://travis-ci.org/Kusumoto/PromptPayQrCode.svg)](https://travis-ci.org/Kusumoto/PromptPayQrCode)

C# library for generate PromptPay QR Code payload implemented by .NET Standard 2.0

---
![Testing on ASP.Net MVC (.Net Framework 4.6.1)](https://github.com/Kusumoto/PromptPayQrCode/raw/master/screenshot_mvc_framework.png)

Testing on ASP.Net MVC (.Net Framework 4.6.1)

![Testing on ASP.Net MVC (Mono Framework)](https://github.com/Kusumoto/PromptPayQrCode/raw/master/screenshot_mvc_mono.png)

Testing on ASP.Net MVC (Mono Framework)

![Testing on ASP.Net MVC Core (.Net Core 2.0)](https://github.com/Kusumoto/PromptPayQrCode/raw/master/screenshot_mvc_core2.png)

Testing on ASP.Net MVC Core (.Net Core 2.0)

---

## Install via Nuget Package Manager

```sh
PM> Install-Package PromptPayQrCode
```
## Dependencies
- libgdiplus (.Net Core running in linux/osx)

## PromptPay ID Format Support
### Phone Number
- 0801234567
- 080-123-4567
- +66-89-123-4567
### National Identify ID
- 1111111111111
- 1-1111-11111-11-1
### Tax ID
- 0123456789012

## How to use

- Get a PromptPay Payload
```C#
var identifyNumber = "0123456789012" // Identify ID or Phone Number;
var amount = 4.22; // not require

var payload = new PromptPayQrCode.PromptPayQrCode(identifyNumber, amount);
var payloadResult = payload.PromptPayPayload; // Return PromptPay Payload for using in other QRCode Library
```
- Generate QRCode from build-in library (We're choose ZXing.Net) If you using .Net Standard 2.0, you need to install CoreCompat.System.Drawing package.
```C#
var identifyNumber = "0123456789012" // Identify ID or Phone Number;
var amount = 4.22; // not require
var path = "C:/Test/";
var filename = "Test";
var width = 200; // not require default 200
var height = 200; // not require default 200
var margin = 5; // not require default 5

var payload = new PromptPayQrCode.PromptPayQrCode(identifyNumber, amount);
payload.GeneratePromptPayQrCode(path,filename,width,height,margin);
```

## References

- https://www.blognone.com/node/95133
- https://github.com/kittinan/php-promptpay-qr
- https://github.com/dtinth/promptpay-qr
- https://github.com/diewland/promptpay-qr-plus/
- http://introcs.cs.princeton.edu/java/61data/CRC16CCITT.java
