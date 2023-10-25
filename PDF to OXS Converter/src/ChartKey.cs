namespace PDF2OXS {
    class ChartKey {
        //TODO: Int here shall be replaced with the OpenCV image type
        private int[] SourceImages = {};
        private KeySymbol[] Symbols = {};

        public KeySymbol getSymbols() {
            return Symbols;
        }

        //TODO: Int here shall be replaced with the OpenCV image type
        public ChartKey(int SourceImages) {}
        //TODO: Int here shall be replaced with the OpenCV image type
        public KeySymbol MatchSymbol(int image) {}
    }
}