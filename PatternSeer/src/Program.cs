using Emgu.CV;
using Emgu.CV.CvEnum;
using SkiaSharp;

namespace PatternSeer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter the path of a valid PDF File:");
            string PatternAddress = Console.ReadLine();
            if (!Util.validPdfFile(PatternAddress)) {
                Console.WriteLine($"\"{PatternAddress}\" is not a valid PDF or does not exist.");
                return;
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
