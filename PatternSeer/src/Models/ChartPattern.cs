using Emgu.CV;

namespace PatternSeer.Models;

public class ChartPattern
{

    /* #region Fields */
    private List<List<Mat>> _unkeyedGrid;
    private List<List<KeySymbol>> _keyedGrid;
    /* #endregion Fields */

    /* #region Properties */
    public Tuple<int, int> Size { get; private set; }
    /* #endregion Properties */

    /* #region Constructors */
    public ChartPattern(List<List<Mat>> unkeyedPattern, ChartKey key)
    {
        
    }
    /* #endregion Constructors */

    /* #region Private Methods */
    /* #endregion Private Methods */

    /* #region Public Methods */
    public KeySymbol GetSymbolAt(int x, int y)
    {
        return _keyedGrid[y][x];
    }

    public void KeyGrid(ChartKey Key)
    {

    }
    /* #endregion Public Methods */
}