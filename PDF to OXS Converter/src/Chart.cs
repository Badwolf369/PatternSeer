namespace PDF2OXS {
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