using System.Drawing;

namespace DarkColors;
public class ColorLayerTests
{
    [Fact]
    public void Ctor_ShouldNotThrow_WhenAmountInRange()
    {
        _ = new ColorLayer(Color.Black, 50);
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenAmountBelowZero()
    {
        Action act = () => new ColorLayer(Color.Black, -1);
        _ = act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Ctor_ShouldThrow_WhenAmountAboveHundred()
    {
        Action act = () => new ColorLayer(Color.Black, 101);
        _ = act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
