using SkiaSharp.Views.Desktop;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace SampleApp;

public static class BitmapUtils
{
    public static Color[] GetPixels(Bitmap bitmap)
    {
        return bitmap.ToSKBitmap().Pixels
            .Select(x => x.ToDrawingColor())
            .ToArray();
    }

    public static BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
        using MemoryStream memory = new MemoryStream();

        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        memory.Position = 0;
        BitmapImage bitmapimage = new BitmapImage();
        bitmapimage.BeginInit();
        bitmapimage.StreamSource = memory;
        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapimage.EndInit();

        return bitmapimage;
    }
}