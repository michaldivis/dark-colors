using DarkColors;
using SampleApp.Properties;
using System.Collections.Generic;
using System.Drawing;

namespace SampleApp;

public class MainViewModel
{
    public List<ColorBlendingExample> ColorBlendingExamples { get; } = new();
    public ColorAnalyzerExample ColorAnalyzerExample { get; }

    public MainViewModel()
    {
        ColorBlendingExamples.Add(new ColorBlendingExample("A bit of gray", Hex("#000"), new ColorLayer(Hex("#fff"), 25)));
        ColorBlendingExamples.Add(new ColorBlendingExample("Fifty shades", Hex("#000"), new ColorLayer(Hex("#fff"), 50)));
        ColorBlendingExamples.Add(new ColorBlendingExample("Bright green", Hex("#007d40"), new ColorLayer(Hex("#fff"), 75)));

        ColorBlendingExamples.Add(new ColorBlendingExample("Is it blue or purple?", Hex("#000"), new ColorLayer(Hex("#4056F4"), 60)));

        ColorBlendingExamples.Add(new ColorBlendingExample("More than two colors", Hex("#007d40"), new ColorLayer[]
        {
            new ColorLayer(Hex("#4056F4"), 42),
            new ColorLayer(Hex("#B1740F"), 28)
        }));

        ColorBlendingExamples.Add(new ColorBlendingExample("Both alpha transparency and amount percentage used", Hex("#000"), new ColorLayer(Hex("#804056F4"), 55)));

        ColorBlendingExamples.Add(new ColorBlendingExample("Combo - both alpha transparency and amount percentage used for multiple colors", Hex("#007d40"), new ColorLayer[]
        {
            new ColorLayer(Hex("#804056F4"), 71),
            new ColorLayer(Hex("#5CB1740F"), 20)
        }));

        var demoBitmaps = new[] { Resources.vildhjarta, Resources.rivers, Resources.abovebelow, Resources.greylotus, Resources.currents, Resources.dali, Resources.metallica, Resources.northlane };

        ColorAnalyzerExample = new(demoBitmaps);
    }

    private static Color Hex(string hex)
    {
        return ColorTranslator.FromHtml(hex);
    }

    private void SimpleExample()
    {
        //The base color. This one can't be transparent. If it is, the alpha channel will be ignored.
        var baseColor = Color.FromArgb(0, 0, 0);

        //A color to add. This one can have transparency.
        var colorToAdd = Color.FromArgb(125, 55, 13);

        var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAdd);
    }

    private void AdvancedExample()
    {
        // The base color.This one can't be transparent. If it is, the alpha channel will be ignored.
        var baseColor = Color.FromArgb(0, 0, 0);

        //A color to add. This one can have transparency.
        var colorToAdd = Color.FromArgb(127, 125, 55, 13);
        //The color's amount is set to 50% and it's alpha channel is at 50% so in the result, only 25% of this color will be added on top of the base color.
        var colorToAddLayer = new ColorLayer(colorToAdd, 50); 

        var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAddLayer);

        var anotherColorToAdd = Color.FromArgb(255, 13, 79);
        var anotherColorToAddLayer = new ColorLayer(anotherColorToAdd, 25);

        var threeColorsCombined = ColorBlender.Combine(baseColor, colorToAddLayer, anotherColorToAddLayer);
    }

    private void TransparencyUsingAlphaExample()
    {
        var baseColor = Color.FromArgb(0, 0, 0);
        //set 50% transparency using the color Alpha channel
        var colorToAdd = Color.FromArgb(127, 125, 55, 13); 
        var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAdd);
    }

    private void TransparencyUsingAmountExample()
    {
        var baseColor = Color.FromArgb(0, 0, 0);
        var colorToAdd = Color.FromArgb(125, 55, 13);
        //set 50% transparency using the color AmountPercentage property of the ColorLayer
        var colorToAddLayer = new ColorLayer(colorToAdd, 50); 
        var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAdd);
    }

    private void TransparencyUsingAlphaAndAmountExample()
    {
        var baseColor = Color.FromArgb(0, 0, 0);
        //set 50% transparency using the color Alpha channel
        var colorToAdd = Color.FromArgb(127, 125, 55, 13);
        //set 50% transparency using the color AmountPercentage property of the ColorLayer. The resulting color will only be added by 25% because both color's Alpha and layer's AmountPercentage were used.
        var colorToAddLayer = new ColorLayer(colorToAdd, 50); 
        var twoColorsCombined = ColorBlender.Combine(baseColor, colorToAdd);
    }

    private void ExtensionsExample()
    {
        var baseColor = Color.FromArgb(0, 0, 0);
        var colorToAdd = Color.FromArgb(125, 55, 13);
        var twoColorsCombined = baseColor.Combine(colorToAdd);
    }
}