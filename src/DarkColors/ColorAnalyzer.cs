using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DarkColors;

/// <summary>
/// Utility for finding a dominant color within an image
/// </summary>
public static class ColorAnalyzer
{
    /// <summary>
    /// Find the dominant color in an image (array of pixels)
    /// </summary>
    /// <param name="pixels">Pixels of the image</param>
    /// <param name="configurator">Configuration</param>
    /// <returns>A list of dominant color candidates</returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static List<DominantColorCandidate> FindDominantColors(Color[] pixels, Action<DominantColorAnalyzerOptions>? configurator = null)
    {
        var options = new DominantColorAnalyzerOptions();
        configurator?.Invoke(options);

        return FindDominantColors(pixels, options);
    }

    /// <summary>
    /// Find the dominant color in an image (array of pixels)
    /// </summary>
    /// <param name="pixels">Pixels of the image</param>
    /// <returns>A list of dominant color candidates</returns>
    /// <exception cref="ArgumentOutOfRangeException" />
    public static List<DominantColorCandidate> FindDominantColors(Color[] pixels)
    {
        return FindDominantColors(pixels, new DominantColorAnalyzerOptions());
    }

    /// <summary>
    /// Find the dominant color in an image (array of pixels)
    /// </summary>
    /// <param name="pixels">Pixels of the image</param>
    /// <param name="options">Configuration</param>
    /// <returns>A list of dominant color candidates</returns>
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="ArgumentOutOfRangeException" />
    public static List<DominantColorCandidate> FindDominantColors(Color[] pixels, DominantColorAnalyzerOptions options)
    {
        if(options is null)
        {
            throw new ArgumentNullException(nameof(options), $"{nameof(options)} cannot be null");
        }

        options.Validate();

        var roundTo = (int)Math.Clamp(options.ColorGrouping * 100, 1, 100);

        var candidates = pixels
            .Select(x => new 
            { 
                Color = x,
                AverageColor = Color.FromArgb(RoundToAndClamp(x.R, roundTo, 0, 255), RoundToAndClamp(x.G, roundTo, 0, 255), RoundToAndClamp(x.B, roundTo, 0, 255)), 
            })
            .GroupBy(x => x.AverageColor)
            .Take(100)
            .Select(x => DominantColorCandidate.Create(x.Select(c => c.Color), x.Count(), pixels.Length))
            .OrderByDescending(x => x.SpaceCoverage)
            .ThenByDescending(x => x.NonGreyscaleScore);

        var filtered = candidates
            .Where(x => x.Brightness >= options.MinBrightness && x.Brightness <= options.MaxBrightness)
            .Where(x => x.Saturation >= options.MinSaturation && x.Saturation <= options.MaxSaturation)
            .Where(x => x.SpaceCoverage > options.MinSpaceCoverage)
            .Where(x => x.NonGreyscaleScore > options.MinNonGreyscaleScore)
            .Take(options.MaxCandidateCount)
            .ToList();

        if (!filtered.Any() && candidates.Any())
        {
            return new List<DominantColorCandidate> { candidates.First() };
        }

        return filtered;
    }

    internal static float GetNonGreyscaleScore(Color color)
    {
        var r = Math.Abs(color.R - color.G);
        var g = Math.Abs(color.G - color.B);
        var b = Math.Abs(color.B - color.R);

        var nonGreyscaleScore = (float)(r + g + b) / (255 * 3);

        return nonGreyscaleScore;
    }

    internal static float GetSpaceCoverage(int count, int totalCount)
    {
        return (float)count / totalCount;
    }

    private static int RoundToAndClamp(int number, int roundTo, int min, int max)
    {
        var rounded = Math.Round((double)number / roundTo, 0, MidpointRounding.ToZero) * roundTo;
        return Math.Clamp((int)rounded, min, max);
    }
}