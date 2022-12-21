using System;
using System.Diagnostics;
using System.Drawing;

namespace DarkColors;

public class ColorAnalyzerTests
{
    private readonly Color[] _pixels = new[] { Color.Black, Color.Gray, Color.White, Color.Green, Color.Red };

    [Fact]
    public void FindDominantColors_ShouldThrow_WhenPixelsNull()
    {
        Action act = () => ColorAnalyzer.FindDominantColors(null!);
        act.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void FindDominantColors_ShouldThrow_WhenPixelsEmpty()
    {
        Action act = () => ColorAnalyzer.FindDominantColors(Array.Empty<Color>());
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void FindDominantColors_ShouldThrow_WhenOptionsNull()
    {
        Action act = () => ColorAnalyzer.FindDominantColors(_pixels, (DominantColorAnalyzerOptions)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void FindDominantColors_ShouldWork()
    {
        var candidates = ColorAnalyzer.FindDominantColors(_pixels);
        
        candidates.Should().Contain(c => CompareColors(c.Color, Color.Green));
        candidates.Should().Contain(c => CompareColors(c.Color, Color.Red));

        candidates.Should().NotContain(c => CompareColors(c.Color, Color.Black));
        candidates.Should().NotContain(c => CompareColors(c.Color, Color.Gray));
        candidates.Should().NotContain(c => CompareColors(c.Color, Color.White));
    }

    private bool CompareColors(Color a, Color b)
    {
        return a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B;
    }
}