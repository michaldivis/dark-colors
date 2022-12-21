using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DarkColors;

/// <summary>
/// A potential dominant color candidate
/// </summary>
/// <param name="Color">The color</param>
/// <param name="Brightness">The brightness the a color</param>
/// <param name="Saturation">The saturation of the color</param>
/// <param name="SpaceCoverage">The amount of space in the image the color covers</param>
/// <param name="NonGreyscaleScore">The greater the non-greyscale score, the further the color is from a gray-ish tone... the more colorful it is</param>
public record DominantColorCandidate(Color Color, float Brightness, float Saturation, float SpaceCoverage, float NonGreyscaleScore)
{
    internal static DominantColorCandidate Create(IEnumerable<Color> colors, int count, int totalCount)
    {
        var averageColor = Color.FromArgb((int)colors.Average(x => x.R), (int)colors.Average(x => x.G), (int)colors.Average(x => x.B));

        return new DominantColorCandidate(averageColor, averageColor.GetBrightness(), averageColor.GetSaturation(), ColorAnalyzer.GetSpaceCoverage(count, totalCount), ColorAnalyzer.GetNonGreyscaleScore(averageColor));
    }
}
