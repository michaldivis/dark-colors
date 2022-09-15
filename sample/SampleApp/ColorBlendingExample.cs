using DarkColors;
using System.Drawing;

namespace SampleApp;

public class ColorBlendingExample
{
    public Color BaseColor { get; }
    public ColorLayer[] Layers { get; }
    public Color ResultColor { get; }

    public ColorBlendingExample(Color baseColor, params ColorLayer[] layers)
    {
        BaseColor = baseColor;
        Layers = layers;
        ResultColor = ColorBlender.Combine(baseColor, layers);        
    }
}
