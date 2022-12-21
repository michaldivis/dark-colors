using System;
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

    /// <summary>
    /// Creates an instance of a <see cref="ColorLayer"/>
    /// </summary>
    /// <param name="color">The color associated with the layer</param>
    /// <param name="amountPercentage">The amount of the color to use in percent (0-100)</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <see cref="AmountPercentage"/> is out of range (0-100)</exception>
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