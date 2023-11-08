using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace PDF2OXS {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter the path of a valid PDF File:");
            string sourceAddress = Console.ReadLine();
            if (!Util.validPdfFile(sourceAddress)) {
                Console.WriteLine("Address entered is not a valid PDF or does not exist.");
                return;
            }

            Mat cvImage = new Mat();
            using (MemoryStream imageStream = new MemoryStream()) {
                byte[] pdfBytes = File.ReadAllBytes(sourceAddress);
                PDFtoImage.Conversion.SavePng(imageStream, pdfBytes);
                CvInvoke.Imdecode(imageStream.ToArray(), ImreadModes.Color, cvImage);
            }
            CvInvoke.Resize(cvImage, cvImage, new Size(0, 0), 0.2, 0.2);
            CvInvoke.Imshow("Test", cvImage);
            CvInvoke.WaitKey();
        }
    }
}