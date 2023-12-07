namespace PatternSeer.Models {
    class ChartKey {
        //TODO: Int here shall be replaced with the OpenCV image type
        private int SourceImage;
        private KeySymbol[] Symbols = {};

        public KeySymbol[] getSymbols() {
            return Symbols;
        }

        //TODO: Int here shall be replaced with the OpenCV image type
        public ChartKey(int SourceImage) {}
        //TODO: Int here shall be replaced with the OpenCV image type
        public KeySymbol MatchSymbol(int image) {
            return new KeySymbol(image);
        }
    }
}