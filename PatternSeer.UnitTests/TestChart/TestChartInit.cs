using NUnit.Framework;
using PatternSeer.Models;

namespace PatternSeer.UnitTests;

public class TestChartInit
{
    [Test]
    public void TestInitFileNotExist()
    {
        string pdfPath = Path.GetFullPath(
            "../../../../PatternSeer.PatternSeer/assets/fake.pdf");;
        Assert.Throws<FileNotFoundException>(() =>
        {
            Chart testChart = new Chart(pdfPath);
        });
    }

    [Test]
    public void TestInitPathNotExist()
    {
        string pdfPath = "C://path/that/doesnt/exist.pdf";
        Assert.Throws<DirectoryNotFoundException>(() =>
        {
            Chart testChart = new Chart(pdfPath);
        });
    }

    [Test]
    public void TestInitFileNotPdf()
    {
        string pdfPath = Path.GetFullPath(
            "../../../../PatternSeer.PatternSeer/assets/logo.ico"
        );
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Chart testChart = new Chart(pdfPath);
        });
    }

    [Test]
    public void TestInitThreePagePdf()
    {
        string pdfPath = Path.GetFullPath(
            "../../../../PatternSeer.PatternSeer/assets/nudi pink.pdf");
        Chart testChart = new Chart(pdfPath);
        Assert.That(testChart.PageCount, Is.EqualTo(3));
    }

    [Test]
    public void TestInitFourPagePdf()
    {
        string pdfPath = Path.GetFullPath(
            "../../../../PatternSeer.PatternSeer/assets/Froggy Wizard Pattern.pdf");
        Chart testChart = new Chart(pdfPath);
        Assert.That(testChart.PageCount, Is.EqualTo(4));
    }

    [Test]
    public void TestInitSevenPagePdf()
    {
        string pdfPath = Path.GetFullPath(
            "../../../../PatternSeer.PatternSeer/assets/NHM Dodo - Cross Stitch.pdf");
        Chart testChart = new Chart(pdfPath);
        Assert.That(testChart.PageCount, Is.EqualTo(7));
    }
}