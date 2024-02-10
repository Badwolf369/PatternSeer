using Emgu.CV;
using Emgu.CV.CvEnum;
using SkiaSharp;

namespace PatternSeer.Models;

/// <summary>
/// Wrapper for all information regarding a cross stitch chart
/// </summary>
public class Chart
{
    /* #region Fields */
    /// <summary>
    /// Contains the path to the currently opened PDF
    /// </summary>
    private string _pdfPath;
    /* #endregion Fields */

    /* #region Properties */
    /// <summary>
    /// Key used to associate the pattern's symbols with colors
    /// </summary>
    public ChartKey Key { get; private set; }
    /// <summary>
    /// Number of pages that make up the chart
    /// </summary>
    public int PageCount { get; private set; }
    /// <summary>
    /// Design's generated stitch pattern
    /// </summary>
    public ChartPattern Pattern { get; private set; }
    /// <summary>
    /// Image version of each page of the chart, incl. cover page, and key
    /// </summary>
    public List<Mat> PdfPages { get; set; }
    /* #endregion Properties */

    /* #region Constructor */
    public Chart()
    {
        PdfPages = new List<Mat>();
    }
    /* #endregion Constructtor */

    /* #region Private Methods */
    /* #endregion Private Methods */

    /* #region Public Methods */
    /// <summary>
    /// Imports a new PDF file into a list of images
    /// </summary>
    /// <param name="path">Path to the PDF</param>
    /// <exception cref="ArgumentOutOfRangeException" />
    /// <exception cref="FileNotFoundException" />
    /// <exception cref="PathNotFoundException" />
    public void ImportPdf(string path)
    {
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
                    imageStream, SKEncodedImageFormat.Png, 100);
                PdfPages.Add(new Mat());
                CvInvoke.Imdecode(
                    imageStream.ToArray(), ImreadModes.Color, PdfPages[page]);
            }
        }
        PageCount = PdfPages.Count();
    }
    /* #endregion Public Methods */
}
