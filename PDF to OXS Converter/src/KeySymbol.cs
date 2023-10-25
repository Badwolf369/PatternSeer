using System.Dynamic;
using System.Reflection;

namespace PDF2OXS {
    class KeySymbol {
        //TODO: Int here shall be replaced with the OpenCV image type
        private int Image;
        private string ThreadColor = "";
        private int ThreadCount = 2;
        private int? StitchCount;
        private string Brand = "dmc";

        //TODO: Int here shall be replaced with the OpenCV image type
        public int GetImage() {
            return Image;
        }
        public string GetThreadColor() {
            return ThreadColor;
        }
        public int GetThreadCount() {
            return ThreadCount;
        }
        public int? GetStitchCount() {
            return StitchCount;
        }
        public int? SetStitchCount(int? stitchCount) {
            StitchCount = stitchCount;
            return stitchCount;
        }
        public string getBrand() {
            return Brand;
        }

        //TODO: Int here shall be replaced with the OpenCV image type
        public KeySymbol(int image) {}
    }
}