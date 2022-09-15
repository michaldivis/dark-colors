using System.Drawing;

namespace DarkColors;

/// <summary>
/// A definition of a color layer that contains the color and the amount to add
/// </summary>
public class ColorLayer
{
    /// <summary>
    /// Color of the layer, can have transparency
    /// </summary>
    public Color Color { get; }

    /// <summary>
    /// Amount to add. Can range from 0 to 100.
    /// <para>0 = no color added, 100 = 100% added</para>
    /// </summary>
    public int AmountPercentage { get; }

    public ColorLayer(Color color, int amountPercentage)
	{
		if(amountPercentage < 0 || amountPercentage > 100)
		{
			throw new ArgumentOutOfRangeException(nameof(amountPercentage), amountPercentage, "Amount percentage has to be in range 0-100");
		}

		Color = color;
		AmountPercentage = amountPercentage;
	}
}