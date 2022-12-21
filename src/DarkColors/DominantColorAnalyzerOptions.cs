using System;

namespace DarkColors;

/// <summary>
/// Configuration options for the color analyzer
/// </summary>
public class DominantColorAnalyzerOptions
{
    /// <summary>
    /// The minimum brightness of a color to be considered
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MinBrightness { get; set; } = 0.1f;

    /// <summary>
    /// The maximum brightness of a color to be considered
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MaxBrightness { get; set; } = 0.9f;

    /// <summary>
    /// The minimum saturation of a color to be considered
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MinSaturation { get; set; } = 0.25f;

    /// <summary>
    /// The maximum saturation of a color to be considered
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MaxSaturation { get; set; } = 1f;

    /// <summary>
    /// The minimum non-greyscale score of a color to be considered. The greater the non-greyscale score, the further the color is from a gray-ish tone... the more colorful it is
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MinNonGreyscaleScore { get; set; } = 0.1f;

    /// <summary>
    /// The minimum space coverage (percentage of space occupied on the image) of a color to be considered
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float MinSpaceCoverage { get; set; } = 0f;

    /// <summary>
    /// The amount of "color grouping". The greater the value, the more will similar colors be squashed together and treated as one. The lesser the value, the more will similar colors be treated as distinct colors, ever when they're almost the same.
    /// <para>Allowed range: 0-1</para>
    /// </summary>
    public float ColorGrouping { get; set; } = 0.2f;

    /// <summary>
    /// Maximum amount of canidates to return
    /// <para>Allowed range: 1-100</para>
    /// </summary>
    public int MaxCandidateCount { get; set; } = 10;

    /// <summary>
    /// Performs validation on the values and throws if any validation rules aren't met
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException" />
    public void Validate()
    {
        if(MinBrightness < 0f || MinBrightness > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MinBrightness), MinBrightness, $"{nameof(MinBrightness)} has to be within range 0-1");
        }

        if (MaxBrightness < 0f || MaxBrightness > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxBrightness), MaxBrightness, $"{nameof(MaxBrightness)} has to be within range 0-1");
        }

        if (MinSaturation < 0f || MinSaturation > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MinSaturation), MinSaturation, $"{nameof(MinSaturation)} has to be within range 0-1");
        }

        if (MaxSaturation < 0f || MaxSaturation > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxSaturation), MaxSaturation, $"{nameof(MaxSaturation)} has to be within range 0-1");
        }

        if (MinNonGreyscaleScore < 0f || MinNonGreyscaleScore > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MinNonGreyscaleScore), MinNonGreyscaleScore, $"{nameof(MinNonGreyscaleScore)} has to be within range 0-1");
        }

        if (MinSpaceCoverage < 0f || MinSpaceCoverage > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(MinSpaceCoverage), MinSpaceCoverage, $"{nameof(MinSpaceCoverage)} has to be within range 0-1");
        }

        if (ColorGrouping < 0f || ColorGrouping > 1f)
        {
            throw new ArgumentOutOfRangeException(nameof(ColorGrouping), ColorGrouping, $"{nameof(ColorGrouping)} has to be within range 0-1");
        }

        if (MaxCandidateCount < 1 || MaxCandidateCount > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(MaxCandidateCount), MaxCandidateCount, $"{nameof(MaxCandidateCount)} has to be within range 1-100");
        }
    }
}
