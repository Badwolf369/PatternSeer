using Xunit;
using PatternSeer.Models;

namespace TestChart;

public class TestImportPdf
{
    [Theory]
    [InlineData("nudi pink.pdf", 3)]
    [InlineData("Froggy Wizard Pattern.pdf", 4)]
    [InlineData("NHM Dodo - Cross Stitch.pdf", 7)]
    public void TestValidPaths(string relativePath, int expectedPageCount)
    {
        Chart chart = new Chart();
        string pdfPath = Path.GetFullPath(
            "../../../test assets/" + relativePath
        );
        chart.ImportPdf(pdfPath);
        Assert.Equal(chart.PageCount, expectedPageCount);
    }

    [Theory]
    [InlineData("Fake.pdf", typeof(FileNotFoundException))]
    [InlineData("logo.ico", typeof(ArgumentOutOfRangeException))]
    [InlineData("/Path/Not/exist.pdf", typeof(DirectoryNotFoundException))]
    public void TestInvalidPaths(string relativePath, Type expectedExceptionType)
    {
        Chart chart = new Chart();
        string pdfPath = Path.GetFullPath(
            "../../../test assets/" + relativePath
        );
        Assert.Throws(expectedExceptionType, () =>
        {
            chart.ImportPdf(pdfPath);
        });
    }
}