using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;


namespace PatternSeer.ViewModels
{
    /// <summary>
    /// Primary ViewModel associated with the View <c>MainView</c>
    /// </summary>
    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        /* #region Observable Properties */
        /// <summary>
        /// Is/should the file picker currently be open?
        /// </summary>
        [ObservableProperty]
        private bool _isFilePickerOpen;
        /// <summary>
        /// File currently opened by the ViewModel.
        /// </summary>
        [ObservableProperty]
        private Uri _openedPattern;

        [ObservableProperty]
        private ObservableCollection<Bitmap> _pdfPages;
        [ObservableProperty]
        private string _pdfZoomLevel = "Zoom: 100%";
        [ObservableProperty]
        private Uri _pdfFilePath;
        [ObservableProperty]
        private string _visiblePdfPage = "Page 0";

        /// <summary>
        /// Runs when an observable property in the ViewModel is updated.
        /// </summary>
        /// <param name="sender">ViewModel that was updated.</param>
        /// <param name="e">Arguments related to the event.</param>
        public void OnViewModelUpdate(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                // When IsfilePicker is updated to false, release a signal
                // to everything waiting for the file picker to close
                case (nameof(IsFilePickerOpen)):
                    if (!IsFilePickerOpen) FilePickerCloseSignal.Release();
                    break;
            }
        }
        /* #endregion Observable Properties */


        /* #region PDF Import Command */
        /// <summary>
        /// Signal to allow the ImportPdf command to pause and wait until
        /// the file picker closes.
        /// </summary>
        private SemaphoreSlim FilePickerCloseSignal;
        /// <summary>
        /// Open a file picker then print the path to the picked file.
        /// </summary>
        [RelayCommand]
        private async void ImportPdf()
        {
            IsFilePickerOpen = true;
            FilePickerCloseSignal = new SemaphoreSlim(0, 1);

            await FilePickerCloseSignal.WaitAsync();

            if (OpenedPattern is not null)
            {
                Console.WriteLine($"Picked {OpenedPattern}");
                PdfFilePath = OpenedPattern;
            }
            else
            {
                Console.WriteLine("No file was picked");
            }
        }
        /* #endregion PDF Import Command */

        /* #region Exit Command */
        /// <summary>
        /// Command associated with the Exit trigger. Prints a message and
        /// then exits the program.
        /// </summary>
        [RelayCommand]
        private static void Exit()
        {
            Console.WriteLine("Goodbye ):");
            Environment.Exit(0);
        }
        /* #endregion Exit Command */

        /// <summary>
        /// Initialize a new instance of the <c>MainWindowViewModel</c> class.
        /// </summary>
        public MainViewModel()
        {
            IsFilePickerOpen = false;
            PdfPages = new ObservableCollection<Bitmap>{
                Util.LoadImageAsBitmap("C:\\Users\\samwi\\Desktop\\Programming\\Experiments\\PatternSeer\\PatternSeer\\assets\\DummyP1.png"),
                Util.LoadImageAsBitmap("C:\\Users\\samwi\\Desktop\\Programming\\Experiments\\PatternSeer\\PatternSeer\\assets\\DummyP2.png"),
                Util.LoadImageAsBitmap("C:\\Users\\samwi\\Desktop\\Programming\\Experiments\\PatternSeer\\PatternSeer\\assets\\DummyP3.png")
            };
        }
    }
}
