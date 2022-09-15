using DarkColors;
using System.Collections.Generic;
using System.Drawing;

namespace SampleApp;

public class MainViewModel
{
    public List<ColorBlendingExample> Examples { get; } = new();

    public MainViewModel()
    {
        Examples.Add(new ColorBlendingExample(Hex("#000"), new ColorLayer(Hex("#fff"), 25)));
        Examples.Add(new ColorBlendingExample(Hex("#000"), new ColorLayer(Hex("#fff"), 50)));
        Examples.Add(new ColorBlendingExample(Hex("#007d40"), new ColorLayer(Hex("#fff"), 75)));

        Examples.Add(new ColorBlendingExample(Hex("#000"), new ColorLayer(Hex("#4056F4"), 60)));

        Examples.Add(new ColorBlendingExample(Hex("#007d40"), new ColorLayer[]
        {
            new ColorLayer(Hex("#4056F4"), 42),
            new ColorLayer(Hex("#B1740F"), 28)
        }));

        Examples.Add(new ColorBlendingExample(Hex("#000"), new ColorLayer(Hex("#804056F4"), 55)));

        Examples.Add(new ColorBlendingExample(Hex("#007d40"), new ColorLayer[]
        {
            new ColorLayer(Hex("#804056F4"), 71),
            new ColorLayer(Hex("#5CB1740F"), 20)
        }));
    }

    private static Color Hex(string hex)
    {
        return ColorTranslator.FromHtml(hex);
    }
}