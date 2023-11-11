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
    }
}