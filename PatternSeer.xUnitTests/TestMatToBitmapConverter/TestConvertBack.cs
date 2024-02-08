using Xunit;
using PatternSeer.Converters;
using Avalonia.Headless.XUnit;
using Emgu.CV;
using Avalonia.Media.Imaging;
using System.Globalization;
using FluentAssertions;

namespace TestMatToBitmapConverter;

public class TestConvertBack
{
    [AvaloniaTheory]
    [InlineData("ffffff.png")]
    [InlineData("ffff00.png")]
    [InlineData("ff00ff.png")]
    [InlineData("00ffff.png")]
    [InlineData("ff0000.png")]
    [InlineData("00ff00.png")]
    [InlineData("0000ff.png")]
    [InlineData("000000.png")]
    public void TestValidArguments(string imageName)
    {
        string imagePath = Path.GetFullPath("../../../test assets/" + imageName);
        Mat expectedMat = CvInvoke.Imread(imagePath);

        MatToBitmapConverter converter = new MatToBitmapConverter();
        Bitmap bitmap = new Bitmap(imagePath);
        Mat convertedMat = (Mat)converter.ConvertBack(
            bitmap, typeof(Mat), null, CultureInfo.CurrentCulture);

        convertedMat.Should().BeEquivalentTo(expectedMat, options => options
            .Excluding(img => img.DataPointer)
            .Excluding(img => img.Ptr));
    }
}