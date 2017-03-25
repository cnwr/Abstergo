
using Abstergo.Entities.Shared;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace Abstergo.Core.Common
{
    class ImageProcessor
    {
        [TestMethod("Generates QrCode By QrCoder")]
        public void GenerateQrCodeByQrCoder(string hashPassword)
        {
            var path = @"c:\" + hashPassword;

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData qrCodeData = qr.CreateQrCode(@"http://www.google.com", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(path, ImageFormat.Png);
        }

        [TestMethod("Generates QrCode By ZXing")]
        public void GenerateQrCodeByZxing(string hashPassword)
        {
            var path = @"c:\" + hashPassword;

            var barcodeWriter = new BarcodeWriter();

            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            barcodeWriter
       .Write("https://google.com/")
       .Save(path + ".bmp");
        }
    }
}
