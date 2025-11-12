// Helpers/GeneraraCodigoBr.cs
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using ZXing.Common;
using ZXing;

namespace mainVentana.Helpers
{
    public static class GeneraraCodigoBr
    {
        public static string GenerarCodigoBarrasPng(string data)
        {
            var writer = new ZXing.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 600,
                    Height = 180,
                    Margin = 2,
                    PureBarcode = true
                }
            };

            using (Bitmap bmp = writer.Write(data))
            {
                string path = Path.Combine(Path.GetTempPath(), $"BAR_{Guid.NewGuid():N}.png");
                bmp.Save(path, ImageFormat.Png);
                return path;
            }
        }
    }
}