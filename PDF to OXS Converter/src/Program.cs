using Aspose.Pdf;
using Aspose.Pdf.Devices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace PDF2OXS {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter the path of a valid PDF File:");
            string sourceAddress = Console.ReadLine();
            
            Resolution resolution = new Resolution(300);
            BmpDevice bmpDevice = new BmpDevice(resolution);
            Document document = new Document(sourceAddress);

            using (MemoryStream imageStream = new MemoryStream())
            {
                bmpDevice.Process(document.Pages[1], imageStream);
                byte[] imageBytes = imageStream.ToArray();
                Mat cvImage = new Mat();
                CvInvoke.Imdecode(imageBytes, ImreadModes.Color, cvImage);
                CvInvoke.Resize(cvImage, cvImage, new Size(0, 0), 0.2, 0.2);
                CvInvoke.Imshow("Test", cvImage);
                CvInvoke.WaitKey();
            }
        }
    }
}