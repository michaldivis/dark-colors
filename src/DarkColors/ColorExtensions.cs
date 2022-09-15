using System.Drawing;

namespace DarkColors;
public static class ColorExtensions
{
    public static Color Combine(this Color color, params ColorLayer[] layers)
    {
        return ColorBlender.Combine(color, layers);
    }
}