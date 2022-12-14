using System.Drawing;

namespace DarkColors;

public class ColorBlenderTests
{
    [Theory]
    [InlineData(0, "#000")]
    [InlineData(25, "#10153c")]
    [InlineData(65, "#29389e")]
    [InlineData(100, "#4056F4")]
    public void CombineWithLayers_ShouldWork_WhenAddingSingeNonTransparentColor(int percentage, string expectedHex)
    {
        var result = ColorBlender.Combine(Hex("#000"), new ColorLayer[]
        {
            new(Hex("#4056F4"), percentage)
        });
        AssertColorsMatch(result, Hex(expectedHex));
    }

    [Theory]
    [InlineData(0, "#000")]
    [InlineData(25, "#080b1f")]
    [InlineData(65, "#151c4f")]
    [InlineData(100, "#202b7a")]
    public void CombineWithLayers_ShouldWork_WhenAddingSingeTransparentColor(int percentage, string expectedHex)
    {
        var result = ColorBlender.Combine(Hex("#000"), new ColorLayer[]
        {
            new(Hex("#804056F4"), percentage) //#4056F4 with 50% transparency
        });
        AssertColorsMatch(result, Hex(expectedHex));
    }

    [Fact]
    public void CombineWithLayers_ShouldWork_WhenAddingMultipleNonTransparentColors()
    {
        var result = ColorBlender.Combine(Hex("#000"), new ColorLayer[]
        {
            new(Hex("#4056F4"), 39),
            new(Hex("#B1740F"), 25)
        });
        AssertColorsMatch(result, Hex("#3f364c"));
    }

    [Fact]
    public void CombineWithLayers_ShouldWork_WhenAddingMultipleTransparentColors()
    {
        var result = ColorBlender.Combine(Hex("#000"), new ColorLayer[]
        {
            new(Hex("#804056F4"), 31), //#4056F4 with 50% transparency
            new(Hex("#5CB1740F"), 55) //#B1740F with 36% transparency
        });
        AssertColorsMatch(result, Hex("#2b2121"));
    }

    [Theory]
    [InlineData("#004056F4", "#000")] //0%
    [InlineData("#404056F4", "#10153c")] //25%
    [InlineData("#A64056F4", "#29389e")] //65%
    [InlineData("#FF4056F4", "#4056F4")] //100%
    public void CombineWithColors_ShouldWork_WhenAddingSingeColor(string inputHex, string expectedHex)
    {
        var result = ColorBlender.Combine(Hex("#000"), Hex(inputHex));
        AssertColorsMatch(result, Hex(expectedHex));
    }

    [Fact]
    public void CombineWithColors_ShouldWork_WhenAddingMultipleColors()
    {
        var result = ColorBlender.Combine(Hex("#000"), Hex("#634056F4"), Hex("#40B1740F"));
        AssertColorsMatch(result, Hex("#3f364b"));
    }

    private static void AssertColorsMatch(Color actual, Color expected)
    {
        AssertValuesMatchApproximately(actual.A, expected.A, 1);
        AssertValuesMatchApproximately(actual.R, expected.R, 1);
        AssertValuesMatchApproximately(actual.G, expected.G, 1);
        AssertValuesMatchApproximately(actual.B, expected.B, 1);
    }

    private static void AssertValuesMatchApproximately(byte actual, byte expected, int tolerance = 0)
    {
        var actualInt = (int)actual;
        var expectedInt = (int)expected;
        actualInt.Should().BeInRange(expectedInt - tolerance, expectedInt + tolerance);
    }

    private static Color Hex(string hex)
    {
        return ColorTranslator.FromHtml(hex);
    }
}