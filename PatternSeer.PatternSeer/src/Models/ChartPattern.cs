namespace PatternSeer.Models;

public class ChartPattern {
    //TODO: Int here shall be replaced with the OpenCV image type
    private List<List<int>> SourceImages;
    private int[] Size = {0, 0};
    private List<List<KeySymbol>> Grid;

    public int[] getSize() {
        return Size;
    }
    public KeySymbol GetSymbol(int x, int y) {
        return Grid[y][x];
    }

    //TODO: Int here shall be replaced with the OpenCV image type
    public ChartPattern(List<List<int>> sourceImages, ChartKey key) {}
}