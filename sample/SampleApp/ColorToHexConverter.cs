using System;
using System.Globalization;
using System.Windows.Data;

namespace SampleApp;
public class ColorToHexConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is System.Drawing.Color color ? GetHex(color) : value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    private static string GetHex(System.Drawing.Color c)
    {
        if(c.A < 255)
        {
            return $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    }
}
