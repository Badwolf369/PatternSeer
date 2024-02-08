using Xunit;
using PatternSeer.Converters;
using Emgu.CV;
using Avalonia.Media.Imaging;
using System.Globalization;
using Avalonia.Headless.XUnit;
using FluentAssertions;

namespace TestMatToBitmapConverter;

public class TestConvert
{
    [AvaloniaTheory]
    [InlineData("ff0000.png")]
    [InlineData("00ff00.png")]
    [InlineData("0000ff.png")]
    [InlineData("ffff00.png")]
    [InlineData("00ffff.png")]
    [InlineData("ff00ff.png")]
    [InlineData("ffffff.png")]
    [InlineData("000000.png")]
    public void TestValidArguments(string imageName)
    {
        string imagePath = "../../../test assets/" + imageName;
        Bitmap expectedBitmap = new Bitmap(imagePath);

        MatToBitmapConverter converter = new MatToBitmapConverter();
        Mat mat = CvInvoke.Imread(imagePath);
        Bitmap convertedBitmap = (Bitmap)converter.Convert(
            mat, typeof(Bitmap), null, CultureInfo.CurrentCulture);

        convertedBitmap.Should().BeEquivalentTo(expectedBitmap);
    }
}