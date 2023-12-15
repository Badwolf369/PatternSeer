using Avalonia.Controls;
using Avalonia.Platform.Storage;


namespace PatternSeer.Views {
    /// <summary>
    /// Primary View used when launched as a desktop application.
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>
        /// Initializes a new instance of the <c>MainWindow</c> class.
        /// </summary>
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Event that asynchronously opens the system's file picker.
        /// Meant to be triggered as an event sent from the ViewModel.
        /// Event trigger configured in the App layer.
        /// </summary>
        /// <param name="sender">Object that sent the event call.</param>
        /// <param name="exitCallback">Callback function for when the event finishes.</param>
        public async void OpenSystemFilePickerAsync(Object sender, Action<Uri> exitCallback) {
            Console.WriteLine("Opening file selection dialogue");

            var topLevel = TopLevel.GetTopLevel(this);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions {
                    Title = "Open cross stitch chart PDF",
                    AllowMultiple = false,
                    FileTypeFilter = new[] {FilePickerFileTypes.Pdf}
            });
            Console.WriteLine("Closing file selection dialogue");

            if (files.Count > 0) {
                exitCallback(files[0].Path);
            } else {
                exitCallback(null);
            }
        }
    }
}
