using DarkColors;
using System.Drawing;

namespace SampleApp;

public class ColorBlendingExample
{
    public string Title { get; }
    public Color BaseColor { get; }
    public ColorLayer[] Layers { get; }
    public Color ResultColor { get; }

    public ColorBlendingExample(string Title, Color baseColor, params ColorLayer[] layers)
    {
        this.Title = Title;
        BaseColor = baseColor;
        Layers = layers;
        ResultColor = ColorBlender.Combine(baseColor, layers);        
    }
}
