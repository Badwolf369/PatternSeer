using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using SkiaSharp;

namespace PatternSeer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter the path of a valid PDF File:");
            string sourceAddress = Console.ReadLine();
            if (!Util.validPdfFile(sourceAddress)) {
                Console.WriteLine("Address entered is not a valid PDF or does not exist.");
                return;
            }

            List<Mat> pdfCvImages = new List<Mat>();
            byte[] pdfBytes = File.ReadAllBytes(sourceAddress);
            string pdf64String = Convert.ToBase64String(pdfBytes);
            var pdfSKBmps = PDFtoImage.Conversion.ToImages(pdf64String).Cast<SKBitmap>().ToList();
            for (int page = 0; page < pdfSKBmps.Count; page++) {
                using (MemoryStream imageStream = new MemoryStream()) {
                    pdfSKBmps[page].Encode(imageStream, SKEncodedImageFormat.Png, 100);
                    pdfCvImages.Add(new Mat());
                    CvInvoke.Imdecode(imageStream.ToArray(), ImreadModes.Color, pdfCvImages[page]);
                }
                //? image debugging options
                Mat cvDebug = new Mat();
                CvInvoke.ResizeForFrame(pdfCvImages[page], cvDebug, new Size(480, 640));
                CvInvoke.Imshow($"Page {page}", cvDebug);
            }
            CvInvoke.WaitKey();
        }
    }
}