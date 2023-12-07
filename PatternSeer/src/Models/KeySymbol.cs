using System.Dynamic;
using System.Reflection;

namespace PatternSeer.Models {
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
        public string GetColor() {
            return ThreadColor;
        }
        public int GetStrand() {
            return ThreadCount;
        }
        public int? GetCount() {
            return StitchCount;
        }
        public int? SetCount(int? stitchCount) {
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