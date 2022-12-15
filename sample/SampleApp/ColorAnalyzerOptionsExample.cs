using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DarkColors;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;

namespace SampleApp;

public partial class ColorAnalyzerExample : ObservableObject
{
    public class DemoImage
    {
        public BitmapImage? BitmapSource { get; set; }
        public Color[] Pixels { get; set; }
        public ObservableCollection<DominantColorCandidate> Candidates { get; set; } = new();
    }

    public DominantColorAnalyzerOptions Options { get; } = new()
    {
        MaxCandidateCount = 5
    };

    public ObservableCollection<DemoImage> Images { get; } = new();

    public ColorAnalyzerExample(Bitmap[] bitmaps)
    {
        var images = bitmaps.Select(x => new DemoImage
        {
            BitmapSource = BitmapUtils.BitmapToImageSource(x),
            Pixels = BitmapUtils.GetPixels(x)
        });

        foreach (var image in images)
        {
            Images.Add(image);
        }

        UpdateCandidates();
    }

    [RelayCommand]
    private void UpdateCandidates()
    {
        foreach (var result in Images)
        {
            result.Candidates.Clear();

            var candidates = ColorAnalyzer.FindDominantColors(result.Pixels, Options);

            foreach (var candidate in candidates)
            {
                result.Candidates.Add(candidate);
            }
        }
    }
}