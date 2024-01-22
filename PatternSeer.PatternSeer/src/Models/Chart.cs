using Emgu.CV;
using Emgu.CV.CvEnum;
using SkiaSharp;

namespace PatternSeer.Models;

/// <summary>
/// Wrapper for all information regarding a cross stitch chartww
/// </summary>
public class Chart {
    private string PdfPath;
    private List<Mat> PdfPages;
    public int PageCount;
    private ChartPattern Pattern;
    private ChartKey Key;

    public ChartPattern getPattern() {
        return Pattern;
    }
    public ChartKey getKey() {
        return Key;
    }

    private void ImportPdf(string path) {
        if (!path.EndsWith(".pdf")) throw new ArgumentOutOfRangeException(
            $"Error: expected a PDF file, got {path}"
        );

        PdfPath = path;
        byte[] pdfBytes = File.ReadAllBytes(path);
        string pdfBase64 = Convert.ToBase64String(pdfBytes);
        var pdfPagesSKBmps = PDFtoImage.Conversion.ToImages(pdfBase64).Cast<SKBitmap>().ToList();
        for (int page = 0; page < pdfPagesSKBmps.Count; page++)
        {
            using (MemoryStream imageStream = new MemoryStream())
            {
                pdfPagesSKBmps[page].Encode(imageStream, SKEncodedImageFormat.Png, 100);
                PdfPages.Add(new Mat());
                CvInvoke.Imdecode(imageStream.ToArray(), ImreadModes.Color, PdfPages[page]);
            }
        }
        PageCount = PdfPages.Count();
    }

    public Chart(string path)
    {
        PdfPages = new List<Mat>();
        ImportPdf(path);
    }
}