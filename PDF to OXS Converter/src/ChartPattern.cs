namespace PDF2OXS {
    class ChartPattern {
        //TODO: Int here shall be replaced with the OpenCV image type
        private int[][] SourceImages = {0};
        private int[] Size = {0, 0};
        private KeySymbol[][] Contents = {};

        public int[] getSize() {
            return Size;
        }
        public KeySymbol GetSymbol(int x, int y) {
            return Contents[y][x];
        }

        //TODO: Int here shall be replaced with the OpenCV image type
        public ChartPattern(int[][] sourceImages, ChartKey key) {}
    }
}