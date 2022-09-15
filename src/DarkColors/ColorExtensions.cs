using System.Drawing;

namespace DarkColors;
public static class ColorExtensions
{
    public static Color Combine(this Color color, params ColorLayer[] layers)
    {
        return ColorBlender.Combine(color, layers);
    }

    public static Color Combine(this Color color, ColorLayer layer)
    {
        return ColorBlender.Combine(color, layer);
    }

    public static Color Combine(this Color color, params Color[] colors)
    {
        return ColorBlender.Combine(color, colors);
    }

    public static Color Combine(this Color color, Color anotherColor)
    {
        return ColorBlender.Combine(color, anotherColor);
    }
}