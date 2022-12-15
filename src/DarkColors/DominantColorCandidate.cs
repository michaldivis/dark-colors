using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DarkColors;

public record DominantColorCandidate(Color Color, float Brightness, float Saturation, float SpaceCoverage, float NonGreyscaleScore)
{
    internal static DominantColorCandidate Create(IEnumerable<Color> colors, int count, int totalCount)
    {
        var averageColor = Color.FromArgb((int)colors.Average(x => x.R), (int)colors.Average(x => x.G), (int)colors.Average(x => x.B));

        return new DominantColorCandidate(averageColor, averageColor.GetBrightness(), averageColor.GetSaturation(), ColorAnalyzer.GetSpaceCoverage(count, totalCount), ColorAnalyzer.GetNonGreyscaleScore(averageColor));
    }
}
