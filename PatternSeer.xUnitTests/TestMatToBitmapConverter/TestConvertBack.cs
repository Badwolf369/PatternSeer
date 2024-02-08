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
    [AvaloniaFact]
    public void TestValidArguments()
    {
        // string imageName = "ffffff.png";
        // string imagePath = Path.GetFullPath("../../../test assets/" + imageName);
        // Mat expectedMat = CvInvoke.Imread(imagePath);

        // MatToBitmapConverter converter = new MatToBitmapConverter();
        // Bitmap bitmap = new Bitmap(imagePath);
        // Mat convertedMat = (Mat)converter.ConvertBack(
        //     bitmap, typeof(Mat), null, CultureInfo.CurrentCulture);

        // convertedMat.Should().BeEquivalentTo(expectedMat);

        string imageName = "ffffff.png";
        string imagePath = Path.GetFullPath("../../../test assets/" + imageName);

        // Bitmap created directly from file
        Bitmap fileBitmap = new Bitmap(imagePath);

        // Bitmap created from memeory stream of file bytes
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        MemoryStream imageStream = new MemoryStream(imageBytes);
        Bitmap streamBitmap = new Bitmap(imageStream);


        imageStream = new MemoryStream();
        fileBitmap.Save(imageStream);
        imageStream = new MemoryStream();
        streamBitmap.Save(imageStream);
    }
}