using Emgu.CV;
using Emgu.CV.CvEnum;
using SkiaSharp;

namespace PatternSeer {
    class Program {
        static void Main(string[] args) {
            string PatternAddress;
            while(true) {
                Console.WriteLine("Please enter the path of a valid PDF File:");
                PatternAddress = Console.ReadLine();
                if (Util.validPdfFile(PatternAddress)) {
                    Console.WriteLine($"Importing {PatternAddress}");
                    break;
                }
                else {
                    Console.WriteLine($"\"{PatternAddress}\" does not exist or is not a PDF not exist.");
                }
            }

            List<Mat> pdfCvImages = new List<Mat>();
            byte[] pdfBytes = File.ReadAllBytes(PatternAddress);
            string pdf64String = Convert.ToBase64String(pdfBytes);
            var pdfSKBmps = PDFtoImage.Conversion.ToImages(pdf64String)
                .Cast<SKBitmap>().ToList();
            for (int page = 0; page < pdfSKBmps.Count; page++) {
                using (MemoryStream imageStream = new MemoryStream()) {
                    pdfSKBmps[page].Encode(imageStream, SKEncodedImageFormat.Png, 100);
                    pdfCvImages.Add(new Mat());
                    CvInvoke.Imdecode(imageStream.ToArray(), ImreadModes.Color, pdfCvImages[page]);
                }
                Console.WriteLine($"Sucessfully loaded page {page} of pattern");
                //? \/ image debugging \/
                // Mat cvDebug = new Mat();
                // CvInvoke.ResizeForFrame(pdfCvImages[page], cvDebug, new Size(480, 640));
                // CvInvoke.Imshow($"Page {page}", cvDebug);
                //? /\ image debugging /\
            }
            CvInvoke.WaitKey();
            CvInvoke.DestroyAllWindows();
        }
    }
}
