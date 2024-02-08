using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace PatternSeer.Converters;

/// <summary>
/// Value converter that converts from Emgu.CV.Mat to
/// Avalonia.Media.Imaging.Bitmap.
/// </summary>
public class MatToBitmapConverter : IValueConverter {
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Mat mat && targetType == typeof(Bitmap))
        {
            using (MemoryStream imageStream = new MemoryStream())
            {
                VectorOfByte matBytes = new VectorOfByte();
                CvInvoke.Imencode(".png", mat, matBytes);
                imageStream.Write(matBytes.ToArray());
                return new Bitmap(imageStream);
            }
        }
        else
        {
            return AvaloniaProperty.UnsetValue;
        }
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Bitmap bitmap && targetType == typeof(Mat))
        {
            using (MemoryStream imageStream = new MemoryStream())
            {
                Mat mat = new Mat();
                bitmap.Save(imageStream);
                CvInvoke.Imdecode(imageStream.ToArray(), ImreadModes.Color, mat);
                return mat;
            }
        }
        return AvaloniaProperty.UnsetValue;
    }
}