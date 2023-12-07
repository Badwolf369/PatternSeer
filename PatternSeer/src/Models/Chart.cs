namespace PatternSeer.Models {
    /// <summary>
    /// Wrapper for all information regarding a cross stitch chartww
    /// </summary>
    class Chart {
        //TODO int here is to be replaced with the OpenCV image type
        private int Source;
        private ChartPattern Pattern;
        private ChartKey Key;

        public ChartPattern getPattern() {
            return Pattern;
        }
        public ChartKey getKey() {
            return Key;
        }

        public Chart() {}
    }
}