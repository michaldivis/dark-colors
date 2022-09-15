using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SampleApp;

public class ColorToSolidColorBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is System.Drawing.Color color ? new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B)) : value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
