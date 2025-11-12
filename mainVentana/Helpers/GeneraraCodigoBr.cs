// Helpers/GeneraraCodigoBr.cs
using System;
using System.IO;
using BarcodeStandard;
using SkiaSharp;

namespace mainVentana.Helpers
{
    public static class GeneraraCodigoBr
    {
        public static string GenerarCodigoBarrasPng(string data)
        {
            var barcode = new Barcode
            {
                IncludeLabel = false,
                Alignment = AlignmentPositions.Center,
                BackColor = new SKColorF(1f, 1f, 1f, 1f), // blanco
                ForeColor = new SKColorF(0f, 0f, 0f, 1f), // negro
            };

            // En BarcodeStandard, Encode devuelve SKImage
            using (SKImage img = barcode.Encode(BarcodeStandard.Type.Code128, data, 600, 180))
            using (SKData png = img.Encode(SKEncodedImageFormat.Png, 100))
            {
                string path = Path.Combine(Path.GetTempPath(), $"BAR_{Guid.NewGuid():N}.png");
                using (var fs = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    png.SaveTo(fs);
                }
                return path;
            }
        }
    }
}