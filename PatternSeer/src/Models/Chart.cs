using Emgu.CV;
using Emgu.CV.CvEnum;
using SkiaSharp;

namespace PatternSeer.Models;

/// <summary>
/// Wrapper for all information regarding a cross stitch chartww
/// </summary>
public class Chart {
    /// <summary>
    /// Contains the path to the currently opened PDF
    /// </summary>
    private string _pdfPath;
    /// <summary>
    /// Contains the generated design pattern
    /// </summary>
    private ChartPattern _pattern;
    /// <summary>
    /// Contains the pattern's color & symbol key
    /// </summary>
    private ChartKey _key;

    public List<Mat> PdfPages;
    public int PageCount;

    public ChartPattern getPattern() {
        return _pattern;
    }
    public ChartKey getKey() {
        return _key;
    }

    public void ImportPdf(string path) {
        if (!path.EndsWith(".pdf")) throw new ArgumentOutOfRangeException(
            $"Error: expected a PDF file, got {path}"
        );

        _pdfPath = path;
        byte[] pdfBytes = File.ReadAllBytes(path);
        string pdfBase64 = Convert.ToBase64String(pdfBytes);
        var pdfPagesSKBmps = PDFtoImage.Conversion.ToImages(pdfBase64)
            .Cast<SKBitmap>().ToList();
        for (int page = 0; page < pdfPagesSKBmps.Count; page++)
        {
            using (MemoryStream imageStream = new MemoryStream())
            {
                pdfPagesSKBmps[page].Encode(
                    imageStream,SKEncodedImageFormat.Png, 100);
                PdfPages.Add(new Mat());
                CvInvoke.Imdecode(
                    imageStream.ToArray(), ImreadModes.Color, PdfPages[page]);
            }
        }
        PageCount = PdfPages.Count();
    }

    public Chart()
    {
        PdfPages = new List<Mat>();
    }
}