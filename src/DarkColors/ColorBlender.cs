using System.Drawing;

namespace DarkColors;

/// <summary>
/// Utility for blending multiple colors with transparency support
/// </summary>
public static class ColorBlender
{
    /// <summary>
    /// Blend a base color with one or more colors
    /// </summary>
    /// <param name="nonTransparentBase">Base color - transparency will be ignored</param>
    /// <param name="colors">Colors to add - supports transparency</param>
    /// <returns>Color blending result</returns>
    public static Color Combine(Color nonTransparentBase, params Color[] colors)
    {
        var result = nonTransparentBase;

        foreach (var color in colors)
        {
            result = Blend(result, color, 100);
        }

        return result;
    }

    /// <summary>
    /// Blend a base color with one or more colors
    /// </summary>
    /// <param name="nonTransparentBase">Base color - transparency will be ignored</param>
    /// <param name="color">Color to add - supports transparency</param>
    /// <returns>Color blending result</returns>
    public static Color Combine(Color nonTransparentBase, Color color)
    {
        return Blend(nonTransparentBase, color, 100);
    }

    /// <summary>
    /// Blend a base color with one or more colors
    /// </summary>
    /// <param name="nonTransparentBase">Base color - transparency will be ignored</param>
    /// <param name="layers">Layers to add - supports transparency</param>
    /// <returns>Color blending result</returns>
    public static Color Combine(Color nonTransparentBase, params ColorLayer[] layers)
    {
        var result = nonTransparentBase;

        foreach (var layer in layers)
        {
            var amount = (double)layer.AmountPercentage / 100;
            result = Blend(result, layer.Color, amount);
        }

        return result;
    }

    /// <summary>
    /// Blend a base color with one or more colors
    /// </summary>
    /// <param name="nonTransparentBase">Base color - transparency will be ignored</param>
    /// <param name="layer">Layer to add - supports transparency</param>
    /// <returns>Color blending result</returns>
    public static Color Combine(Color nonTransparentBase, ColorLayer layer)
    {
        var amount = (double)layer.AmountPercentage / 100;
        return Blend(nonTransparentBase, layer.Color, amount);
    }

    private static Color Blend(Color source, Color added, double addedManualAmount)
    {
        var addedTransparencyAmount = (double)added.A / 255;
        var addedAmount = addedManualAmount * addedTransparencyAmount;
        var r = BlendChannel(source.R, added.R, addedAmount);
        var g = BlendChannel(source.G, added.G, addedAmount);
        var b = BlendChannel(source.B, added.B, addedAmount);
        return Color.FromArgb(r, g, b);
    }

    private static int BlendChannel(byte source, byte added, double addedAmount)
    {
        var sourceAmount = 1d - addedAmount;
        var result = (source * sourceAmount) + (added * addedAmount);
        return (int)result;
    }
}