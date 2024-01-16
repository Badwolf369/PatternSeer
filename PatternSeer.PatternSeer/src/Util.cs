using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace PatternSeer {
    class Util {
        public static bool validPdfFile(string pdfAddress) {
            if (!pdfAddress.EndsWith(".pdf")) {
                return false;
            }
            else if (!File.Exists(pdfAddress)) {
                return false;
            }
            else {
                return true;
            }
        }

        public static Bitmap LoadImageAsBitmap(string path) {
            using var stream = File.OpenRead(path);
            return new Bitmap(stream);
        }
    }
}