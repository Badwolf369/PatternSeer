using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Emgu.CV;
using PatternSeer.Models;


namespace PatternSeer.ViewModels;

/// <summary>
/// Primary ViewModel associated with the View <c>MainView</c>
/// </summary>
public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
{
    /* #region Observable Properties */
    /// <summary>
    /// Is/should the pdf file picker currently be open?
    /// </summary>
    [ObservableProperty]
    private bool _isPdfPickerOpen;
    /// <summary>
    /// Path to the PDF file currently opened by the ViewModel.
    /// </summary>
    [ObservableProperty]
    private string _pdfFilePath;

    [ObservableProperty]
    private ObservableCollection<Mat> _pdfPages;
    [ObservableProperty]
    private string _pdfZoomLevel = "Zoom: 100%";
    [ObservableProperty]
    private string _visiblePdfPage = "Page 0";
    /* #endregion Observable Properties */

    /* #region Private Properties */
    private Chart _chart;
    /// <summary>
    /// Signal to allow the ImportPdf command to pause and wait until
    /// the file picker closes.
    /// </summary>
    private SemaphoreSlim PdfPickerThreads;
    /* #endregion Private Properties */

    /* #region PDF Import Command */

    /// <summary>
    /// Open a file picker then print the path to the picked file.
    /// </summary>
    [RelayCommand]
    private async void ImportPdf()
    {
        IsPdfPickerOpen = true;
        PdfPickerThreads = new SemaphoreSlim(1, 2);
        await PdfPickerThreads.WaitAsync();

        if (PdfFilePath is not null) {
            Debug.WriteLine($"Picked {PdfFilePath}");
            _chart.ImportPdf(PdfFilePath);
            // PdfPages = new ObservableCollection<Mat>(_chart.PdfPages);
        } else {
            Debug.WriteLine("No file was picked");
        }
    }
    /* #endregion PDF Import Command */

    /// <summary>
    /// Runs when an observable property in the ViewModel is updated.
    /// </summary>
    /// <param name="sender">ViewModel property that was updated.</param>
    /// <param name="e">Arguments related to the event caller.</param>
    public void OnViewModelUpdate(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            // When IsPdfPickerOpen is updated to false, release a semaphore
            // to everything waiting for the pdf picker to close
            case (nameof(IsPdfPickerOpen)):
                if (!IsPdfPickerOpen) PdfPickerThreads.Release();
                break;
        }
    }

    /// <summary>
    /// Initialize a new instance of the <c>MainWindowViewModel</c> class.
    /// </summary>
    public MainViewModel()
    {
        IsPdfPickerOpen = false;
        _chart = new Chart();
    }
}

